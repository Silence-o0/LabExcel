using LabCalculator;
using System;
using System.Runtime.Serialization;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Windows.Forms;

namespace LabExcel
{
    public partial class mainForm : Form
    {
        List <char> symbols = new() {'=', ' ', '+', '-', '*', '/', '%', '(', '^'};
        public mainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            int startRowsQuantity = 10;
            addNewRow(0);

            for (int rowIndex = 1; rowIndex < startRowsQuantity; rowIndex++)
            {
                dataGridView.Rows.Add();
                addNewRow(rowIndex);
            }
        }

        private void addRowButton_Click(object sender, EventArgs e)
        {
            dataGridView.Rows.Add();
            addNewRow(dataGridView.RowCount-1);
        }

        private void addNewRow(int rowIndex)
        {
            List<DataCell> newRow = new List<DataCell>();
            for (int colIndex = 0; colIndex < this.dataGridView.Columns.Count; colIndex++)
            {
                newRow.Add(new DataCell(colIndex, rowIndex));
            }
            Data.cellsList.Add(newRow);
        }

        private void addColumnButton_Click(object sender, EventArgs e)
        {
            addNewColumn();
        }

        private void addNewColumn()
        {
            if (dataGridView.Columns.Count > 26)
            {
                MessageBox.Show("Занадто багато стовпчиків. Макс. кількість: 26.");
            }
            else
            {
                int columnIndex = dataGridView.ColumnCount;
                char columnLetter = (char)(columnIndex + Data.firstUpperASCII);

                dataGridView.Columns.Add(columnLetter.ToString(), columnLetter.ToString());
                dataGridView.Columns[columnIndex].Width = 120;
                dataGridView.Columns[columnIndex].SortMode = DataGridViewColumnSortMode.NotSortable;


                int rowIndex = 0;
                foreach (List<DataCell> row in Data.cellsList)
                {
                    row.Add(new DataCell(columnIndex, rowIndex));
                    rowIndex++;
                }
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.SelectedCells.Count == 1)
            {
                    formulaTextBox.Focus();
                    formulaTextBox.Text = Data.cellsList[dataGridView.SelectedCells[0].RowIndex][dataGridView.SelectedCells[0].ColumnIndex].Formula;
            }
        }

        private void dataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) // передає ім'я комірки в formulaTextBox
        {
            if (e.Button == MouseButtons.Right)   //Клік ПКМ
            {
                if (dataGridView.SelectedCells.Count == 1)
                {
                    int col = e.ColumnIndex;
                    int row = e.RowIndex;
                    if (formulaTextBox.Text.Length != 0)
                    {
                        char s = formulaTextBox.Text[formulaTextBox.Text.Length - 1];

                        if (symbols.Contains(s))
                        {
                            formulaTextBox.Text += Data.cellsList[row][col].Name;
                            formulaTextBox.SelectionStart = formulaTextBox.Text.Length;
                        }
                    }

                }
            }
        }


        private void formulaTextBox_KeyDown (object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)     //Натискання Enter
            {
                acceptEnterDataInCell();
            }
        }


        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count > 0 && dataGridView.SelectedRows.Count < dataGridView.Rows.Count) 
            {
                Data.isRowDeleting = true;

                int index1 = dataGridView.SelectedRows[0].Index;
                int index2 = dataGridView.SelectedRows[dataGridView.SelectedRows.Count - 1].Index;

                Data.firstElementToDelete = Math.Min(index1, index2);
                Data.lastElementToDelete = Math.Max(index1, index2);

            }
            else if (dataGridView.SelectedColumns.Count > 0 && dataGridView.SelectedColumns.Count < dataGridView.Columns.Count)
            {
                Data.isRowDeleting = false;

                int index1 = dataGridView.SelectedColumns[0].Index;
                int index2 = dataGridView.SelectedColumns[dataGridView.SelectedColumns.Count - 1].Index;

                Data.firstElementToDelete = Math.Min(index1, index2);
                Data.lastElementToDelete = Math.Max(index1, index2);
            }
            else
            {
                RowOrColumnDelete selectTypeOfDeletionForm = new RowOrColumnDelete();
                if(selectTypeOfDeletionForm.ShowDialog() == DialogResult.OK)
                {
                    Data.firstElementToDelete = -1;
                    Data.lastElementToDelete = -1;
                }
                else
                {
                    return;
                }
            }

            DeleteForm deleteForm = new DeleteForm();

            if (deleteForm.ShowDialog() == DialogResult.OK)
            {
                if(Data.isRowDeleting == true)  
                {
                    int difference = (Data.lastElementToDelete - Data.firstElementToDelete)+1;
                    for (int index = Data.lastElementToDelete + 1; index < Data.cellsList.Count; index++)
                    {
                        foreach (DataCell cell in Data.cellsList[index])
                        {
                            cell.Row -= difference;
                            cell.SetName();
                        }
                    }
                    
                    for (int i = Data.lastElementToDelete; i >= Data.firstElementToDelete; i--)
                    {
                        dataGridView.Rows.RemoveAt(i);
                        Data.cellsList.RemoveAt(i);
                    }

                }
                else
                {
                    int difference = (Data.lastElementToDelete - Data.firstElementToDelete) + 1;

                    for (int i = Data.lastElementToDelete; i >= Data.firstElementToDelete; i--)  //Видаляємо стовпчик
                    {
                        foreach (List<DataCell> list in Data.cellsList)
                        {
                            list.RemoveAt(i);
                        }
                        dataGridView.Columns.RemoveAt(i);
                    }

                    for (int index = Data.firstElementToDelete; index < Data.cellsList[0].Count; index++)   //Змінюємо індекси всіх наступних колонок
                    {
                        foreach (List<DataCell> list in Data.cellsList)
                        {
                            list[index].Column -= difference;
                            list[index].SetName();
                        }

                        char columnLetter = (char)(index + Data.firstUpperASCII);

                        dataGridView.Columns[index].HeaderText = columnLetter.ToString();
                        dataGridView.Columns[index].Name = columnLetter.ToString();
                    }

                }
            }


        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            acceptEnterDataInCell();
        }

        private void acceptEnterDataInCell()
        {
            if (dataGridView.SelectedCells.Count == 1)
            {
                if (formulaTextBox.Text.StartsWith("=") == true)
                {
                    var formula = formulaTextBox.Text[1..];
                    var res = Calculator.Evaluate(formula);
                    dataGridView.SelectedCells[0].Value = res.ToString();
                    Data.cellsList[dataGridView.SelectedCells[0].RowIndex][dataGridView.SelectedCells[0].ColumnIndex].Value = res.ToString();

                }
                else
                {
                    dataGridView.SelectedCells[0].Value = formulaTextBox.Text;
                    Data.cellsList[dataGridView.SelectedCells[0].RowIndex][dataGridView.SelectedCells[0].ColumnIndex].Value = formulaTextBox.Text;

                }
                Data.cellsList[dataGridView.SelectedCells[0].RowIndex][dataGridView.SelectedCells[0].ColumnIndex].Formula = formulaTextBox.Text;
            }
            else
            {
                MessageBox.Show("Error!");
            }
        }

        private void DataGridView_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)  //метод нумерації рядків
        {
            var grid = sender as DataGridView;
            var rowIndex = (e.RowIndex + 1).ToString();

            var centerFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
            e.Graphics.DrawString(rowIndex, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
        }

        private void dataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
        }

        private void dataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
        }

        private void saveAsButton_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        private static void Save()
        {
            try
            {
                if (Data.Path == null)
                {
                    MessageBox.Show("Не вдається знайти шлях. Спробуйте зберегти цей файл через 'Save as'.");
                }
                else
                {
                    var options = new JsonSerializerOptions
                    {
                        Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.LatinExtendedA),
                        WriteIndented = true
                    };

                    string serializedFile = JsonSerializer.Serialize(Data.cellsList, options);
                    File.WriteAllText(Data.Path, serializedFile);
                    MessageBox.Show("Файл було збережено!");
                }
            }
            catch (SerializationException)
            {
                MessageBox.Show("Помилка серіалізації файлу.");
            }
            catch
            {
                MessageBox.Show("Не вдалось зберегти файл.");
            }
        }

        private static void SaveAs()
        {
            try
            {
                SaveFileDialog saveFile = new()
                {
                    Filter = "Json-file|*.json",
                    Title = "Save as"
                };

                saveFile.ShowDialog();

                try
                {
                    var options = new JsonSerializerOptions
                    {
                        Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.LatinExtendedA),
                        WriteIndented = true
                    };

                    string serializedFile = JsonSerializer.Serialize(Data.cellsList, options);
                    File.WriteAllText(saveFile.FileName, serializedFile);
                    Data.Path = saveFile.FileName;
                }
                catch
                {
                    MessageBox.Show("Помилка серіалізації файлу.");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Не вдалось зберегти файл.");
            }
        }

        private void OpenAs()
        {
            try
            {
                OpenFileDialog openFile = new()
                {
                    Filter = "Json-file|*.json",
                    Title = "Open as"
                };

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    string Path = openFile.FileName;

                    try
                    {
                        var jsonContent = File.ReadAllText(Path);

                        Data.cellsList = JsonSerializer.Deserialize<List<List<DataCell>>>(jsonContent, new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        });

                        if (CheckFile() == false)
                        {
                            MessageBox.Show("Файл пошкоджений.");
                            return;
                        }

                        // Очищуємо dataGridView
                        dataGridView.Rows.Clear();
                        dataGridView.Columns.Clear();

                        if (Data.cellsList != null)
                        {
                            int columnCount = Data.cellsList[0].Count;
                            int rowCount = Data.cellsList.Count;


                            for (int i = 0; i < columnCount; i++)   //Створюємо стовпчики
                            {
                                char letter = (char)(i + Data.firstUpperASCII);

                                dataGridView.Columns.Add(letter.ToString(), letter.ToString());
                            }

                            for (int i = 0; i < rowCount; i++)    //Створюємо рядки
                            {
                                dataGridView.Rows.Add();
                            }

                            foreach (List<DataCell> list in Data.cellsList)    //Заповнюємо клітинки значеннями
                            {   
                                foreach (DataCell cell in list)
                                {
                                    dataGridView.Rows[cell.Row].Cells[cell.Column].Value = cell.Value;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Файл порожній.");
                            return;
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Не вдалось десеріалізувати файл.");
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Файл не було обрано.");
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Не вдалось відкрити файл.");
                return;
            }
        }

        private static bool CheckFile()
        {
            int cellInList = 0;

            for(int row = 0; row < Data.cellsList.Count; row++)    //Заповнюємо клітинки значеннями
            {
                for(int col = 0; col < Data.cellsList[row].Count; col++)
                {
                    cellInList++;
                    if (Data.cellsList[row][col].Row != row || Data.cellsList[row][col].Column != col 
                        || Data.cellsList[row][col].Name == null)
                    {
                        return false;
                    }
                }
            }

            int numOfCells = Data.cellsList.Count * Data.cellsList[0].Count;
           
            if (numOfCells != cellInList) 
            {
                return false;
            }


            return true;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void openAsButton_Click(object sender, EventArgs e)
        {
            OpenAs();
        }
    }
}
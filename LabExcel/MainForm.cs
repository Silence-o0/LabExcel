using LabCalculator;
using System;
using System.Data.Common;
using System.Runtime.Serialization;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace LabExcel
{
    public partial class MainForm : Form
    {
        readonly List <char> symbols = new() {'=', ' ', '+', '-', '*', '/', '%', '(', '^'};
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CreateNewTable();
        }

        private void CreateNewTable()
        {
            dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
            Data.Path = null;

            dataGridView.Rows.Clear();
            dataGridView.Columns.Clear();

            int defaultRowsQuantity = 10;
            int defaultColumnsQuantity = 10;

            Data.cellsList.Clear();

            CreateListOCfell(defaultRowsQuantity, defaultColumnsQuantity);

            CreateTableByList();
        }
        private void CreateListOCfell(int row, int col)
        {
            for (int i = 0; i < row; i++)
            {
                AddNewRowToList(i);
            }
            for (int i = 0; i < col; i++)
            {
                AddNewColumnToList(i);
            }
        }
        private void CreateTableByList()
        {
            if (Data.cellsList != null)
            {
                for (int columnIndex = 0; columnIndex < Data.cellsList[0].Count; columnIndex++)  //Створюємо стовпчики
                {
                    string columnLetter = ConverterColumnIndex.ConvertIndexToStringSymbol(columnIndex);
                    dataGridView.Columns.Add(columnLetter, columnLetter);

                    dataGridView.Columns[columnIndex].Width = 120;
                    dataGridView.Columns[columnIndex].SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                for (int rowIndex = 1; rowIndex < Data.cellsList.Count; rowIndex++)  //Створюємо рядки
                {
                    dataGridView.Rows.Add();
                }

                try
                {
                    for (int rowIndex = 0; rowIndex < Data.cellsList.Count; rowIndex++)    //Заповнюємо коміркм значеннями
                    {
                        for (int columnIndex = 0; columnIndex < Data.cellsList[rowIndex].Count; columnIndex++)
                        {
                            dataGridView.Rows[rowIndex].Cells[columnIndex].Value = Data.cellsList[rowIndex][columnIndex].Value;
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Не вдалось заповнити комірки значеннями.");
                }
            }
            else
            {
                MessageBox.Show("Файл порожній.");
                return;
            }
        }

        private void CreateNewTableButton_Click(object sender, EventArgs e)
        {
            CreateNewTable();
        }
        private void AddRowButton_Click(object sender, EventArgs e)
        {
            AddNewRow();
        }
        private void AddColumnButton_Click(object sender, EventArgs e)
        {
            AddNewColumn();
        }

        private void AddNewRow()
        {
            try
            {
                AddNewRowToList(dataGridView.Rows.Count);
                dataGridView.Rows.Add();
            }
            catch
            {
                MessageBox.Show("Не вдалось додати новий рядок.");
            }
        }

        private void AddNewRowToList(int rowIndex)
        {
            List<DataCell> newRow = new();
            for (int colIndex = 0; colIndex < dataGridView.Columns.Count; colIndex++)
            {
                newRow.Add(new DataCell(colIndex, rowIndex));
            }
            Data.cellsList.Add(newRow);
        }
        
        private void AddNewColumn()
        {
            int columnIndex = Data.cellsList[0].Count;
            if (columnIndex > 25)
            {
                MessageBox.Show("Занадто багато стовпчиків. Макс. кількість: 26.");
            }
            else
            {
                string columnLetter = ConverterColumnIndex.ConvertIndexToStringSymbol(columnIndex);

                dataGridView.Columns.Add(columnLetter, columnLetter);
                dataGridView.Columns[columnIndex].Width = 120;
                dataGridView.Columns[columnIndex].SortMode = DataGridViewColumnSortMode.NotSortable;

                AddNewColumnToList(columnIndex);
            }
        }

        private static void AddNewColumnToList(int columnIndex)
        {
            for (int rowIndex = 0; rowIndex < Data.cellsList.Count; rowIndex++)
            {
                Data.cellsList[rowIndex].Add(new DataCell(columnIndex, rowIndex));

            }
        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.SelectedCells.Count == 1)
            {
                formulaTextBox.Focus();

                int selectedRowIndex = dataGridView.SelectedCells[0].RowIndex;
                int selectedColumnIndex = dataGridView.SelectedCells[0].ColumnIndex;
                formulaTextBox.Text = Data.cellsList[selectedRowIndex][selectedColumnIndex].Formula;
                formulaTextBox.SelectionStart = formulaTextBox.Text.Length;
            }
        }

        private void DataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e) // передає ім'я комірки в formulaTextBox
        {
            if (e.Button == MouseButtons.Right)   //Клік ПКМ
            {
                int row = e.RowIndex;
                int col = e.ColumnIndex;

                AddCellNameToBox(row, col);
            }
        }
        private void AddCellNameToBox(int rowIndex, int colIndex)   //автоматично вводимо комірку в formulaTextBox
        {
            if (dataGridView.SelectedCells.Count == 1 && formulaTextBox.Text.Length != 0)
            {
                char lastSymbol = formulaTextBox.Text[^1]; //Отримуємо останній символ тексту в formulaTextBox

                if (symbols.Contains(lastSymbol))
                {
                    formulaTextBox.Text += Data.cellsList[rowIndex][colIndex].Name;
                    formulaTextBox.SelectionStart = formulaTextBox.Text.Length;
                }
            }
        }

        private void FormulaTextBox_KeyDown (object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)     //Натискання Enter
            {
                AcceptEnterDataInCell();
            }
        }
        private void AcceptButton_Click(object sender, EventArgs e)
        {
            AcceptEnterDataInCell();
        }

        private void AcceptEnterDataInCell()   //Обчислення та передача даний в комірку
        {
            if (dataGridView.SelectedCells.Count == 1)
            {
                int selectedRowIndex = dataGridView.SelectedCells[0].RowIndex;
                int selectedColumnIndex = dataGridView.SelectedCells[0].ColumnIndex;

                if (formulaTextBox.Text.StartsWith("=") == true)
                {
                    Data.cellsList[selectedRowIndex][selectedColumnIndex].CellsInFormula.Clear();

                    Data.currentCell = Data.cellsList[selectedRowIndex][selectedColumnIndex];
                    Data.cellsList[selectedRowIndex][selectedColumnIndex].Formula = formulaTextBox.Text;
                    CalculateFormula(selectedRowIndex, selectedColumnIndex);
                }
                else
                {
                    dataGridView.SelectedCells[0].Value = formulaTextBox.Text;
                    Data.cellsList[selectedRowIndex][selectedColumnIndex].Value = formulaTextBox.Text;
                }

                Data.cellsList[selectedRowIndex][selectedColumnIndex].Formula = formulaTextBox.Text;
                RefreshTable();
            }
            else
            {
                MessageBox.Show("Оберіть комірку, в яку хочете ввести дані.");
            }
        }
        private void CalculateFormula(int row, int col)
        {
            try
            {
                if (Data.cellsList[row][col].Formula[1..] != null)
                {
                    var formula = Data.cellsList[row][col].Formula[1..];
                    var res = Calculator.Evaluate(formula);
                    if (Data.CorrectCalculate == true)
                    {
                        dataGridView.Rows[row].Cells[col].Value = res.ToString();
                        Data.cellsList[row][col].Value = res.ToString();
                    }
                    else
                    {
                        dataGridView.Rows[row].Cells[col].Value = null;
                        Data.cellsList[row][col].Value = null;
                        formulaTextBox.Text = String.Empty;
                        Data.cellsList[row][col].Formula= null;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Не вдалось обчислити. Перевірте правильність введеної формули.");
            }
        }

        private void RefreshTable()
        {
            int row = 0;
            foreach(List<DataCell> list in Data.cellsList)
            {
                int col = 0;
                foreach (DataCell cell in list)
                {

                    if (cell.Formula != null)
                    {
                        if (cell.Formula.StartsWith("=") == true)
                        {
                            cell.CellsInFormula.Clear();

                            Data.currentCell = cell;
                            CalculateFormula(row, col);
                        }
                        else
                        {
                            cell.Value = cell.Formula;
                        }
                    }

                    col++;
                }
                row++;
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

        private void DataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect;
        }

        private void DataGridView_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect;
        }
        private void InfoButton_Click(object sender, EventArgs e)
        {
            InfoForm infoForm = new();
            infoForm.Show();
        }
        private void SaveAsButton_Click(object sender, EventArgs e)
        {
            FileWorker.SaveAs();
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            FileWorker.Save(Data.Path);
        }
        private void OpenAsButton_Click(object sender, EventArgs e)
        {
            OpenAs();
        }

        private void OpenAs()
        {
            try
            {
                dataGridView.SelectionMode = DataGridViewSelectionMode.CellSelect;
                FileWorker.OpenFile();

                // Очищуємо dataGridView
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();

                CreateTableByList();
            }
            catch
            {
                MessageBox.Show("Не вдалось відкрити файл.");
            }
        }
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DeleteElement();
        }

        private void DeleteElement()
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
                RowOrColumnDelete selectTypeOfDeletionForm = new();
                if (selectTypeOfDeletionForm.ShowDialog() == DialogResult.OK)
                {
                    Data.firstElementToDelete = Data.ErrorValueIndex;
                    Data.lastElementToDelete = Data.ErrorValueIndex;
                }
                else
                {
                    return;
                }
            }

            DeleteWithForm();   //функція, яка надалі працює з "Вікном видалення"
        }
        private void DeleteWithForm()
        {
            try
            {
                DeleteForm deleteForm = new();

                if (deleteForm.ShowDialog() == DialogResult.OK)
                {
                    int difference = (Data.lastElementToDelete - Data.firstElementToDelete) + 1;

                    if (Data.isRowDeleting == true)
                    {
                        for (int index = Data.lastElementToDelete + 1; index < Data.cellsList.Count; index++)   //Змінюємо індекси клітинок
                        {
                            foreach (DataCell cell in Data.cellsList[index])
                            {
                                cell.Row -= difference;
                                cell.SetName();
                            }
                        }
                        for (int i = Data.lastElementToDelete; i >= Data.firstElementToDelete; i--)    //Виділяємо рядок
                        {
                            dataGridView.Rows.RemoveAt(i);
                            Data.cellsList.RemoveAt(i);
                        }
                    }
                    else
                    {
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

                            string columnLetter = ConverterColumnIndex.ConvertIndexToStringSymbol(index);

                            dataGridView.Columns[index].HeaderText = columnLetter;
                            dataGridView.Columns[index].Name = columnLetter;
                        }
                    }

                    UpdateFormulas(difference);
                }
            }
            catch
            {
                MessageBox.Show("Не вдалось видалити.");
            }
        }
        private void UpdateFormulas(int difference)
        {
            try
            {
                if (Data.isRowDeleting == true)
                {
                    for (int rowInd = Data.firstElementToDelete; rowInd < Data.cellsList.Count; rowInd++)
                    {
                        foreach (DataCell cell in Data.cellsList[rowInd])
                        {
                            if(cell.Formula != null) 
                            {
                                ReplaceIdentInFormula(difference, cell);
                            }
                        }
                    }
                }
                else
                {
                    foreach (List <DataCell> list in Data.cellsList)
                    {
                        for (int colInd = Data.firstElementToDelete; colInd < list.Count; colInd++)
                        {
                            if (list[colInd].Formula != null)
                            {
                                ReplaceIdentInFormula(difference, list[colInd]);
                            }
                        }
                    }
                }
                RefreshTable();
            }
            catch
            {
                MessageBox.Show("Помилка оновлення формул.");
            }
        }

        private void ReplaceIdentInFormula(int difference, DataCell cell)
        {
            List<string> newListOfCells = new();
            foreach (string name in cell.CellsInFormula)
            {
                char column = name[0];
                int row = Int32.Parse(name[1..]);

                if (Data.isRowDeleting == true)
                {
                    row -= difference;
                    if (row < 1)
                    {
                        newListOfCells.Add("0");

                    }
                    else
                    {
                        string newCellName = column + row.ToString();
                        newListOfCells.Add(newCellName);
                    }
                    
                }
                else
                {
                    int columnNum = (int)column - difference;
                    if(columnNum < 65)
                    {
                        newListOfCells.Add("0");
                    }
                    else
                    {
                        string newCellName = (char)columnNum + row.ToString();
                        newListOfCells.Add(newCellName);
                    }
                }
            }

            for (int i = 0; i < cell.CellsInFormula.Count; i++)
            {
                cell.Formula = cell.Formula.Replace(cell.CellsInFormula[i], newListOfCells[i]);
            }

            formulaTextBox.Text = cell.Formula;
        }
    }
}
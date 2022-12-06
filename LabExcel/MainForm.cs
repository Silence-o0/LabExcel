using LabCalculator;
using System.Windows.Forms;

namespace LabExcel
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            dataGridView.RowCount = 10;

            for (int i = 0; i < this.dataGridView.Rows.Count; i++)
            {
                this.dataGridView.Rows[i].HeaderCell.Value = (i + 1).ToString();

                List<DataCell> row = new List<DataCell>();
                for (int j = 0; j < this.dataGridView.Columns.Count; j++)
                {
                    row.Add(new DataCell(j, i));
                }
                Data.cellsList.Add(row);
            }
        }

 //       private void AddNewRow()
 //       {
 //           formulas.Add(new List<string>());
 //       }
        

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                if (dataGridView.SelectedCells.Count == 1)
                {

                    formulaTextBox.Text = Data.cellsList[dataGridView.SelectedCells[0].RowIndex][dataGridView.SelectedCells[0].ColumnIndex].Formula;

                }
                else
                {
                    MessageBox.Show("Error!");
                }
        }

        private void dataGridView_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)   //Клік ПКМ
            {
                if(dataGridView.SelectedCells.Count == 1)
                {
                    int col = e.ColumnIndex;
                    int row = e.RowIndex;
                    if(formulaTextBox.Text.EndsWith("=") || formulaTextBox.Text.EndsWith("+")
                        || formulaTextBox.Text.EndsWith("-") || formulaTextBox.Text.EndsWith("*")
                        || formulaTextBox.Text.EndsWith("/") || formulaTextBox.Text.EndsWith("%") 
                        || formulaTextBox.Text == string.Empty)
                    {
     //                   string cellName = GetCellIndex(col, row);
                        formulaTextBox.Text += Data.cellsList[row][col].Name;
                        label1.Text = Data.cellsList[row][col].Name;
                        formulaTextBox.SelectionStart = formulaTextBox.Text.Length;
                    }

                    //       string value = dataGridView.Rows[row].Cells[col].Value.ToString();             

                    //       dataGridView[e.ColumnIndex, e.RowIndex].Selected = true;
                    //       formulaTextBox.Text = dataGridView.SelectedCells[e.ColumnIndex].ToString();
                }

            }
        }


        private void formulaTextBox_KeyDown (object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)     //Натискання Enter
            {
                if (dataGridView.SelectedCells.Count == 1) 
                {
                    if (formulaTextBox.Text.StartsWith("=") == true)
                    {
                        var formula = formulaTextBox.Text.Substring(1);
                        var res = Calculator.Evaluate(formula);
                        dataGridView.SelectedCells[0].Value = res.ToString();
                        Data.cellsList[dataGridView.SelectedCells[0].RowIndex][dataGridView.SelectedCells[0].ColumnIndex].Value = res.ToString();
                        Data.tableIdentifier.Add(Data.cellsList[dataGridView.SelectedCells[0].RowIndex][dataGridView.SelectedCells[0].ColumnIndex].Name, res);

                    }
                    else
                    {
                        dataGridView.SelectedCells[0].Value = formulaTextBox.Text;
                        Data.cellsList[dataGridView.SelectedCells[0].RowIndex][dataGridView.SelectedCells[0].ColumnIndex].Value = formulaTextBox.Text;
                        Data.tableIdentifier.Add(Data.cellsList[dataGridView.SelectedCells[0].RowIndex][dataGridView.SelectedCells[0].ColumnIndex].Name, Double.Parse(formulaTextBox.Text));

                    }
                    Data.cellsList[dataGridView.SelectedCells[0].RowIndex][dataGridView.SelectedCells[0].ColumnIndex].Formula = formulaTextBox.Text;
                }
                else
                {
                    MessageBox.Show("Error!");
                }

            }
        }

        private void formulaTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
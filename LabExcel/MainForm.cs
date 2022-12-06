using LabCalculator;
using System.Windows.Forms;

namespace LabExcel
{
    public partial class mainForm : Form
    {
        public List<List<string>> formulas = new List<List<string>>();
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

                List<string> l = new List<string>();
                for (int j = 0; j < this.dataGridView.Columns.Count; j++)
                {
                    l.Add(null);
                }
                formulas.Add(l);
            }
        }

        private void AddNewRow()
        {
            formulas.Add(new List<string>());
        }
        

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                if (dataGridView.SelectedCells.Count == 1)
                {

                    formulaTextBox.Text = formulas[dataGridView.SelectedCells[0].RowIndex][dataGridView.SelectedCells[0].ColumnIndex];

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
                        || formulaTextBox.Text.EndsWith("/") || formulaTextBox.Text.EndsWith("%"))
                    {
                        string cellName = GetCellIndex(col, row);
                        formulaTextBox.Text += cellName;
                    }

                    //       string value = dataGridView.Rows[row].Cells[col].Value.ToString();             

                    //       dataGridView[e.ColumnIndex, e.RowIndex].Selected = true;
                    //       formulaTextBox.Text = dataGridView.SelectedCells[e.ColumnIndex].ToString();
                }

            }
        }

        private string GetCellIndex(int colIndex, int rowIndex)
        {
            char column = (char)(colIndex + 65);
            int row = rowIndex + 1;
            string cellName = column.ToString() + row;
            label1.Text = cellName;

            return cellName;
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
                    }
                    else
                    {
                        dataGridView.SelectedCells[0].Value = formulaTextBox.Text;
                    }

                    formulas[dataGridView.SelectedCells[0].RowIndex][dataGridView.SelectedCells[0].ColumnIndex] = formulaTextBox.Text;
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
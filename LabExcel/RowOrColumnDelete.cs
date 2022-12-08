using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LabExcel
{
    public partial class RowOrColumnDelete : Form
    {
        public RowOrColumnDelete()
        {
            InitializeComponent();
        }

        private void RowSelectButton_Click(object sender, EventArgs e)
        {
            Data.isRowDeleting = true;
        }

        private void ColumnSelectButton_Click(object sender, EventArgs e)
        {
            Data.isRowDeleting = false;
        }
    }
}

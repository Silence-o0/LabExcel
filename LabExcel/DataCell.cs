using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExcel
{
    public static class Data
    {
        internal static string Path;
        internal static List<List<DataCell>> cellsList = new List<List<DataCell>>();
        public const int firstUpperASCII = 65;    // Значення першої великої літери за таблицею ASCII
        internal static bool isRowDeleting;             // Видаляємо рядок? (Чи стовпчик?)
        internal static int firstElementToDelete;     
        internal static int lastElementToDelete;
    }

    public class DataCell
    {
        public int Column { get; set; }
        public int Row { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; } = null;
        public string? Formula { get; set; } = null;
 //       public DataCell()
 //       {
 //           Value = null;
 //           Formula = Value;
 //       }
 //       public DataCell(string? name, string? value, string? formula)
 //       {
 //           Name = name;
 //           Value = value;
 //           Formula = formula;
 //       }
        public DataCell (int column, int row)
        {
            this.Column = column;
            this.Row = row;
            this.SetName();
        }
        public void SetName()
        {
            this.Name = GetCellName(this.Column, this.Row);
        }

        public string GetCellName(int colIndex, int rowIndex)
        {
            char column = (char)(colIndex + Data.firstUpperASCII);
            int row = rowIndex + 1;
            string cellName = column.ToString() + row;

            return cellName;
        }
    }
}

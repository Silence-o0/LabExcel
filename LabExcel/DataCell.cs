using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExcel
{
    public static class Data
    {
        public static List<List<DataCell>> cellsList = new List<List<DataCell>>();
        public static Dictionary<string, double> tableIdentifier = new Dictionary<string, double>();

    }

    public class DataCell
    {
        public int Column { get; set; }
        public int Row { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; }
        public string? Formula { get; set; }
        public DataCell()
        {
            Value = null;
            Formula = Value;
        }
        public DataCell(string? name, string? value, string? formula)
        {
            Name = name;
            Value = value;
            Formula = formula;
        }
        public DataCell (int column, int row)
        {
            Column = column;
            Row = row;
            Name = GetCellName(column, row);

        }
        public string GetCellName(int colIndex, int rowIndex)
        {
            char column = (char)(colIndex + 65);
            int row = rowIndex + 1;
            string cellName = column.ToString() + row;

            return cellName;
        }
    }
}

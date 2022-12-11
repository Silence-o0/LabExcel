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
        internal static string? Path = null;  //Шлях файлу
        internal static List<List<DataCell>> cellsList = new List<List<DataCell>>();
        internal static bool isRowDeleting;             // Видаляємо рядок? (Чи стовпчик?)
        internal static int firstElementToDelete;     
        internal static int lastElementToDelete;
        public const int ErrorValueIndex = -1;
        internal static bool CorrectCalculate;
        internal static DataCell currentCell;
    }

    public static class ConverterColumnIndex
    {
        public const int firstUpperASCII = 65;    // Значення першої великої літери за таблицею ASCII
        public static string ConvertIndexToStringSymbol(int columnIndex)  //Конвертує індекс індекс стовпчика в його символ (назву)
        {
            char columnLetter = (char)(columnIndex + firstUpperASCII);
            return columnLetter.ToString();
        }
        public static int ConvertStringSymbolToIndex(string columnLetter)  //Конвертує символ (назву) стовпчика в його індекс
        {
            int index = (int)columnLetter[0] - firstUpperASCII;
            return index;
        }
    }

    public class DataCell
    {
        public int Column { get; set; }
        public int Row { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; } = null;
        public string? Formula { get; set; } = null;
        public List <string> CellsInFormula = new();
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

        public static string GetCellName(int colIndex, int rowIndex)
        {
            string column = ConverterColumnIndex.ConvertIndexToStringSymbol(colIndex);
            int row = rowIndex + 1;
            string cellName = column + row;

            return cellName;
        }
    }
}

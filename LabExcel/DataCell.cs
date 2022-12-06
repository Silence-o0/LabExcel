using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabExcel
{
    public class DataCell
    {
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class ColumnType
    {
        public Autodesk.Revit.DB.Element RevitElement { get; set; }
        public List<Column> Columns { get; set; } = new List<Column>();
    }
}

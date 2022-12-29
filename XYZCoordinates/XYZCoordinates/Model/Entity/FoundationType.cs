using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class FoundationType
    {
        public Autodesk.Revit.DB.Element RevitElement { get; set; }
        public List<Foundation> Foundations { get; set; } = new List<Foundation>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class Floor
    {
        public Autodesk.Revit.DB.Element RevitElement { get; set; }
        public List<XYZCoordinates> XYZCoordinates { get; set; } = new List<Model.XYZCoordinates>();

    }
}

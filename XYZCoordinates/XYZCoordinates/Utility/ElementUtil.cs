using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingleData;
using Utility;
using Autodesk.Revit.DB.Structure;

namespace Utility
{
    public static class ElementUtil
    {
        private static RevitData revitData
        {
            get
            {
                return RevitData.Instance;
            }
        }
        private static ModelData modelData
        {
            get
            {
                return ModelData.Instance;
            }
        }
        public static Autodesk.Revit.DB.Element GetElement(this Autodesk.Revit.DB.ElementId elemId)
        {
            return revitData.Document.GetElement(elemId);
        }
        public static Autodesk.Revit.DB.Element GetElement(this Autodesk.Revit.DB.Reference elemRef)
        {
            return revitData.Document.GetElement(elemRef);
        }
        public static Autodesk.Revit.DB.XYZ GetLocationPoint (this Autodesk.Revit.DB.FamilyInstance pilesFI)
        {
            var locationPoint = pilesFI.Location as Autodesk.Revit.DB.LocationPoint;
            var point = locationPoint.Point;
            return point;
        }
       
       
        

    }
}

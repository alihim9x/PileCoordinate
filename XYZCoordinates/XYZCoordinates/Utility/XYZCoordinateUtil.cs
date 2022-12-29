using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using SingleData;

namespace Utility
{
    public static class XYZCoordinateUtil
    {
       private static RevitData revitData
        {
            get
            {
                return RevitData.Instance;
            }
        }
       
       public static Model.XYZCoordinates GetXYZCoordinates (this Autodesk.Revit.DB.XYZ point, Autodesk.Revit.DB.XYZ pickOriginPoint)
        {
            var modelXYZCoordinates = new Model.XYZCoordinates();
            var projectBasePoint = revitData.ProjectBasePoint;
            var ewX = projectBasePoint.get_Parameter(Autodesk.Revit.DB.BuiltInParameter.BASEPOINT_EASTWEST_PARAM).AsDouble().Feet2Milimeter();
            var snY = projectBasePoint.get_Parameter(Autodesk.Revit.DB.BuiltInParameter.BASEPOINT_NORTHSOUTH_PARAM).AsDouble().Feet2Milimeter();
            var angle = projectBasePoint.get_Parameter(Autodesk.Revit.DB.BuiltInParameter.BASEPOINT_ANGLETON_PARAM).AsDouble();
            var tf = Autodesk.Revit.DB.Transform.Identity;
            tf.Origin = pickOriginPoint;
            tf.BasisX = new Autodesk.Revit.DB.XYZ(1 * Math.Cos(angle) - 0, 1 * Math.Sin(angle), 0);
            tf.BasisY = new Autodesk.Revit.DB.XYZ(-Math.Sin(angle), Math.Cos(angle), 0);
            var resultPoint = tf.Inverse.OfPoint(point);
            modelXYZCoordinates.X = Math.Round((resultPoint.X.Feet2Milimeter() + ewX),0);
            modelXYZCoordinates.Y = Math.Round((resultPoint.Y.Feet2Milimeter() + snY),0) ;
            return modelXYZCoordinates;
        }
        public static Autodesk.Revit.DB.Line CreateLineFromXYZCoordinates (this Model.XYZCoordinates xyzCoordinate1, Model.XYZCoordinates xyzCoordinate2)
        {
            var pnt1 = new Autodesk.Revit.DB.XYZ(xyzCoordinate1.X, xyzCoordinate2.Y, 0);
            var pnt2 = new Autodesk.Revit.DB.XYZ(xyzCoordinate2.X, xyzCoordinate2.Y, 0);
            var line = Autodesk.Revit.DB.Line.CreateBound(pnt1, pnt2);
            return line;
        }
        public static Autodesk.Revit.DB.XYZ ConvertVN2000ToXYZRevit (this Model.XYZCoordinates xyzCoordinate)
        {
            var revitXYZ = new Autodesk.Revit.DB.XYZ (xyzCoordinate.X, xyzCoordinate.Y, 0);
            var projectBasePoint = (revitData.ProjectBasePoint as Autodesk.Revit.DB.BasePoint);
            var ewXProjectBP = projectBasePoint.get_Parameter(Autodesk.Revit.DB.BuiltInParameter.BASEPOINT_EASTWEST_PARAM).AsDouble();
            var nsYProjectBP = projectBasePoint.get_Parameter(Autodesk.Revit.DB.BuiltInParameter.BASEPOINT_NORTHSOUTH_PARAM).AsDouble();
            var angleProjectBP = projectBasePoint.get_Parameter(Autodesk.Revit.DB.BuiltInParameter.BASEPOINT_ANGLETON_PARAM).AsDouble();

            
            var resultPoint = new Autodesk.Revit.DB.XYZ(xyzCoordinate.X.Milimet2Feet() - ewXProjectBP, xyzCoordinate.Y.Milimet2Feet() - nsYProjectBP, 0);
            
            
            return resultPoint;
        }
    }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using SingleData;

namespace Utility
{
    public static class FloorUtil
    {
       private static RevitData revitData
        {
            get
            {
                return RevitData.Instance;
            }
        }
       
       public static Autodesk.Revit.DB.CurveArray GetCurveArray (this Model.Entity.Floor floor)
        {
            var projectBasePoint = revitData.ProjectBasePoint;            
            var listPoints = floor.XYZCoordinates;
            var projectBasePointInput = listPoints.First();
            projectBasePoint.SetValue("E/W", projectBasePointInput.X.Milimet2Feet());
            projectBasePoint.SetValue("N/S", projectBasePointInput.Y.Milimet2Feet());
            Autodesk.Revit.DB.CurveArray curveArr = new Autodesk.Revit.DB.CurveArray();
            var ewXProjectBP = projectBasePoint.get_Parameter(Autodesk.Revit.DB.BuiltInParameter.BASEPOINT_EASTWEST_PARAM).AsDouble();
            var nsYProjectBP = projectBasePoint.get_Parameter(Autodesk.Revit.DB.BuiltInParameter.BASEPOINT_NORTHSOUTH_PARAM).AsDouble();
            var angleProjectBP = projectBasePoint.get_Parameter(Autodesk.Revit.DB.BuiltInParameter.BASEPOINT_ANGLETON_PARAM).AsDouble();

            var tf = Autodesk.Revit.DB.Transform.Identity;
            tf.Origin = new Autodesk.Revit.DB.XYZ(0, 0, 0);
            tf.BasisX = new Autodesk.Revit.DB.XYZ(1 * Math.Cos(angleProjectBP) - 0, 1 * Math.Sin(angleProjectBP), 0);
            tf.BasisY = new Autodesk.Revit.DB.XYZ(-Math.Sin(angleProjectBP), Math.Cos(angleProjectBP), 0);

            for (int i = 0; i < listPoints.Count; i++)
            {
                Autodesk.Revit.DB.Line line = null;
                if(i != listPoints.Count - 1)
                {
                    line = Autodesk.Revit.DB.Line.CreateBound(listPoints[i].ConvertVN2000ToXYZRevit(),listPoints[i+1].ConvertVN2000ToXYZRevit());
                }
                else
                {
                    line = Autodesk.Revit.DB.Line.CreateBound(listPoints[i].ConvertVN2000ToXYZRevit(), listPoints[0].ConvertVN2000ToXYZRevit());
                }
                curveArr.Append(line);
            }

            return curveArr;
        }
        public static Autodesk.Revit.DB.Floor CreateFloorByVN2000 (this Model.Entity.Floor floorEtt)
        {
            var doc = revitData.Document;
            var activeView = revitData.ActiveView;
            var projectBasePoint = (revitData.ProjectBasePoint as Autodesk.Revit.DB.BasePoint);
            var angleToTrueNorth = projectBasePoint.get_Parameter(Autodesk.Revit.DB.BuiltInParameter.BASEPOINT_ANGLETON_PARAM).AsDouble();
            var floorType = ElementTypeUtil.GetFloorType("Generic 150mm");
            var level1 = LevelUtil.GetLevel("Level 1");
            var curveArr = floorEtt.GetCurveArray();
            var newFloor = doc.Create.NewFloor(curveArr, floorType, level1, false);
            var firstPoint = floorEtt.XYZCoordinates.First();
            var firstPointRV = firstPoint.ConvertVN2000ToXYZRevit();
            //var vectorTF = new Autodesk.Revit.DB.XYZ(0, 0, 0) - firstPointRV;
            Autodesk.Revit.DB.ElementTransformUtils.RotateElement(doc,newFloor.Id, Autodesk.Revit.DB.Line.CreateBound(new Autodesk.Revit.DB.XYZ(0,0,0), new Autodesk.Revit.DB.XYZ(0, 0, 0) + 500.0.Milimet2Feet()*Autodesk.Revit.DB.XYZ.BasisZ), angleToTrueNorth);
            
            

            return null;
            //return newFloor;
            




        }
       
    }
    
}

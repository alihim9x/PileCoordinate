using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingleData;
using Utility;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;

namespace XYZCoordinates
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            #region Initial

            RevitData revitData = RevitData.Instance;
            revitData.UIApplication = commandData.Application;
            var sel = revitData.Selection;
            var doc = revitData.Document;
            var activeView = revitData.ActiveView;
            var tx = revitData.Transaction;
            var uidoc = revitData.UIDocument;
            var app = revitData.Application;
            var formData = FormData.Instance;
            tx.Start();
            #endregion

            //var projectLocation = doc.ActiveProjectLocation;
            //var aaa = projectLocation.GetTotalTransform().Inverse.Origin;
            //XYZ origin = new XYZ(0, 0, 0);

            //ProjectPosition a = projectLocation.GetProjectPosition(origin);
            //var b = projectLocation.GetSiteLocation();



            //var x = a.EastWest;
            //var y = a.NorthSouth;
            //TaskDialog.Show("Revit", $"X:{x},Y:{y}");

            //ElementCategoryFilter filter = new ElementCategoryFilter(BuiltInCategory.OST_ProjectBasePoint);

            //FilteredElementCollector collector = new FilteredElementCollector(doc);
            //var ee = collector.WherePasses(filter).First();
            //var bPoint = ee as BasePoint;

            //var ee1 = revitData.ProjectBasePoint;

            //double x1 = ee1.get_Parameter(BuiltInParameter.BASEPOINT_EASTWEST_PARAM).AsDouble().Feet2Milimeter();
            //double y1 = ee1.get_Parameter(BuiltInParameter.BASEPOINT_NORTHSOUTH_PARAM).AsDouble().Feet2Milimeter();
            //double elevation = ee1.get_Parameter(BuiltInParameter.BASEPOINT_ELEVATION_PARAM).AsDouble().Feet2Milimeter();
            //double angle = ee1.get_Parameter(BuiltInParameter.BASEPOINT_ANGLETON_PARAM).AsDouble();

            ////TaskDialog.Show("Revit", $"X:{x1.Milimet2Feet()},Y:{y1.Milimet2Feet()}");
            ////var pnt1 = sel.PickPoint();
            ////var pnt2 = sel.PickPoint();
            ////var pnt3 = sel.PickPoint();
            //var tf = Transform.Identity;
            ////tf.Origin = new XYZ(x1 * Math.Cos(angle) - y1 * Math.Sin(angle),x1 * Math.Sin(angle) + y1 * Math.Cos(angle), 0);
            ////tf.Origin = new XYZ(x1, y1, 0);
            //tf.Origin = sel.PickPoint();
            //tf.BasisX = new XYZ(1 * Math.Cos(angle) - 0, 1 * Math.Sin(angle), 0);
            //tf.BasisY = new XYZ(-Math.Sin(angle), Math.Cos(angle), 0);
            //var pnt = sel.PickPoint();
            //var localPnt = tf.Inverse.OfPoint(pnt);
            //TaskDialog.Show("Revit", $"X:{localPnt.X.Feet2Milimeter() + x1},Y:{localPnt.Y.Feet2Milimeter() + y1}");
            ////TaskDialog.Show("Revit", $"X:{pnt.X},Y:{pnt.Y}");
            ///


            //var foundationCate = new List<Autodesk.Revit.DB.BuiltInCategory>
            //{
            //    Autodesk.Revit.DB.BuiltInCategory.OST_StructuralFoundation
            //};
            //ParameterUtil.AddParameter("XCoordinate(EW)", Model.AddParameterType.Instance, Model.DefinitionGroupType.KetCau, Autodesk.Revit.DB.ParameterType.Text,
            //    Autodesk.Revit.DB.BuiltInParameterGroup.PG_IDENTITY_DATA, foundationCate);
            //ParameterUtil.AddParameter("YCoordinate(NS)", Model.AddParameterType.Instance, Model.DefinitionGroupType.KetCau, Autodesk.Revit.DB.ParameterType.Text,
            //    Autodesk.Revit.DB.BuiltInParameterGroup.PG_IDENTITY_DATA, foundationCate);


            var form = formData.PileCoordinate;
            form.ShowDialog();



            //var pickProjectBasePoint = sel.PickPoint();
            //var piles = revitData.FoundationInstances.Where(x => x.Name == "D300").ToList();

            //var pileLocationPoints = revitData.FoundationInstances.Where(x => x.Name == "D300").Select(x => x.Location as LocationPoint).ToList();
            //var foundationCate = new List<BuiltInCategory>
            //{
            //    BuiltInCategory.OST_StructuralFoundation
            //};
            //ParameterUtil.AddParameter("XCoordinate(EW)", Model.AddParameterType.Instance, Model.DefinitionGroupType.KetCau, ParameterType.Text,
            //    BuiltInParameterGroup.PG_IDENTITY_DATA, foundationCate);
            //ParameterUtil.AddParameter("YCoordinate(NS)", Model.AddParameterType.Instance, Model.DefinitionGroupType.KetCau, ParameterType.Text,
            //    BuiltInParameterGroup.PG_IDENTITY_DATA, foundationCate);
            //foreach (var item in piles)
            //{
            //    var point = item.GetLocationPoint().GetXYZCoordinates(pickProjectBasePoint);
            //    item.SetValue("XCoordinate(EW)", point.X.ToString());
            //    item.SetValue("YCoordinate(NS)", point.Y.ToString());
            //}       
            //var result = sel.PickPoint().GetXYZCoordinates(pickProjectBasePoint);
            //TaskDialog.Show("Revit", $"X:{result.X}, Y:{result.Y}");


            ////var pnt11 = new XYZ(600567065.0.Milimet2Feet(), 1194285538.0.Milimet2Feet(), 0);
            ////var pnt12 = new XYZ(600562904.0.Milimet2Feet(), 1194305576.0.Milimet2Feet(), 0);
            ////var pnt13 = new XYZ(600585047.0.Milimet2Feet(), 1194305872.0.Milimet2Feet(), 0);
            ////var pnt14 = new XYZ(600584570.0.Milimet2Feet(), 1194276650.0.Milimet2Feet(), 0);
            ////var curveArray = new CurveArray();

            //List<XYZ> xyz1 = new List<XYZ> { pnt11, pnt12, pnt13, pnt14 };
            //for (int i = 0; i < xyz1.Count; i++)
            //{
            //    Line line1 = null;
            //    if (i != xyz1.Count - 1)

            //    {
            //        line1 = Line.CreateBound(xyz1[i], xyz1[i + 1]);
            //    }
            //    else
            //    {
            //        line1 = Line.CreateBound(xyz1[i], xyz1[0]);
            //    }
            //    curveArray.Append(line1);
            //}

            //var floorType = revitData.FloorTypes.Where(x=>x.Name == "150mm").First() as FloorType;
            //var level1 = revitData.Levels.Where(x => x.Name == "Level 1").Single();

            //doc.Create.NewFloor(curveArray, floorType, level1, true);

            ////var projectLocation = doc.ActiveProjectLocation;
            ////var aaa = projectLocation.GetTotalTransform().Inverse.Origin;

            ////var pnt111 = new XYZ(-23.4854363005067, -27.6806946485487, 0);
            ////Line aaaaa = null;
            ////aaaaa = Line.CreateBound(pnt111, pnt111 + 3000000.0.Milimet2Feet() * XYZ.BasisY);

            //var ee1 = revitData.ProjectBasePoint as BasePoint;

            //ee1.SetValue("N/S", 1194285538.0.Milimet2Feet());
            //ee1.SetValue("E/W", 600567065.0.Milimet2Feet());
            


            tx.Commit();
            return Result.Succeeded;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Utility;
using SingleData;

namespace Model.Form
{
    /// <summary>
    /// Interaction logic for PileCoordinate.xaml
    /// </summary>
    public partial class PileCoordinate : Window
    {
        public PileCoordinate()
        {
            InitializeComponent(); 

        }

        private void PickProjectBasePoint_Click(object sender, RoutedEventArgs e)
        {
            FormUtil.PickProjectBasePoint();
        }

        private void GetPileCoordinate_Click(object sender, RoutedEventArgs e)
        {
            
            
            var pickProjectBasePoint = ModelData.Instance.CurrentProjectBasePoint;
            //var piles = ModelData.Instance.CurrentFoundationType.Foundations.Select(x=>x.RevitElement as Autodesk.Revit.DB.FamilyInstance);
            var piles = ModelData.Instance.CurrentFoundationFamily.Foundations.Select(x => x.RevitElement as Autodesk.Revit.DB.FamilyInstance);
            var setting = ModelData.Instance.Setting;
            var roundingDecimal = setting.Decimal;

            var pileLocationPoints = piles.Select(x => x.Location as Autodesk.Revit.DB.LocationPoint).ToList();           
            foreach (var item in piles)
            {
                var point = item.GetLocationPoint().GetXYZCoordinates(pickProjectBasePoint);
                item.SetValue("02_SE_XCOORDINATE(EW)", Math.Round((point.X/1000),roundingDecimal).ToString("0.000"));
                item.SetValue("02_SE_YCOORDINATE(NS)", Math.Round((point.Y/1000), roundingDecimal).ToString("0.000"));
            }
            Autodesk.Revit.UI.TaskDialog.Show("Revit", "Done!");
            var form = FormData.Instance.PileCoordinate;
            form.Close();
            


            //var columnTYpe = ModelData.Instance.CurrentColumnType.Columns;
            //foreach (var item in columnTYpe)
            //{
            //    item.RevitElement.SetValue("Comments", "a");
            //}
        }
    }
}

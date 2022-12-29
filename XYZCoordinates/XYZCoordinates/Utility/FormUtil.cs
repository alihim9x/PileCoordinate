using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;
using SingleData;

namespace Utility
{
    public static class FormUtil
    {
        private static RevitData revitData
        {
            get
            {
                return RevitData.Instance;
            }
        }
        private static FormData formData
        {
            get
            {
                return FormData.Instance;
            }
        }
        private static ModelData modelData
        {
            get
            {
                return ModelData.Instance;
            }
        }
        public static void PickProjectBasePoint()
        {
            var form = formData.PileCoordinate;
            form.Hide();
            var sel = revitData.Selection;
            try
            {
                formData.CurrentProjectBasePoint = sel.PickPoint();
            }
            catch(Autodesk.Revit.Exceptions.OperationCanceledException)
            {

            }
            form.ShowDialog();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingleData;
using Utility;
using Model.Entity;

namespace SingleData
{
    public class ModelData
    {
        public static ModelData Instance { get { return SingleTon.Instance.ModelData; } }

        private static RevitData revitData
        {
            get
            {
                return RevitData.Instance;
            }
        }
        

        private List<Model.Entity.ColumnType> columnTypes;
        public List<Model.Entity.ColumnType> ColumnTypes
        {
            get
            {
                if (columnTypes == null) columnTypes = ColumnTypeUtil.GetColumnTypes();
                return columnTypes;
            }
        }

        public Model.Entity.ColumnType CurrentColumnType { get; set; }
        private List<Model.Entity.FoundationType> foundationTypes;
        public List<Model.Entity.FoundationType> FoundationTypes
        {
            get
            {
                if (foundationTypes == null) foundationTypes = FoundationTypeUtil.GetFoundationTypes();
                return foundationTypes;
            }
        }
        public Model.Entity.FoundationType CurrentFoundationType { get; set; }
        public Model.Entity.FoundationFamily CurrentFoundationFamily { get; set; }
        public Autodesk.Revit.DB.XYZ CurrentProjectBasePoint { get; set; }
        private List<Model.Entity.FoundationFamily> foundationFamilies;
        public List<Model.Entity.FoundationFamily> FoundationFamilies
        {
            get
            {
                if (foundationFamilies == null) foundationFamilies = FoundationTypeUtil.GetFoundationFamilies();
                return foundationFamilies;
            }
        }
        private Setting setting;
        public Setting Setting
        {
            get
            {
                if(setting == null)
                {
                    setting = new Setting();
                }
                return setting;
            }
        }
    }
}

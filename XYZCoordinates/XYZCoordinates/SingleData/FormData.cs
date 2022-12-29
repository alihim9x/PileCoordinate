using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace SingleData
{
    public class FormData : NotifyClass
    {
        public static FormData Instance
        {
            get
            {
                return SingleTon.Instance.FormData;
            }
        }
        private Model.Form.PileCoordinate pileCoordinate;
        public Model.Form.PileCoordinate PileCoordinate
        {
            get
            {
                if(pileCoordinate == null)
                {
                    pileCoordinate = new Model.Form.PileCoordinate
                    {
                        DataContext = this
                    };
                }
                return pileCoordinate;
            }
        }
        

            
        public List<Model.Entity.ColumnType> ColumnTypes
        {
            get
            {
                return ModelData.Instance.ColumnTypes;
            }
        }

        private Model.Entity.ColumnType currentColumnType;
        public Model.Entity.ColumnType CurrentColumnType
        {
            get
            {
                return currentColumnType;
            }
            set
            {
                currentColumnType = value;
                OnPropertyChanged();

                ModelData.Instance.CurrentColumnType = value;
            }
        }
        public List<Model.Entity.FoundationFamily> FoundationFamilies
        {
            get
            {
                return ModelData.Instance.FoundationFamilies;
            }
        }
        public List<Model.Entity.FoundationType> FoundationTypes
        {
            get
            {
                return ModelData.Instance.FoundationTypes;
            }
        }
        private Model.Entity.FoundationType currentFoundationType;
        public Model.Entity.FoundationType CurrentFoundationType
        {
            get
            {
                return currentFoundationType;
            }
            set
            {
                currentFoundationType = value;
                OnPropertyChanged();
                ModelData.Instance.CurrentFoundationType = value;
            }
        }
        private Model.Entity.FoundationFamily currentFoundationFamily;
        public Model.Entity.FoundationFamily CurrentFoundationFamily
        {
            get
            {
                return currentFoundationFamily;
            }
            set
            {
                currentFoundationFamily = value;
                OnPropertyChanged();
                ModelData.Instance.CurrentFoundationFamily = value;
            }
        }
        private Autodesk.Revit.DB.XYZ currentProjectBasePoint;
        public Autodesk.Revit.DB.XYZ CurrentProjectBasePoint
        {
            get
            {
                return currentProjectBasePoint;
            }
            set
            {
                currentProjectBasePoint = value;
                OnPropertyChanged();
                ModelData.Instance.CurrentProjectBasePoint = value;
            }
        }
        private Model.ViewModel.SettingView settingView;
        public Model.ViewModel.SettingView SettingView
        {
            get
            {
                if(settingView == null)
                {
                    settingView = new Model.ViewModel.SettingView()
                    {
                        Setting = ModelData.Instance.Setting
                    };
                }
                return settingView;
            }
        }

    }
}

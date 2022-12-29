using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;


namespace Model.Entity
{
    public class Setting : NotifyClass
    {
        private int deCimal;
        public int Decimal
        {
            get
            {
                return deCimal;
            }
            set
            {
                if (deCimal == value) return;
                deCimal = value;
                OnPropertyChanged();
            }
        }
           
    }
}

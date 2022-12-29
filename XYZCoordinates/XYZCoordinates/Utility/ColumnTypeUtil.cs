using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SingleData;

namespace Utility
{
    public static class ColumnTypeUtil
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
        public static List<Model.Entity.ColumnType> GetColumnTypes()
        {
            var columnTypes = new List<Model.Entity.ColumnType>();

            foreach (var element in revitData.ColumnInstances)
            {
                var elementType = element.Symbol;
                var columnType = columnTypes.SingleOrDefault(x => x.RevitElement.Id == elementType.Id);
                if (columnType == null)
                {
                    columnType = new Model.Entity.ColumnType
                    {
                        RevitElement = elementType
                    };

                    columnTypes.Add(columnType);
                }

                var column = new Model.Entity.Column
                {
                    RevitElement = element
                };
                columnType.Columns.Add(column);
            }

            return columnTypes;
        }
    }
}

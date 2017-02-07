using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PositionMatrixContainerDataModel.Models.Models;

namespace PositionMatrixContainerDataModel.Models.Exceptions
{
    public class DifferentIndexedMatrixType:Exception
    {
        #region Properties
        public PointDimension Type1 { get; set; }
        public PointDimension Type2 { get; set; }

        public override string Message { get; }
        #endregion

        #region Constructor

        public DifferentIndexedMatrixType(PointDimension type1, PointDimension type2)
        {
            Type1 = type1;
            Type2 = type2;

            Message =
                string.Format(
                    "Each indexed matrix via containers should be the same type. Type {0} and type {1} are different.",
                    Type1, Type2);
        }
        #endregion
    }
}

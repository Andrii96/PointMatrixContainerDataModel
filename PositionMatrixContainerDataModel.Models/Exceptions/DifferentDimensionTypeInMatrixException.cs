using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PositionMatrixContainerDataModel.Models.Models;

namespace PositionMatrixContainerDataModel.Models.Exceptions
{
    public class DifferentDimensionTypeInMatrixException:Exception
    {
        #region Properties
        public PointDimension MatrixType { get; set; }

        public override string Message { get; }

        #endregion

        #region Constructor

        public DifferentDimensionTypeInMatrixException(PointDimension type)
        {
            MatrixType = type;
            Message = string.Format("All positions in matrix should be of the same type.{0} type is different.", type);
        }
        #endregion
    }
}

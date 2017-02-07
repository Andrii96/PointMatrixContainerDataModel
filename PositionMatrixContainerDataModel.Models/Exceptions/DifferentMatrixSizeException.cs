using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMatrixContainerDataModel.Models.Exceptions
{
    public class DifferentMatrixSizeException:Exception
    {
        #region Properties
        public int MatrixSize { get; set; }

        public override string Message { get; }

        #endregion

        #region Constructor

        public DifferentMatrixSizeException(int matrixSize)
        {
            MatrixSize = matrixSize;
            Message = string.Format("All matrices in container should have the same length - {0} elements.",MatrixSize);
        }
        #endregion
    }
}

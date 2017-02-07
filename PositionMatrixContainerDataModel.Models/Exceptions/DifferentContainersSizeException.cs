using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMatrixContainerDataModel.Models.Exceptions
{
    public class DifferentContainersSizeException:Exception
    {
        #region Properties
        public int ContainerSize { get; set; }

        public override string Message { get; }

        #endregion
        #region Constructor

        public DifferentContainersSizeException(int size)
        {
            ContainerSize = size;
            Message = string.Format("Each container should have equal number of matrices - {0}", ContainerSize);
        }
        #endregion
    }
}

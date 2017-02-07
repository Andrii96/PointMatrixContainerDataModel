using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMatrixContainerDataModel.Models.Exceptions
{
    public class NotNumericTypeException:Exception
    {
        #region Properties
        public Type Type { get; set; }

        public override string Message { get; }
        #endregion

        #region Constructor

        public NotNumericTypeException(Type type)
        {
            Type = type;

            Message = string.Format("Only numeric types allowed. {0} is not numeric type.", type.Name);
        }
        #endregion
    }
}

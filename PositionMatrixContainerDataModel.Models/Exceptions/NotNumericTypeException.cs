using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PositionMatrixContainerDataModel.Models.Exceptions
{
    [Serializable]
    public class NotNumericTypeException:ApplicationException
    {
        #region Properties
        public Type Type { get; set; }
        #endregion

        #region Constructor

        public NotNumericTypeException() : base() { }

        public NotNumericTypeException(string message) : base(message) { }

        public NotNumericTypeException(string message,Exception innerException) : base(message, innerException) { }

        public NotNumericTypeException(Type type):this(string.Format("Only numeric types allowed. {0} is not numeric type.", type.Name))
        {
            Type = type;            
        }

        protected NotNumericTypeException(SerializationInfo info,StreamingContext context) : base(info, context) { }

        #endregion
    }
}

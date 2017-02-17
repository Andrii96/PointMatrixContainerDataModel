using System;
using System.Linq;
using PositionMatrixContainer.Models.Exceptions;

namespace PositionMatrixContainer.Models.Helpers
{
    public abstract class NumericType<T>
    {
        #region Constructor

        protected NumericType()
        {
            if (!CheckType(typeof(T)))
            {
                throw new NotNumericTypeException(typeof(T));
            }
        }

        #endregion

        #region Helpers

        private static bool IsNumericType(Type type)
        {
            return Type.GetTypeCode(type) == TypeCode.Byte || Type.GetTypeCode(type) == TypeCode.Decimal ||
                   Type.GetTypeCode(type) == TypeCode.Double || Type.GetTypeCode(type) == TypeCode.Int16 ||
                   Type.GetTypeCode(type) == TypeCode.Int32 || Type.GetTypeCode(type) == TypeCode.Int64 ||
                   Type.GetTypeCode(type) == TypeCode.SByte || Type.GetTypeCode(type) == TypeCode.Single ||
                   Type.GetTypeCode(type) == TypeCode.UInt16 || Type.GetTypeCode(type) == TypeCode.UInt32 ||
                   Type.GetTypeCode(type) == TypeCode.UInt64;
        }

        private bool CheckType(Type type)
        {
            return IsNumericType(type.IsGenericType ? type.GenericTypeArguments.First() : type);
        }

        #endregion
    }
}

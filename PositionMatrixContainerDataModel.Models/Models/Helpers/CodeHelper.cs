using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PositionMatrixContainerDataModel.Models.Models.Helpers
{
    public static class CodeHelper
    {
        public static TResult IfNotNull<T, TResult>(this T value, Func<T, TResult> converter)
        {
            return value != null ? converter(value) : default(TResult);
        }
    }
}

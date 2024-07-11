using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Extentions
{
    public static class ArrayExtentions
    {
        public static bool IsNullOrEmpty<T>(this T[] array)
        {
            if (array == null || array.Length == 0) return true;
            return false;
        }
    }
}

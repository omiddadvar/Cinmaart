using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Extentions
{
    public static class ListExtentions
    {
        public static bool IsNullOrEmpty<T>(this List<T> array)
        {
            if (array == null || array.Count == 0) return true;
            return false;
        }
    }
}

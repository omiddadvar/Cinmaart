using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Application.Extentions.Files
{
    public static class FiulenameExtensions
    {
        public static string GetExtension(this string filename)
        {
            var splitted =  filename.Split('.');
            return splitted[splitted.Length - 1];
        }
        public static string GetExtensionToUpper(this string filename)
        {
            return GetExtension(filename);
        }
    }
}

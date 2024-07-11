using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinamaart.Domain.Extentions
{
    public static class JsonExtentions
    {
        public static string? ToJson(this object obj)
        {
            try
            {
                if (obj is string)
                    return obj.ToString();
                return JsonConvert.SerializeObject(obj);
            }
            catch
            {
                return null;
            }
        }
        public static T? ToModel<T>(this string jsonString)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonString);
            }
            catch
            {
                return default(T);
            }
        } 
    }
}

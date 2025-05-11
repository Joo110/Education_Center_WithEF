using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access.GlobalUtilities
{
    public static class ExceptionHandle
    {
        public static T? TryCatch<T>(Func<T> func)
        {
            try
            {
                return func();
            }
            catch
            {
                return default;
            }
        }
        
        public static async Task<T?> TryCatchAsync<T>(Func<Task<T>> func)
        {
            try
            {
                return await func();
            }
            catch
            {
                return default;
            }
        }
    }
}

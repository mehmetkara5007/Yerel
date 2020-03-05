using System;

namespace Yerel.Core.Utilities.ExtensionMethods
{
    public static class ConvertExtensionMethods
    {
        public static int ToInt32(this object obj)
        {
            return Convert.ToInt32(obj);
        }

        public static double ToDouble(this object obj)
        {
            return Convert.ToDouble(obj);
        }

        public static decimal ToDecimal(this object obj)
        {
            return Convert.ToDecimal(obj);
        }

        public static bool ToBoolean(this object obj)
        {
            return Convert.ToBoolean(obj);
        }

        public static long ToLong(this object obj)
        {
            return Convert.ToInt64(obj);
        }
    }
}

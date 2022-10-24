using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BlueLotus360.Core.Domain.Extension
{
    public static class ObjectExtensions
    {
        public static string Truncate(this string value, int maxChars)
        {
            if (value == null)
            {
                return "";
            }
            return value.Length <= maxChars ? value : value.Substring(0, maxChars);
        }

        public static bool IsOn(this string value)
        {
            return value != null && value.Equals("on");

        }

        public static bool IsDefaultSqlDate(this DateTime value)
        {
            return value.Year == 1900 && value.Month == 1 && value.Day == 1;

        }

        public static object GetPropValue(this object obj, string name)
        {
            foreach (String part in name.Split('.'))
            {
                if (obj == null) { return null; }

                Type type = obj.GetType();
                PropertyInfo info = type.GetProperty(part);
                if (info == null) { return null; }

                obj = info.GetValue(obj, null);
            }
            return obj;
        }

        public static T GetPropValue<T>(this object obj, string name)
        {
            try
            {

                Type t1 = typeof(T);
                if (name != null)
                {
                    object retval = GetPropValue(obj, name);
                    if (retval == null)
                    {
                        return default(T);
                    }
                    Type t3 = retval.GetType();
                    if (retval == null) { return default(T); }
                    if (t1 == typeof(int))
                    {
                        object value = Convert.ToInt32(retval);
                        return (T)value;

                    }
                    else if (t1 == typeof(long))
                    {
                        object value = Convert.ToInt64(retval);
                        return (T)value;
                    }

                    else
                    {
                        return (T)retval;
                    }
                }
                return default(T);
            }
            catch (Exception exp)
            {
                return default(T);
            }
        }

        public static string GetPropValueInString(this object obj, string name, string format = null)
        {
            try
            {
                if (format != null && format.Trim().Length > 0)
                {
                    object value = GetPropValue(obj, name);
                    if (value is DateTime)
                    {
                        return ((DateTime)value).ToString(format);
                    }
                    if (value is int)
                    {
                        return ((int)value).ToString(format);
                    }
                    if (value is decimal)
                    {
                        return ((decimal)value).ToString(format);
                    }
                    if (value is long)
                    {
                        return ((long)value).ToString(format);
                    }
                    if (value is float)
                    {
                        return ((float)value).ToString(format);
                    }
                    if (value is double)
                    {
                        return ((double)value).ToString(format);
                    }
                    return value.ToString();
                }
                return GetPropValue(obj, name).ToString();

            }
            catch
            {
                return string.Empty;
            }


        }



        static readonly string[] SizeSuffixes =
                   { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        public static string SizeSuffix(this long value, int decimalPlaces = 2)
        {
            if (decimalPlaces < 0) { throw new ArgumentOutOfRangeException("decimalPlaces"); }
            if (value < 0) { return "-" + SizeSuffix(-value); }
            if (value == 0) { return string.Format("{0:n" + decimalPlaces + "} bytes", 0); }

            // mag is 0 for bytes, 1 for KB, 2, for MB, etc.
            int mag = (int)Math.Log(value, 1024);

            // 1L << (mag * 10) == 2 ^ (10 * mag) 
            // [i.e. the number of bytes in the unit corresponding to mag]
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            // make adjustment when the value is large enough that
            // it would round up to 1000 or more
            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                mag += 1;
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}",
                adjustedSize,
                SizeSuffixes[mag]);
        }

    }
}

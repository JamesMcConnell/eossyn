using System;
using System.Text.RegularExpressions;

namespace Eossyn.Core.Extensions
{
    public static class Conversion
    {
        /// <summary>
        /// Used to convert a given object to a specific type, if it is null or cannot be cast
        /// it will return the defaultvalue.
        /// This method will  not throw an error regardless of value passed in.
        /// </summary>
        /// <typeparam name="T">Type to be returned. ie(int)</typeparam>
        /// <param name="obj">The object to be converted to the specified type.</param>
        /// <param name="defaultValue">A default value in case the object cannot be converted.</param>
        /// <returns>T</returns>
        public static T Convert<T>(this object obj, T defaultValue)
        {
            if (obj == null)
            {
                return defaultValue;
            }
            if (obj == DBNull.Value)
            {
                return defaultValue;
            }
            if (obj.GetType() == typeof(T))
            {
                return (T)obj;
            }
            var result = ConvertFrom(obj, defaultValue);
            if (result != null)
            {
                return (T)result;
            }
            return defaultValue;
        }
        /// <summary>
        /// Converts the object passed in to the type of the defaultValue.
        /// </summary>
        /// <param name="obj">The object to be converted.</param>
        /// <param name="defaultValue">The default value if the object cannot be converted(or type is not found).</param>
        /// <returns>The resulting object or the defaultValue.</returns>
        private static object ConvertFrom(object obj, object defaultValue)
        {
            var d = defaultValue.GetType();
            if (obj == null)
            {
                return defaultValue;
            }
            if (d == typeof(bool))
            {
                return ToBoolean(obj, defaultValue);
            }
            if (d == typeof(byte))
            {
                return ToByte(obj, defaultValue);
            }
            if (d == typeof(char))
            {
                return ToChar(obj, defaultValue);
            }
            if (d == typeof(DateTime))
            {
                return ToDateTime(obj, defaultValue);
            }
            if (d == typeof(decimal))
            {
                return ToDecimal(obj, defaultValue);
            }
            if (d == typeof(double))
            {
                return ToDouble(obj, defaultValue);
            }
            if (d == typeof(Int16))
            {
                return ToInt16(obj, defaultValue);
            }
            if (d == typeof(Int32))
            {
                return ToInt32(obj, defaultValue);
            }
            if (d == typeof(Int64))
            {
                return ToInt64(obj, defaultValue);
            }
            if (d == typeof(Single))
            {
                return ToSingle(obj, defaultValue);
            }
            if (d == typeof(string))
            {
                return ToString(obj, defaultValue);
            }
            return d == typeof(Guid) ? ToGuid(obj, defaultValue) : defaultValue;
        }

        #region IConvertible Members
        //These will not throw an error unless the value passed in is null!!!!!!!

        public static object ToBoolean(object value, object defaultValue)
        {
            bool result;
            return bool.TryParse(value.ToString(), out result) ? result : defaultValue;
        }

        public static object ToByte(object value, object defaultValue)
        {
            byte result;
            return byte.TryParse(value.ToString(), out result) ? result : defaultValue;
        }

        public static object ToChar(object value, object defaultValue)
        {
            char result;
            return char.TryParse(value.ToString(), out result) ? result : defaultValue;
        }

        public static object ToDateTime(object value, object defaultValue)
        {
            var result = DateTime.Now;
            return DateTime.TryParse(value.ToString(), out result) ? result : defaultValue;
        }

        public static object ToDecimal(object value, object defaultValue)
        {
            decimal result;
            return decimal.TryParse(value.ToString(), out result) ? result : defaultValue;
        }

        public static object ToDouble(object value, object defaultValue)
        {
            double result;
            return double.TryParse(value.ToString(), out result) ? result : defaultValue;
        }

        public static object ToInt16(object value, object defaultValue)
        {
            short result;
            return short.TryParse(value.ToString(), out result) ? result : defaultValue;
        }

        public static object ToInt32(object value, object defaultValue)
        {
            int result;
            return int.TryParse(value.ToString(), out result) ? result : defaultValue;
        }

        public static object ToInt64(object value, object defaultValue)
        {
            long result;
            return long.TryParse(value.ToString(), out result) ? result : defaultValue;
        }

        public static object ToSingle(object value, object defaultValue)
        {
            float result;
            return float.TryParse(value.ToString(), out result) ? result : defaultValue;
        }

        public static object ToString(object value, object defaultValue)
        {
            return value.ToString();
        }
        public static object ToGuid(object value, object defaultValue)
        {
            if (value.GetType() == typeof(Guid) || value.GetType() == typeof(string))
            {
                var isGuid = new Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", RegexOptions.Compiled);
                if (isGuid.IsMatch(value.ToString()))
                {
                    return new Guid(value.ToString());
                }
            }
            return defaultValue;
        }

        #endregion
    }
}

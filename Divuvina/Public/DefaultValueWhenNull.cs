using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Divuvina.Public
{
    public class DefaultValueWhenNull
    {
        public static DateTime DefaultDate = new DateTime(1990, 1, 1);
        public static short ConvertShort(short? value)
        {
            return value == null ? (short)0 : (short)value;
        }
        public static short ConvertShort(string value)
        {
            return String.IsNullOrEmpty(value)? (short)0 : short.Parse(value);
        }
        public static decimal ConvertDecimal(decimal? value)
        {
            return value == null ? 0 : (decimal)value;
        }
        public static decimal ConvertDecimal(string value)
        {
            return String.IsNullOrEmpty(value) ? 0 : decimal.Parse(value);
        }
        public static double ConvertDouble(double? value)
        {
            return value == null ? 0 : (double)value;
        }
        public static double ConvertDouble(string value)
        {
            return String.IsNullOrEmpty(value) ? 0 : double.Parse(value);
        }
        public static int ConvertInt(int? value)
        {
            return value == null ? 0 : (int)value;
        }
        public static int ConvertInt(string value)
        {
            return String.IsNullOrEmpty(value) ? 0 : int.Parse(value);
        }
        public static string ConvertString(string value)
        {
            return String.IsNullOrEmpty(value)? string.Empty : value;
        }
        public static DateTime ConvertDatetime(DateTime? value)
        {
            return value == null ? new DateTime(1990,1,1) : (DateTime)value;
        }
        public static DateTime ConvertDatetime(string value)
        {
            return String.IsNullOrEmpty(value) ? new DateTime(1990, 1, 1) : DateTime.Parse(value);
        }

    }//EndClass
}//EndNamespace
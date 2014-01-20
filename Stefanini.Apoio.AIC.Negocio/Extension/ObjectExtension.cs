using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace System
{
    public static class ObjectExtension
    {

        public static bool IsNumeric(this object valor)
        {

            Regex reNum = new Regex(@"^\d*[0-9](\.\d*[0-9])?$");
            bool isNumeric = reNum.Match(valor.ToString()).Success;
            return isNumeric;

        }

        public static T ParseEnum<T>(this object obj)
        {
            return (T)Enum.Parse(typeof(T), Convert.ToString(obj));
        }


    }
}

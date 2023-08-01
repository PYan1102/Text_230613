﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnCube_Switch.Converters
{

   
    internal class DateTimeConverter  
    {
        /// <summary>
        /// 轉換日期行蝶和字串型別的
        /// </summary>
        internal static DateTime ToDateTime(string input, string format)
        {
            DateTime.TryParseExact(input, format, null, DateTimeStyles.None, out DateTime result);
            return result;
        }
    }
}

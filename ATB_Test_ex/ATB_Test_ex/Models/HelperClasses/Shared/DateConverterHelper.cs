using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATB_Test_ex.Models.HelperClasses.Shared
{
    public class DateConverterHelper
    {
        public static string DateForWeb(DateTime? date)
        {
            if (date == null)
            {
                return "";
            }
            else
                return ((DateTime)date).ToString("yyyy-MM-ddTHH:mm:ss.fffffffZ");
        }
    }
}
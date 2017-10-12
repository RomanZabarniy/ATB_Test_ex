using ATB_Test_ex.Models.DB_Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ATB_Test_ex.Models.HelperClasses.Enums
{
    public class DropDownContent
    {
        public static async Task<string> GetCityStringAsync()
        {
            string ls = "";
            using (EmployeeContext db = new EmployeeContext())
            {
                var lm = await db.Cities.OrderBy(x => x.Name).ToListAsync();
                foreach (var temp in lm)
                {
                    ls += temp.Name + ",";
                }
            }
            return string.IsNullOrEmpty(ls) ? "" : ls.Substring(0, ls.Length - 1);
        }
    }
}
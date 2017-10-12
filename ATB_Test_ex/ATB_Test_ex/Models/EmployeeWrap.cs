using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATB_Test_ex.Models
{
    public class EmployeeWrap
    {
        public int EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public DateTime BirsdayDate { get; set; }
        public string Sex { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
    }
}
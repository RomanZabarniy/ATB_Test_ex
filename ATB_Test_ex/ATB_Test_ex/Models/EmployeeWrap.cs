using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ATB_Test_ex.Models
{
    public class EmployeeWrap
    {
        public int EmployeeId { get; set; }
        [StringLength(100)]
        public string FullName { get; set; }
        public int DepartmentId { get; set; }
        [StringLength(100)]
        public string DepartmentName { get; set; }
        [Column(TypeName = "date")]
        public DateTime? BirsdayDate { get; set; }
        public string BDateString { get; set; }
        [StringLength(1)]
        public string Sex { get; set; }
        [StringLength(100)]
        public string City { get; set; }
        [StringLength(100)]
        public string Adress { get; set; }
        [StringLength(20)]
        public string Phone { get; set; }
    }
}
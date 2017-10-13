using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ATB_Test_ex.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [MaxLength(100)]
        public string FullName { get; set; }
        public int DepartmentId { get; set; }
        [Column("Date", TypeName = "datetime2")]
        public DateTime BirsdayDate { get; set; }
        [Column(TypeName = "char")]
        [StringLength(1, MinimumLength = 1)]
        public string Sex { get; set; }
        public string City { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }

        internal bool Save(object organizationID, object errorList)
        {
            throw new NotImplementedException();
        }
    }
}

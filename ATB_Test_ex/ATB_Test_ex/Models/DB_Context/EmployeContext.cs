using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ATB_Test.Models.DB_Context
{
    public class EmployeContext : DbContext
    {
        public DbSet<Employee> Employes { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}

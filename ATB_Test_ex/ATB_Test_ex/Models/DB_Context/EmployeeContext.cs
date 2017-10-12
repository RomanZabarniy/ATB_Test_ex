using ATB_Test_ex.Models.Domain.Entity;
using System.Data.Entity;

namespace ATB_Test_ex.Models.DB_Context
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employes { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}

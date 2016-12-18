using System.Data.Entity;

namespace Urgentcargus.Models
{
    public class UrgentCargusContext : DbContext
    {
        public UrgentCargusContext() : base("name=UrgentCargus")
        {
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
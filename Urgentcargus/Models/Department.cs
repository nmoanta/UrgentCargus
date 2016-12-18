using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Urgentcargus.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [ForeignKey("ParentDepartment")]
        public int? ParentId { get; set; }
        public virtual Department  ParentDepartment { get; set; }
        public virtual ICollection<Department> Children { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
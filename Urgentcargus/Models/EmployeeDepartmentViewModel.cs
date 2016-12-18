using System.ComponentModel.DataAnnotations;

namespace Urgentcargus.Models
{
    public class EmployeeDepartmentViewModel
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }
    }
}
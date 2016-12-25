using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Urgentcargus.Models
{
    public class AddEmployeeViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime? BirthDate { get; set; }
        public int DepartmentId { get; set; }
    }
}
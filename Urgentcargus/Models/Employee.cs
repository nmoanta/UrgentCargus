using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Urgentcargus.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public virtual Department Department { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
    }
}
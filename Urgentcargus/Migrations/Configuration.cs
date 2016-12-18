namespace Urgentcargus.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Models.UrgentCargusContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Urgentcargus.Models.UrgentCargusContext context)
        {
            context.Departments.AddOrUpdate(
              p => p.Id,
              new Department { Name = "Analysis", Id = 1 },
              new Department { Name = "Digital Inovation", Id = 2 },
              new Department { Name = "Operations", Id = 3 },
              new Department { Name = "Science & Technology", Id = 4 },
              new Department { Name = "Support", Id = 5 },

              new Department { Name = "Office of Analytic Production and Dissemination", ParentId = 1, Employees = new List<Employee> { new Employee { FirstName = "Aldrich", LastName = "Ames", DateOfBirth = new DateTime(1941, 5, 26) } }, Id = 6 },
              new Department { Name = "Office Advanced Analytics", ParentId = 1, Id = 7 },

              new Department { Name = "Agency Data Office", ParentId = 2, Id = 8 },
              new Department { Name = "Center for Cyber Intelligence", ParentId = 2, Employees = new List<Employee> { new Employee { FirstName = "David", LastName = "Barnett" }, new Employee { FirstName = "Ana", LastName = "Montes", DateOfBirth = new DateTime(1957, 2, 27) } }, Id = 9 },

              new Department { Name = "Human Resources Staff", ParentId = 3, Id = 10 },
              new Department { Name = "Intelligence and Foreign Affairs", ParentId = 3, Id = 11 },

              new Department { Name = "US-CERT", ParentId = 11, Employees = new List<Employee> { new Employee { FirstName = "Anna", LastName = "Chapman" } }, Id = 12 }
            );
        }
    }
}

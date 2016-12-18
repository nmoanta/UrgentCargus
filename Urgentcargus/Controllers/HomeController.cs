using AutoMapper;
using System.Collections.Generic;
using System.Web.Mvc;
using Urgentcargus.Models;
using System.Linq;
using System;

namespace Urgentcargus.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeDepartmentService m_EmployeeDepartmentService;
        public HomeController(IEmployeeDepartmentService employeeDepartmentService)
        {
            m_EmployeeDepartmentService = employeeDepartmentService;
        }
        // GET: Home
        public ActionResult Index(string fName = null, string lName = null, string dep = null)
        {
            IList<Employee> employees = !Request.IsAjaxRequest() ? m_EmployeeDepartmentService.GetEmployees() : m_EmployeeDepartmentService.GetEmployees(fName, lName, dep);
            Mapper.CreateMap<Employee, EmployeeDepartmentViewModel>();
            IList<EmployeeDepartmentViewModel> viewModelList = Mapper.Map<IList<Employee>, IList<EmployeeDepartmentViewModel>>(employees);

            if (Request.IsAjaxRequest())
            {
                return PartialView("_Employees", viewModelList);
            }

            return View(viewModelList);
        }
    }
    public interface IEmployeeDepartmentService
    {
        IList<Employee> GetEmployees();
        IList<Employee> GetEmployees(string fn, string ln, string dep);
    }
    public class EmployeeDepartmentService : IEmployeeDepartmentService
    {
        private static UrgentCargusContext db = new UrgentCargusContext();
        public IList<Employee> GetEmployees()
        {
            var employees = from e in db.Employees
                            select e;
            return employees.ToList();
        }
        public IList<Employee> GetEmployees(string fn, string ln, string dep)
        {
            var employees = from e in db.Employees
                            select e;
            if (!String.IsNullOrEmpty(fn))
            {
                employees = employees.Where(e => e.FirstName.Contains(fn));
            }
            if (!String.IsNullOrEmpty(ln))
            {
                employees = employees.Where(e => e.LastName.Contains(ln));
            }
            if (!String.IsNullOrEmpty(dep))
            {
                employees = employees.Where(e => e.Department.Name.Contains(fn));
            }
            return employees.ToList();
        }
    }
}
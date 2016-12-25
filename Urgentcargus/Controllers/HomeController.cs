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
        private readonly IDepartmentService m_DepartmentService;
        public HomeController(IEmployeeDepartmentService employeeDepartmentService, IDepartmentService departmentService)
        {
            m_EmployeeDepartmentService = employeeDepartmentService;
            m_DepartmentService = departmentService;
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

            Mapper.CreateMap<Department, DepartmentViewModel>();
            IList<Department> departments = m_DepartmentService.GetDepartments();
            ViewBag.Departments = new SelectList(departments, "Id", "Name");

            return View(viewModelList);
        }

        public ActionResult Add(AddEmployeeViewModel employee)
        {
            Mapper.CreateMap<AddEmployeeViewModel, Employee>()
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.Phone))
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.BirthDate));
            Employee emp = Mapper.Map<AddEmployeeViewModel, Employee>(employee);

            m_EmployeeDepartmentService.AddEmployee(emp);

            return RedirectToAction("Index");
        }
    }

    public interface IEmployeeDepartmentService
    {
        IList<Employee> GetEmployees();
        IList<Employee> GetEmployees(string fn, string ln, string dep);
        void AddEmployee(Employee emp);
    }

    public interface IDepartmentService
    {
        IList<Department> GetDepartments();
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
                employees = employees.Where(e => e.Department.Name.Contains(dep));
            }
            return employees.ToList();
        }

        public void AddEmployee(Employee emp)
        {
            db.Employees.Add(emp);
            db.SaveChanges();
        }
    }

    public class DepartmentService : IDepartmentService
    {
        private static UrgentCargusContext db = new UrgentCargusContext();
        public IList<Department> GetDepartments()
        {
            return db.Departments.ToList();
        }
    }
}
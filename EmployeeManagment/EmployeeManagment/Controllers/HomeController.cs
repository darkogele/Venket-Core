using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagment.Models;
using EmployeeManagment.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagment.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        public HomeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
       
        public IActionResult Index()
        {
           var list = _employeeRepository.GetEmployeesAll();
           return View(list);
          // return _employeeRepository.GetEmployee(1);
          // return Json(new { myObj = new { name = "Darko", age = "31", cars = new { car1 = "Mazda", car2 = "Ford", car3 = "Opel" } } });
        }

      
        public ActionResult Details(int? id)
        {
            Employee model = _employeeRepository.GetEmployee(1);
            ViewBag.PageTitle = "Employee Details";
            //  return View(model);
            var homeDetailsViewModel = new HomeDetailsViewModel();
            homeDetailsViewModel.Employee = _employeeRepository.GetEmployee(id??1);
            homeDetailsViewModel.PageTitle = "Employee Details";
            //{             
            //    Employee = _employeeRepository.GetEmployee(1),
            //    PageTitle = "Employee Details"
            //};
            return View(homeDetailsViewModel);
        }
    }
}

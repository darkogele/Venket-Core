using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagment.Models;
using EmployeeManagment.Models.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagment.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHostingEnvironment hostingEnvironment;

        public HomeController(IEmployeeRepository employeeRepository, IHostingEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            this.hostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            var list = _employeeRepository.GetEmployeesAll();
            return View(list);
            // return _employeeRepository.GetEmployee(1);
            // return Json(new { myObj = new { name = "Darko", age = "31", cars = new { car1 = "Mazda", car2 = "Ford", car3 = "Opel" } } });
        }

        public IActionResult Details(int? id)
        {
            Employee model = _employeeRepository.GetEmployee(1);
            ViewBag.PageTitle = "Employee Details";
            //  return View(model);
            var homeDetailsViewModel = new HomeDetailsViewModel();
            homeDetailsViewModel.Employee = _employeeRepository.GetEmployee(id ?? 1);
            homeDetailsViewModel.PageTitle = "Employee Details";
            //{             
            //    Employee = _employeeRepository.GetEmployee(1),
            //    PageTitle = "Employee Details"
            //};
            return View(homeDetailsViewModel);
        }

        public IActionResult Create()
        {
            // ViewBag.EmpCount = _employeeRepository.GetEmployeesAll().Count();
            return View();
        }

        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqieFileName = null;

                if (model.Photo != null && validationForOnlyImage(model.Photo.FileName))
                {
                    var uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath + "\\images\\Users");
                    uniqieFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    var filePath = Path.Combine(uploadsFolder, uniqieFileName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                var newEmployee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = uniqieFileName
                };

                _employeeRepository.Add(newEmployee);
                return RedirectToAction("Details", new { id = newEmployee.Id });
            }
            return View();
        }
        #region Private Methods
        private static bool validationForOnlyImage(string file)
        {
            string[] imageTypes = { "jpg", "bmp", "gif", "png" };
            bool contains = false;
            foreach (var type in imageTypes)
            {
                contains = file.Contains(type);
                if (contains)
                {
                    return contains;
                }
            }
            return contains;
        }
        #endregion

    }
}

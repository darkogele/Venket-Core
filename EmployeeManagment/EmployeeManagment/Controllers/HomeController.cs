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
            // throw new Exception("Ne radi bre") //-- za test
            var employee = _employeeRepository.GetEmployee(id.Value);
            if (employee == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", id.Value);
            }

            var homeDetailsViewModel = new HomeDetailsViewModel
            {
                Employee = employee,
                PageTitle = "Employee Details"
            };

            return View(homeDetailsViewModel);
        }

        [HttpGet]
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
                var newEmployee = new Employee
                {
                    Name = model.Name,
                    Email = model.Email,
                    Department = model.Department,
                    PhotoPath = ProcesUploadedFile(model)
                };
                _employeeRepository.Add(newEmployee);
                return RedirectToAction("Details", new { id = newEmployee.Id });
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _employeeRepository.GetEmployee(id);
            var employeeEditViewModel = new EmployeeEditViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Email = employee.Email,
                Department = employee.Department,
                ExistingPhotoPath = employee.PhotoPath
            };
            return View(employeeEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var updateEmployee = _employeeRepository.GetEmployee(model.Id);
                updateEmployee.Id = model.Id;
                updateEmployee.Name = model.Name;
                updateEmployee.Email = model.Email;
                updateEmployee.Department = model.Department;
                if (model.Photo != null)
                {
                    if (model.ExistingPhotoPath != null)
                    {
                        var filePath = Path.Combine(hostingEnvironment.WebRootPath + @"\images\users\" + model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
                    updateEmployee.PhotoPath = ProcesUploadedFile(model);
                }

                _employeeRepository.Update(updateEmployee);
                TempData["updateDone"] = "Employee was Updated";
            }
            return RedirectToAction("index");
        }

        #region Private Methods

        private string ProcesUploadedFile(EmployeeCreateViewModel model)
        {
            string uniqieFileName = null;
            if (model.Photo != null && ValidationForOnlyImage(model.Photo.FileName))
            {
                var uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath + @"\images\Users");
                uniqieFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                var filePath = Path.Combine(uploadsFolder, uniqieFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }
            return uniqieFileName;
        }

        private static bool ValidationForOnlyImage(string file)
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

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                 new Employee() { Id = 1, Name = "Mary", Department = "HR", Email = "MaryTheSlut@gmail.com" },
                 new Employee() { Id = 2, Name = "Dare", Department = "GURU", Email = "Darkogele23@gmail.com" },
                 new Employee() { Id = 3, Name = "Joco", Department = "TechLead", Email = "kecac@gmail.com" },
            };

            var sam = new Employee() { Name = "Dare", Id = 69, Department = "KILLER", Email = "MajkoKecac@69.com" };
            var poveke = new List<Employee>()
            {
                new Employee(){ Id = 1, Name = "Mary", Department = "HR", Email = "MaryTheSlut@gmail.com" },
                new Employee() { Id = 2, Name = "Dare", Department = "GURU", Email = "Darkogele23@gmail.com" },
            };
            poveke.Add(new Employee() { Id = 2, Name = "Dare", Department = "GURU", Email = "Darkogele23@gmail.com" });
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.Id == Id);
        }

        public List<Employee> GetEmployees()
        {
            return _employeeList;
        }

        public IEnumerable<Employee> GetEmployeesAll()
        {
            return _employeeList;
        }     
    }
}

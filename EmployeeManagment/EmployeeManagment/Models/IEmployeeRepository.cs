﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.Models
{
    public  interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);
        List<Employee> GetEmployees();
        IEnumerable<Employee> GetEmployeesAll();
        Employee Add(Employee employee);
    }
}

using EmployeeManagement.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EmployeeManagment.Models
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<SQLEmployeeRepository> _logger;

        public SQLEmployeeRepository(AppDbContext context, ILogger<SQLEmployeeRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Employee Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
            return employee;
        }

        public Employee Delete(int Id)
        {
            var employee = _context.Employees.FirstOrDefault(e => e.Id == Id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
            return employee;
        }

        public Employee GetEmployee(int Id)
        {
            _logger.LogTrace("Trace log");
            _logger.LogDebug("Debug log");
            _logger.LogInformation("Information log");
            _logger.LogWarning("Warrning log");
            _logger.LogError("Error log");
            _logger.LogCritical("Critical log");

            return _context.Employees.Find(Id); // NOVO Samo davas ID i go vraka ne sporedue 
        }

        public List<Employee> GetEmployees()
        {
            return _context.Employees.ToList();
        }

        public IEnumerable<Employee> GetEmployeesAll()
        {
            return _context.Employees;          
        }

        public Employee Update(Employee employeeChanges)  
        {
            var employee = _context.Employees.Attach(employeeChanges); // NOVO Go nema vo EF 6
            employee.State = EntityState.Modified;
            _context.SaveChanges();
            return employeeChanges;
        }
    }
}

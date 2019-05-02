using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.Models.SeedData
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                 new Employee
                 {
                     Id = 1,
                     Name = "Darko",
                     Department = Dept.IT,
                     Email = "Darkogele@hotmail.com"
                 },
                 new Employee
                 {
                     Id = 2,
                     Name = "Daro",
                     Department = Dept.Payroll,
                     Email = "Darkogele@live.com"
                 }
            );
        }
    }
}

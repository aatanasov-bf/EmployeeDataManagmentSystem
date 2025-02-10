using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataManagmentSystem
{
    public class Employee
    {
        public string FullName { get; set; }
        public Country Country { get; set; }
        public List<string> AssignedDepartments { get; set; }
        public decimal Salary { get; set; }

        public Employee() { }

        public Employee(string fullName, Country country)
        {
            FullName = fullName;
            Country = country;
        }

        public Employee(string fullName, Country country, decimal salary)
        {
            FullName = fullName;
            Country = country;
            Salary = salary;
        }

        public void AddDepartment(string department)
        {
            if (!AssignedDepartments.Contains(department.ToLower(),StringComparer.OrdinalIgnoreCase))
                AssignedDepartments.Add(department);
            else
                throw new Exception("Department already added");
        }

        public void UpdateSalary(decimal salary)
        {
            if (salary > 0)
                Salary = salary;
            else
                throw new Exception("Salry must be a positive number!");
        }
    }

}

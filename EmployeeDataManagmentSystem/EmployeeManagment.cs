using EmployeeDataManagmentSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataManagmentSystem
{
    public class EmployeeManagment
    {
        private const string employeeStorageFilePath = "employees.json";
        private List<Employee> employees = FileServices.LoadFromFile(employeeStorageFilePath);

        public void AddEmployee(Employee employee)
        {
            if (!IsExistingEmployee(employee))
            {
                employees.Add(employee);
                Console.WriteLine("Employee succesfully added\n");
            }

            else
                Console.WriteLine("Employee already exists!\n");
        }

        public void RemoveEmployee(string employeeName)
        {
            if (IsExistingEmployee(employeeName))
            {
                employees.Remove(GetCertainEmployee(employeeName));
                Console.WriteLine("Employee successfully removed\n");
            }
            else
                Console.WriteLine("Employee not found!\n");
        }

        public void AssignDepartment(string employeeName, string departmentName)
        {
            if (!IsExistingEmployee(employeeName))
                Console.WriteLine("Employee does not exist!\n");
            else if (IsExistingDepartment(departmentName))
                Console.WriteLine("Department already assigned!\n");
            else
            {
                Employee employee = GetCertainEmployee(employeeName);
                employee.AddDepartment(departmentName);
            }
        }

        public void UpdateSalary(string employeeName, decimal newSalary)
        {
            if (!IsExistingEmployee(employeeName))
                Console.WriteLine("Employee does not exist!\n");
            else
            {
                Employee employee = GetCertainEmployee(employeeName);
                employee.UpdateSalary(newSalary);
            }
        }

        public void DisplayEmployees()
        {
            if (employees.Count > 0)
            {
                Console.WriteLine("-List of all employees-");
                foreach (Employee employee in employees)
                {
                    Console.WriteLine($"Employee Name: {employee.FullName}");
                    Console.WriteLine($"Employee Country: {employee.Country.Name.CountryCommonName}");
                    if (employee.AssignedDepartments != null)
                        Console.WriteLine($"Employee Assigned Departments: {string.Join(", ", employee.AssignedDepartments)}");
                    else
                        Console.WriteLine($"Employee Assigned Departments: None");
                    Console.WriteLine($"Employee Salary: {employee.Salary}");
                    Console.WriteLine();
                }
            }
            else
                Console.WriteLine("List is empty!\n");
        }

        public Employee GetCertainEmployee(string employeeName)
        {
            return employees.FirstOrDefault(e => e.FullName.Equals(employeeName, StringComparison.OrdinalIgnoreCase));
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }

        private bool IsExistingEmployee(Employee employee)
        {
            return employees.Any(e => e.FullName.Equals(employee.FullName, StringComparison.OrdinalIgnoreCase));
        }

        private bool IsExistingEmployee(string employeeName)
        {
            return employees.Any(e => e.FullName.Equals(employeeName, StringComparison.OrdinalIgnoreCase));
        }

        private bool IsExistingDepartment(string departmentName)
        {
            return employees.Any(e => e.AssignedDepartments!=null && e.AssignedDepartments.Contains(departmentName,StringComparer.OrdinalIgnoreCase));
        }
    }
}

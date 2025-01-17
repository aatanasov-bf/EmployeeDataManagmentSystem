using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDataManagmentSystem
{
    public class Emplyee
    {
        public string FullName { get; set; }
        public Country Country { get; set; }
        public List<string> AssignedDepartments { get; set; }
        public decimal Salary { get; set; }

        public Emplyee() { }

        public Emplyee(string fullName, Country country, List<string> assignedDepartments, decimal salary)
        {
            FullName = fullName;
            Country = country;
            AssignedDepartments = assignedDepartments;
            Salary = salary;
        }
    }

}

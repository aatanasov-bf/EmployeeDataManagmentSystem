using EmployeeDataManagmentSystem;
using EmployeeDataManagmentSystem.Services;

CountryService countryService = new CountryService();
EmployeeManagment employeeManagment = new EmployeeManagment();
List<Country> countries = countryService.FetchCountryList();

Console.WriteLine("List of available countires");
foreach (var c in countries)
{
    Console.WriteLine(c.Name.CountryCommonName);
}

employeeManagment.DisplayEmployees();

AddEmployee(employeeManagment,countries);
employeeManagment.DisplayEmployees();
FileServices.SaveToFile(employeeManagment.GetEmployees());

UpdateSalary(employeeManagment);
employeeManagment.DisplayEmployees();
FileServices.SaveToFile(employeeManagment.GetEmployees());

RemoveEmployee(employeeManagment);
employeeManagment.DisplayEmployees();
FileServices.SaveToFile(employeeManagment.GetEmployees());

static void AddEmployee(EmployeeManagment employeeManagment, List<Country> countries)
{
    Console.WriteLine("Enter employee name: ");
    string fullName = Console.ReadLine();
    Console.WriteLine("Enter employee salary: ");
    decimal salary = decimal.Parse(Console.ReadLine());
    Console.WriteLine("Choose employee country: ");
    int selectedCountry = int.Parse(Console.ReadLine());
    Country country = countries[selectedCountry];

    employeeManagment.AddEmployee(new Employee(fullName, country, salary));
}

static void RemoveEmployee(EmployeeManagment employeeManagment)
{
    Console.WriteLine("Enter employee name: ");
    string employeeName = Console.ReadLine();
    employeeManagment.RemoveEmployee(employeeName);
}

static void UpdateSalary(EmployeeManagment employeeManagment)
{
    Console.WriteLine("Enter employee name: ");
    string employeeName = Console.ReadLine();
    Console.WriteLine("Enter new salary: ");
    decimal newSalary = decimal.Parse(Console.ReadLine());
    employeeManagment.UpdateSalary(employeeName, newSalary);
}


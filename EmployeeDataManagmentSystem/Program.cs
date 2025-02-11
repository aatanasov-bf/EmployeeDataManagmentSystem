using EmployeeDataManagmentSystem;
using EmployeeDataManagmentSystem.Services;

CountryService countryService = new CountryService();
EmployeeManagment employeeManagment = new EmployeeManagment();
List<Country> countries = countryService.FetchCountryList();

int choice;
do
{
    Console.WriteLine("List of available options:\n" +
        "1. Add employee\n" +
        "2. Update employee salary\n" +
        "3. Assign department to an employee\n" +
        "4. Remove employee\n" +
        "5. Display all employees\n" +
        "6. Save employees to a file\n" +
        "7. Exit");
    Console.Write("Select an option: ");
    choice = int.Parse(Console.ReadLine());

    switch(choice)
    {
        case 1:
            AddEmployee(employeeManagment, countries);
            break;
            case 2: UpdateSalary(employeeManagment);
            break;
            case 3: AssignDepartment(employeeManagment);
            break;
        case 4: RemoveEmployee(employeeManagment);
            break;
        case 5: employeeManagment.DisplayEmployees();
            break;
        case 6: FileServices.SaveToFile(employeeManagment.GetEmployees());
            break;
        case 7:
            SaveAndExit(employeeManagment);
            break;
    }

} while (choice != 7);

static void AddEmployee(EmployeeManagment employeeManagment, List<Country> countries)
{
    Console.WriteLine("-Add an employee-");
    Console.Write("Enter employee name: ");
    string fullName = Console.ReadLine();

    Console.Write("Enter employee salary: ");
    decimal salary = decimal.Parse(Console.ReadLine());
    if(salary <= 0)
    {
        Console.WriteLine("Invalid salary input!");
        return;
    }

    Console.WriteLine("List of available countires");
    int index = 1;
    foreach (var c in countries)
    {
        Console.WriteLine($"{index}. {c.Name.CountryCommonName}");
        index++;
    }

    Console.Write("Choose employee country: ");
    int selectedCountry = int.Parse(Console.ReadLine());
    if (selectedCountry <= 0 || selectedCountry > countries.Count)
    {
        Console.WriteLine("Invalid country input!");
        return;
    }
    Country country = countries[selectedCountry-1];

    employeeManagment.AddEmployee(new Employee(fullName, country, salary));
}

static void RemoveEmployee(EmployeeManagment employeeManagment)
{
    Console.WriteLine("-Remove an employee-");
    Console.Write("Enter employee name: ");
    string employeeName = Console.ReadLine();
    employeeManagment.RemoveEmployee(employeeName);
}

static void UpdateSalary(EmployeeManagment employeeManagment)
{
    Console.WriteLine("-Update salary-");
    Console.Write("Enter employee name: ");
    string employeeName = Console.ReadLine();
    Console.Write("Enter new salary: ");
    decimal newSalary = decimal.Parse(Console.ReadLine());
    if (newSalary <= 0)
    {
        Console.WriteLine("Invalid salary input!");
        return;
    }
    employeeManagment.UpdateSalary(employeeName, newSalary);
}

static void AssignDepartment(EmployeeManagment employeeManagment)
{
    Console.WriteLine("-Assign department-");
    Console.Write("Enter employee name: ");
    string employeeName = Console.ReadLine();
    Console.Write("Enter department name: ");
    string departmentName = Console.ReadLine();
    employeeManagment.AssignDepartment(employeeName,departmentName);
}

static void SaveAndExit(EmployeeManagment employeeManagment)
{
    Console.Write("Do you want to save your changes before exit (y/n)?: ");
    string choice = Console.ReadLine();
    switch (choice)
    {
        case "y":
            {
                FileServices.SaveToFile(employeeManagment.GetEmployees());
                Console.WriteLine("Goodbye!");
                break;
            }
        case "n":
            {
                Console.WriteLine("Goodbye!");
                break;
            }
        default:
            {
                Console.WriteLine("Goodbye!");
                break;
            }
    }
}
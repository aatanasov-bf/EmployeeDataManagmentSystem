using Newtonsoft.Json;

namespace EmployeeDataManagmentSystem.Services
{
    public class FileServices
    {
        private const string employeeFilePath = "employees.json";

        public static void SaveToFile(List<Employee> employees)
        {
            string json = JsonConvert.SerializeObject(employees, Formatting.Indented);
            File.WriteAllText(employeeFilePath, json);
        }

        public static List<Employee> LoadFromFile(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                List<Employee> emplyees = JsonConvert.DeserializeObject<List<Employee>>(json);
                return emplyees;
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Employee>();
            }
        }
    }
}

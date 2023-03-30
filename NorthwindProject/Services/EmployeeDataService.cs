using NorthwindProject.Models;
using System.Data;

namespace NorthwindProject.Services
{
    public class EmployeeDataService
    {
        public EmployeeDataService() { }

        public async Task<List<Employee>> GetEmployees()
        {
            List<Employee> employees = new();

            using var conn = DbConnector.GetServiceConnection();
            using var cmd = conn?.CreateCommand();

            if (cmd != null)
            {
                cmd.CommandText = "SELECT EmployeeID, FirstName, LastName FROM Employees ORDER BY LastName, FirstName";

                using var sdr = cmd.ExecuteReader();
                if (!sdr.HasRows)
                    throw new Exception("No records found.");

                while (await sdr.ReadAsync())
                {
                    var employee = new Employee
                    {
                        EmployeeID = sdr.GetInt32(0),
                        FirstName = sdr.GetString(1),
                        LastName = sdr.GetString(2)
                    };

                    employees.Add(employee);
                }
            }

            return employees;
        }

        public async <Task<Employee>> GetEmployeeById(int id)
        {

        }
    }
}

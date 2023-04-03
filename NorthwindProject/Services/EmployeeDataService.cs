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

        public async Task<Employee> GetEmployeeById(int id)
        {
            Employee employee = null;

            using var conn = DbConnector.GetServiceConnection();
            using var cmd = conn?.CreateCommand();

            if (cmd != null)
            {

                cmd.CommandText = "SELECT EmployeeID, FirstName, LastName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Notes, ReportsTo FROM Employees WHERE EmployeeID = " + id;

                using var sdr = cmd.ExecuteReader();
                if (!sdr.HasRows)
                    throw new Exception("No records found.");

                while (await sdr.ReadAsync())
                {
                    employee = new Employee
                    {
                        EmployeeID = sdr.GetInt32(0),
                        FirstName = sdr.GetString(1),
                        LastName = sdr.GetString(2),
                        Title = !sdr.IsDBNull(3) ? sdr.GetString(3) : string.Empty,
                        TitleOfCourtesy = !sdr.IsDBNull(4) ? sdr.GetString(4) : string.Empty,
                        BirthDate = !sdr.IsDBNull(5) ? sdr.GetDateTime(5) : DateTime.Now,
                        HireDate = !sdr.IsDBNull(6) ? sdr.GetDateTime(6) : DateTime.Now,
                        Address = !sdr.IsDBNull(7) ? sdr.GetString(7) : string.Empty,
                        City = !sdr.IsDBNull(8) ? sdr.GetString(8) : string.Empty,
                        Region = !sdr.IsDBNull(9) ? sdr.GetString(9) : string.Empty,
                        PostalCode = !sdr.IsDBNull(10) ? sdr.GetString(10) : string.Empty,
                        Country = !sdr.IsDBNull(11) ? sdr.GetString(11) : string.Empty,
                        HomePhone = !sdr.IsDBNull(12) ? sdr.GetString(12) : string.Empty,
                        Extension = !sdr.IsDBNull(13) ? sdr.GetString(13) : string.Empty,
                        Notes = !sdr.IsDBNull(14) ? sdr.GetString(14) : string.Empty,
                        ReportsTo = !sdr.IsDBNull(15) ? sdr.GetInt32(15) : int.MinValue
                    };
                }
            }
            return employee;
        }
    }
}

using NorthwindProject.Models;

namespace NorthwindProject.Services
{
    public class EmployeeDataService
    {
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
                        Title = sdr.GetString(3),
                        TitleOfCourtesy = sdr.GetString(4),
                        BirthDate = sdr.GetDateTime(5),
                        HireDate = sdr.GetDateTime(6),
                        Address = sdr.GetString(7),
                        City = sdr.GetString(8),
                        Region = sdr.GetString(9),
                        PostalCode = sdr.GetString(10),
                        Country = sdr.GetString(11),
                        HomePhone = sdr.GetString(12),
                        Extension = sdr.GetString(13),
                        Notes = sdr.GetString(14),
                        ReportsTo = sdr.GetInt32(15)
                    };
                }
            }
            return employee;
        }
    }
}

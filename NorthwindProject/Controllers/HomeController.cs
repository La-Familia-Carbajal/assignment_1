using Microsoft.AspNetCore.Mvc;
using NorthwindProject.Models;
using NuGet.Protocol.Plugins;
using System.Data;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace NorthwindProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        #region Employees
        public async Task<IActionResult> Employees()
        {
            List<Employee> Employees = new List<Employee>();

            try
            {
                using var conn = DbConnector.GetServiceConnection();
                using var cmd = conn?.CreateCommand();

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
                    Employees.Add(employee);
                }
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
            }
            
            return View(Employees);        
        }

        public async Task<IActionResult> EmployeeInfo(int id)
        {
            Employee employee = null;

            try
            {
                using var conn = DbConnector.GetServiceConnection();
                using var cmd = conn?.CreateCommand();

                cmd.CommandText = "SELECT EmployeeID, FirstName, LastName, Title, TitleOfCourtesy, BirthDate, HireDate, Address, City, Region, PostalCode, Country, HomePhone, Extension, Notes, ReportsTo FROM Employees WHERE EmployeeID = " + id;

                using var sdr = cmd.ExecuteReader();
                if (!sdr.HasRows)
                    throw new Exception("No records found.");

                await sdr.ReadAsync();

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
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
            }

            return View(employee);
        }
        #endregion

        #region Customers
        public async Task<IActionResult> Customers()
        {
            List<Customers> Customers = new List<Customers>();

            try
            {
                using var conn = DbConnector.GetServiceConnection();
                using var cmd = conn?.CreateCommand();

                cmd.CommandText = "SELECT CustomerID, CompanyName, ContactName, ContactTitle FROM Customers";

                using var sdr = cmd.ExecuteReader();
                if (!sdr.HasRows)
                {
                    throw new Exception("No record found");
                }
                while(await sdr.ReadAsync())
                {
                    var customers = new Customers
                    {
                        CustomerID = sdr.GetString(0),
                        CompanyName = sdr.GetString(1),
                        ContactName = sdr.GetString(2),
                        ContactTitle = sdr.GetString(3)
                    };

                    Customers.Add(customers);
                }
            }

            catch(Exception exc)
            {
                _logger.LogError(exc.Message);
            }

            return View(Customers);
        }
        #endregion
        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Sophia(string id)
        {
            return View();
        }
    }
}
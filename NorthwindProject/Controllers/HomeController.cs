using Microsoft.AspNetCore.Mvc;
using NorthwindProject.Models;
using NuGet.Protocol.Plugins;
using System.Diagnostics;

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
            
            return View(Employees);        }

        public async Task<IActionResult> EmployeeInfo(int id)
        {
            Employee employee = null;

            try
            {
                using var conn = DbConnector.GetServiceConnection();
                using var cmd = conn?.CreateCommand();

                cmd.CommandText = "SELECT EmployeeID, FirstName, LastName FROM Employees WHERE EmployeeID = {id}";

                using var sdr = cmd.ExecuteReader();
                if(!sdr.HasRows)
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
                        HomePhone = sdr.GetInt32(12),
                        Extension = sdr.GetInt32(13),
                        Notes = sdr.GetString(14),
                        ReportsTo = sdr.GetInt32(15)
                    };
                }
            }
            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
            }

            return View(employee);
        }
        #endregion

        #region Customer Orders
        public async Task<IActionResult> CustomerOrders()
        {
            List<CustomerOrders> CustomerOrders = new List<CustomerOrders>();

            try
            {
                using var conn = DbConnector.GetServiceConnection();
                using var cmd = conn?.CreateCommand();

                cmd.CommandText = "SELECT CompanyName, ContactName, ContactTitle FROM Customers";

                using var sdr = cmd.ExecuteReader();
                if (!sdr.HasRows)
                {
                    throw new Exception("No record found");
                }
                while(await sdr.ReadAsync())
                {
                    var customerOrders = new CustomerOrders
                    {
                        CompanyName = sdr.GetString(0),
                        ContactName = sdr.GetString(1),
                        ContactTitle = sdr.GetString(2)
                    };

                    CustomerOrders.Add(customerOrders);
                }
            }

            catch(Exception exc)
            {
                _logger.LogError(exc.Message);
            }

            return View(CustomerOrders);
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
using Microsoft.AspNetCore.Mvc;
using NorthwindProject.Models;
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

        public async Task<IActionResult> Employees()
        {
            List<Employee> Employees = new List<Employee>();

            try
            {
                using var conn = DbConnector.GetServiceConnection();
                using var cmd = conn?.CreateCommand();

                cmd.CommandText = "SELECT FirstName, LastName FROM Employees";

                using var sdr = cmd.ExecuteReader();
                if (!sdr.HasRows)
                    throw new Exception("No records found.");

                while (await sdr.ReadAsync())
                {
                    var employee = new Employee
                    {
                        FirstName = sdr.GetString(0),
                        LastName = sdr.GetString(1)
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
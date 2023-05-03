using Microsoft.AspNetCore.Mvc;
using NorthwindProject.Models;
using NorthwindProject.Views.ViewModels;
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

        /*#region Employees
        public async Task<IActionResult> Employees()
        {
            List<Employee> Employees = new List<Employee>();
            
            return View(Employees);        
        }

        public async Task<IActionResult> EmployeeInfo(int id)
        {
            Employee employee = null;

            return View(employee);
        }
        #endregion*/

        #region Customers
        public async Task<IActionResult> Customers()
        {
            //creating an empty customer list
            List<Customer> Customers = new List<Customer>();

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
                while (await sdr.ReadAsync())
                {
                    //creating a new customer using the information taken from DB
                    var customers = new Customer
                    {
                        CustomerID = sdr.GetString(0),
                        CompanyName = sdr.GetString(1),
                        ContactName = sdr.GetString(2),
                        ContactTitle = sdr.GetString(3)
                    };

                    //Adding new customer to the Customers list
                    Customers.Add(customers);
                }
            }

            catch (Exception exc)
            {
                _logger.LogError(exc.Message);
            }

            return View(Customers);
        }

        //public async Task<IActionResult> CustomerOrders(string id)
        //{
        //    CustomerOrderData customerOrderData = new CustomerOrderData();

        //    try
        //    {
        //        using var conn = DbConnector.GetServiceConnection();
        //        using var cmd = conn?.CreateCommand();

        //        //getting the full customer information from the DB
        //        cmd.CommandText = "SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax FROM Customers WHERE CustomerID = " + $"'{id}'";

        //        using var sdr = cmd.ExecuteReader();

        //        if (!sdr.HasRows)
        //            throw new Exception("No records found.");

        //        await sdr.ReadAsync();

        //        //Creating a new customer
        //        Customer customerInfo = new Customer
        //        {
        //            CustomerID = sdr.GetString(0),
        //            CompanyName = sdr.GetString(1),
        //            ContactName = !sdr.IsDBNull(2) ? sdr.GetString(2) : string.Empty,
        //            ContactTitle = !sdr.IsDBNull(3) ? sdr.GetString(3) : string.Empty,
        //            Address = !sdr.IsDBNull(4) ? sdr.GetString(4) : string.Empty,
        //            City = !sdr.IsDBNull(5) ? sdr.GetString(5) : string.Empty,
        //            Region = !sdr.IsDBNull(6) ? sdr.GetString(6) : string.Empty,
        //            PostalCode = !sdr.IsDBNull(7) ? sdr.GetString(7) : string.Empty,
        //            Country = !sdr.IsDBNull(8) ? sdr.GetString(8) : string.Empty,
        //            Phone = !sdr.IsDBNull(9) ? sdr.GetString(9) : string.Empty,
        //            Fax = !sdr.IsDBNull(10) ? sdr.GetString(10) : string.Empty
        //        };

        //        customerOrderData.CustomerInfo = customerInfo;

        //        sdr.Close();

        //        //Creating a new, empty order list
        //        List<Order> orders = new List<Order>();

        //        //pulling all order info from the DB
        //        cmd.CommandText = "SELECT OrderID, CustomerID, EmployeeId, OrderDate, RequiredDate, ShippedDate, ShipVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, ShipCountry FROM Orders WHERE CustomerID  = " + $"'{id}'";

        //        using var sdrOrder = cmd.ExecuteReader();

        //        if (!sdrOrder.HasRows)
        //            throw new Exception("No records found.");


        //        while (await sdrOrder.ReadAsync())
        //        {
        //            //creating a new single order.  Looped to be able to grab all of the orders for the specified customer
        //            Order order = new Order
        //            {
        //                OrderID = sdrOrder.GetInt32(0),
        //                CustomerID = !sdrOrder.IsDBNull(1) ? sdrOrder.GetString(1) : string.Empty,
        //                EmployeeID = !sdrOrder.IsDBNull(2) ? sdrOrder.GetInt32(2) : -1,
        //                OrderDate = !sdrOrder.IsDBNull(3) ? sdrOrder.GetDateTime(3) : DateTime.Now
        //            };

        //            //adding each order obtained to the order list
        //            orders.Add(order);

        //        }

        //        customerOrderData.Order = orders;
        //    }
        //    catch (Exception exc)
        //    {
        //        _logger.LogError(exc.Message);
        //    }

        //    return View(customerOrderData);
        //}

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
using Microsoft.AspNetCore.Mvc;
using NorthwindProject.Models;
using NorthwindProject.Services;
using NorthwindProject.Views.ViewModels;

namespace NorthwindProject.Controllers
{
    public class CustomerController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<CustomerView> customers = new List<CustomerView>();

            try
            {
                var customerService = new CustomerDataService();

                var dataCustomers = await customerService.GetCustomers();

                foreach (var dataCustomer in dataCustomers)
                {
                    var viewCustomer = new CustomerView();
                    viewCustomer.CustomerID = dataCustomer.CustomerID;
                    viewCustomer.CompanyName = dataCustomer.CompanyName;
                    viewCustomer.ContactName = dataCustomer.ContactName;
                    viewCustomer.ContactTitle = dataCustomer.ContactTitle;

                    customers.Add(viewCustomer);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return View(customers);
        }
    }
}

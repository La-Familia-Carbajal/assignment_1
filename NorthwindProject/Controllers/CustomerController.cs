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

                var dataCustomers = await customerService.GetCustomerList();

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

        public async Task<IActionResult> CustomerOrders(string customerId)
        {
            Customer customer = new Customer();

            try
            {
                var customerService = new CustomerDataService();

                var customerData = await customerService.GetCustomerInfo(customerId);

                if(customerData != null)
                {
                    customer = new Customer
                    {
                        CustomerID = customerData.CustomerID,
                        CompanyName = customerData.CompanyName,
                        ContactName = customerData.ContactName,
                        ContactTitle = customerData.ContactTitle,
                        Address = customerData.Address,
                        City = customerData.City,
                        Region = customerData.Region,
                        PostalCode = customerData.PostalCode,
                        Country = customerData.Country,
                        Phone = customerData.Phone,
                        Fax = customerData.Fax
                    };
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return View(customer);
        }
    }
}

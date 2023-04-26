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

        public async Task<IActionResult> CustomerOrder(string id)
        {
            //Create a new Doc for Specific Customer
            CustomerOrderData customerOrders = new CustomerOrderData();

            //Call customer manager person
            var customerService = new CustomerDataService();

            //Grab the specific customer information from manager person
            var customerData = await customerService.GetCustomerOrder(id);

            //Take the specific customer information to the office and find specific information needed
            if(customerData != null)
            {
                CustomerView customerInfo = new CustomerView()
                {
                    CustomerID = customerData.CustomerInfo.CustomerID,
                    CompanyName = customerData.CustomerInfo.CompanyName,
                    ContactName = customerData.CustomerInfo.ContactName,
                    ContactTitle = customerData.CustomerInfo.ContactTitle,
                    Address = customerData.CustomerInfo.Address,
                    City = customerData.CustomerInfo.City,
                    Region = customerData.CustomerInfo.Region,
                    PostalCode = customerData.CustomerInfo.PostalCode,
                    Country = customerData.CustomerInfo.Country,
                    Phone = customerData.CustomerInfo.Phone,
                    Fax = customerData.CustomerInfo.Fax

                };
                //copy down the needed information
            }           

            //Give the final document to the front desk/view
            return View(customerOrders);
        }
    }
}

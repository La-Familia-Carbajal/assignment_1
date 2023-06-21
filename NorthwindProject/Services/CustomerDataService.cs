using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NorthwindProject.Models;
using NorthwindProject.Views.ViewModels;
using System.Data;

namespace NorthwindProject.Services
{
    public class CustomerDataService
    {
        public async Task<List<Customer>> GetCustomerList()
        {
            //creating an empty customer list
            List<Customer> Customers = new List<Customer>();

            using var conn = DbConnector.GetServiceConnection();
            using var cmd = conn?.CreateCommand();

            if (cmd != null)
            {
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
            return Customers;
        }

        public async Task<Customer> GetCustomerInfo(string customerId)
        {
            Customer customer = new();

            using var conn = DbConnector.GetServiceConnection();
            using var cmd = conn?.CreateCommand();

            if (cmd != null)
            {
                //getting the full customer information from the DB
                cmd.CommandText = "SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax FROM Customers WHERE CustomerID = " + $"'{customerId}'";

                using var sdr = cmd.ExecuteReader();

                if (!sdr.HasRows)
                {
                    throw new Exception("No records found.");
                }

                while (await sdr.ReadAsync())
                {
                   customer = new Customer
                    {
                       CustomerID = sdr.GetString(0),
                       CompanyName = sdr.GetString(1),
                       ContactName = sdr.GetString(2),
                       ContactTitle = sdr.GetString(3),
                       Address = sdr.GetString(4),
                       City = sdr.GetString(5),
                       Region = sdr.GetString(6),
                       PostalCode = sdr.GetString(7),
                       Country = sdr.GetString(8),
                       Phone = sdr.GetString(9),
                       Fax = sdr.GetString(10)
                   };
                }
            }
            return customer;
        }

        //public async Task<CustomerOrderData> GetCustomerOrders(string id)
        //{
        //    CustomerOrderData customerOrderData = new CustomerOrderData();

        //    using var conn = DbConnector.GetServiceConnection();
        //    using var cmd = conn?.CreateCommand();

        //    if (cmd != null)
        //    {
        //        //getting the full customer information from the DB
        //        cmd.CommandText = "SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax FROM Customers WHERE CustomerID = " + $"'{id}'";

        //        using var sdr = cmd.ExecuteReader();

        //        if (!sdr.HasRows)
        //        {
        //            throw new Exception("No records found.");
        //        }

        //        while (await sdr.ReadAsync())
        //        {
        //            Customer customerInfo = new Customer
        //            {
        //                CustomerID = sdr.GetString(0),
        //                CompanyName = sdr.GetString(1),
        //                ContactName = !sdr.IsDBNull(2) ? sdr.GetString(2) : string.Empty,
        //                ContactTitle = !sdr.IsDBNull(3) ? sdr.GetString(3) : string.Empty,
        //                Address = !sdr.IsDBNull(4) ? sdr.GetString(4) : string.Empty,
        //                City = !sdr.IsDBNull(5) ? sdr.GetString(5) : string.Empty,
        //                Region = !sdr.IsDBNull(6) ? sdr.GetString(6) : string.Empty,
        //                PostalCode = !sdr.IsDBNull(7) ? sdr.GetString(7) : string.Empty,
        //                Country = !sdr.IsDBNull(8) ? sdr.GetString(8) : string.Empty,
        //                Phone = !sdr.IsDBNull(9) ? sdr.GetString(9) : string.Empty,
        //                Fax = !sdr.IsDBNull(10) ? sdr.GetString(10) : string.Empty
        //            };

        //            customerOrderData.CustomerInfo = customerInfo;

        //            sdr.Close();
        //        }

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

        //    return customerOrderData;
        //}
    }
}





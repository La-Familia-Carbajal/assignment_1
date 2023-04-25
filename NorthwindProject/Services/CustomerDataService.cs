using NorthwindProject.Models;
using System.Data;

namespace NorthwindProject.Services
{
    public class CustomerDataService
    {
        public async Task<List<Customers>> GetCustomers()
        {
            //creating an empty customer list
            List<Customers> Customers = new List<Customers>();

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
                    var customers = new Customers
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

    }
}


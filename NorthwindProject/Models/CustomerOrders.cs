using System.ComponentModel;
using NorthwindProject.Models.ViewModels;

namespace NorthwindProject.Models
{
    public class CustomerOrders
    {
        public IEnumerable<CustomerOrders>? customerOrders;
        public CustomerInfo? customerInfo { get; set; }
    }
}

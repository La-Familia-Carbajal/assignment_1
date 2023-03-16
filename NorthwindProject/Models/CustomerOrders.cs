using System.ComponentModel;

namespace NorthwindProject.Models
{
    public class CustomerOrders
    {
        public IEnumerable<Order>? customerOrders;
        public Customers? customerInfo { get; set; }
    }
}

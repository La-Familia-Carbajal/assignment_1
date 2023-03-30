using NorthwindProject.Models;

namespace NorthwindProject.Views.ViewModels
{
    public class CustomerOrderData
    {
        public IEnumerable<Order>? Order { get; set; } = Enumerable.Empty<Order>();
        public Customers? CustomerInfo { get; set; } = new Customers();
    }
}

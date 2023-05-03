using NorthwindProject.Models;

namespace NorthwindProject.Views.ViewModels
{
    public class CustomerOrderData
    {
        public IEnumerable<OrderView>? Order { get; set; } = Enumerable.Empty<OrderView>();
        public CustomerView? CustomerInfo { get; set; } = new CustomerView();
    }
}

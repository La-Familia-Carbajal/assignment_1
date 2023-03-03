using System.ComponentModel;

namespace NorthwindProject.Models
{
    public class CustomerOrders
    {
        [DisplayName("Order ID")]
        public int OrderId { get; set; }
        [DisplayName("Customer ID")]
        public string ?CustomerId { get; set; }
        [DisplayName("Employee ID")]
        public int EmployeeId { get; set; }
        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set;}
        [DisplayName("Required Date")]
        public DateTime RequiredDate { get; set; }
        [DisplayName("Shipped Date")]
        public DateTime ShippedDate { get; set; }
        [DisplayName("Ship Via")]
        public int ShipVia { get; set; }
        [DisplayName("Freight Weight")]
        public float FreightWeight { get; set; }
        [DisplayName("Shipping Name")]
        public string ?ShipName { get; set; }
        [DisplayName("Shipping Address")]
        public string ?ShipAddress { get; set; }
        [DisplayName("Shipping City")]
        public string ?ShipCity { get; set; }
        [DisplayName("Shipping Region")]
        public string ?ShipRegion { get; set; }
        [DisplayName("Shipping Postal Code")]
        public string ?ShipPostalCode { get; set; }
        [DisplayName("Shipping Country")]
        public string ?ShipCountry { get; set; }
    }
}

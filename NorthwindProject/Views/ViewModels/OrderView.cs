namespace NorthwindProject.Views.ViewModels
{
    public class OrderView
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; } = string.Empty;
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int ShipVia { get; set; }
        public float Freight { get; set; }
        public string ShipName { get; set; } = string.Empty;
        public string ShipAddress { get; set; } = string.Empty;
        public string ShipCity { get; set; } = string.Empty;
        public string ShipPostalcode { get; set; } = string.Empty;
        public string ShipCountry { get; set; } = string.Empty;
    }
}

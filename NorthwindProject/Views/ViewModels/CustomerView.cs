using System.ComponentModel;

namespace NorthwindProject.Views.ViewModels
{
    public class CustomerView
    {
        public string CustomerID { get; set; } = string.Empty;
        [DisplayName("Company Name")]
        public string CompanyName { get; set; } = string.Empty;
        [DisplayName("Contact Name")]
        public string ContactName { get; set; } = string.Empty;
        [DisplayName("Title")]
        public string ContactTitle { get; set; } = string.Empty;
        [DisplayName("Company Address")]
        public string Address { get; set; } = string.Empty;
        [DisplayName("Company City")]
        public string City { get; set; } = string.Empty;
        [DisplayName("Company Region")]
        public string Region { get; set; } = string.Empty;
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; } = string.Empty;
        [DisplayName("Company Country")]
        public string Country { get; set; } = string.Empty;
        [DisplayName("Company Phone")]
        public string Phone { get; set; } = string.Empty;
        [DisplayName("Company Fax")]
        public string Fax { get; set; } = string.Empty;
    }
}

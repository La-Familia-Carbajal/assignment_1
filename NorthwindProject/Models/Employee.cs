using System.ComponentModel;

namespace NorthwindProject.Models
{
	public class Employee
	{
		[DisplayName("Employee ID")]
		public int EmployeeID { get; set; }  
		[DisplayName("First Name")]
		public string FirstName { get; set; } = string.Empty;
		[DisplayName("Last Name")]
		public string LastName { get; set; } = string.Empty;
        [DisplayName("Title")]
        public string Title { get; set; } = string.Empty;
        [DisplayName("Prefix")]
        public string TitleOfCourtesy { get; set; } = string.Empty;
        [DisplayName("Birth Date")]
        public DateTime BirthDate { get; set; }
        [DisplayName("Hire Date")]
        public DateTime HireDate { get; set; }
        [DisplayName("Street Address")]
        public string Address { get; set; } = string.Empty;
        [DisplayName("City")]
        public string City { get; set; } = string.Empty;
        [DisplayName("Region")]
        public string Region { get; set; } = string.Empty;
        [DisplayName("Postal Code")]
        public string PostalCode { get; set; } = string.Empty;
        [DisplayName("Country")]
        public string Country { get; set; } = string.Empty;
        [DisplayName("Home Phone")]
        public int HomePhone { get; set; }
        [DisplayName("Ext.")]
        public int Extension { get; set; }
        [DisplayName("Notes")]
        public string Notes { get; set; } = string.Empty;
        [DisplayName("Reports To")]
        public int ReportsTo { get; set; }
	}
}

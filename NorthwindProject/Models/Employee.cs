using System.ComponentModel;

namespace NorthwindProject.Models
{
	public class Employee
	{
		public int ID { get; set; } = -1;

		[DisplayName("First Name")]
		public string FirstName { get; set; } = string.Empty;
		[DisplayName("Last Name")]
		public string LastName { get; set; } = string.Empty;
    }
}

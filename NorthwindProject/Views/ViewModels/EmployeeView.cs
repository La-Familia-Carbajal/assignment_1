using System.ComponentModel;

namespace NorthwindProject.Views.ViewModels
{
    public class EmployeeView
    {
        public int EmployeeID { get; set; }

        [DisplayName("First Name")]
        public string FirstName { get; set; } = string.Empty;

        [DisplayName("Last Name")]
        public string LastName { get; set; } = string.Empty;
    }
}

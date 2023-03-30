using Microsoft.AspNetCore.Mvc;
using NorthwindProject.Models;
using NorthwindProject.Services;
using NorthwindProject.Views.ViewModels;

namespace NorthwindProject.Controllers
{
    public class EmployeeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            // create a box of EmployeeView records
            List<EmployeeView> employees = new List<EmployeeView>();

            // fill our box
            try
            {
                // call employee manager guy
                var employeeService = new EmployeeDataService(); 

                // ask for employees and data manager guy gives box of full employee data
                var dataEmployees = await employeeService.GetEmployees(); 

                // go back into the office and create box of proper EmployeeView records
                foreach (var dataEmployee in dataEmployees) // go through all records
                {
                    // create new record and copy data from Employee to EmployeeView
                    var viewEmployee = new EmployeeView();
                    viewEmployee.EmployeeID = dataEmployee.EmployeeID;
                    viewEmployee.FirstName = dataEmployee.FirstName;
                    viewEmployee.LastName = dataEmployee.LastName;

                    // place new record in box of EmployeeView records
                    employees.Add(viewEmployee);
                }
            }
            catch(Exception e) {
                Console.WriteLine(e);
            }

            // give box of EmployeeView records to front desk person
            return View(employees);
        }
    }
}

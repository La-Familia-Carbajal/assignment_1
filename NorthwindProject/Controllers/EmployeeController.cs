using Microsoft.AspNetCore.Mvc;
using NorthwindProject.Models;
using NorthwindProject.Services;
using NorthwindProject.Views.ViewModels;
using NuGet.Packaging.Signing;
using static Azure.Core.HttpHeader;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Net;
using System.Drawing.Imaging;

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
            catch(Exception e) 
            {
                Console.WriteLine(e);
            }

            // give box of EmployeeView records to front desk person
            return View(employees);
        }

        public async Task<IActionResult> EmployeeInfo(int employeeId)
        {
            //Create new, empty employee document
            EmployeeView employee = new EmployeeView();

            //fill out employee document
            try
            {
                //grab the box of employee information
                var employeeService = new EmployeeDataService();

                //dig in box find specific employee
                var employeeData = await employeeService.GetEmployeeById(employeeId);

                //copy all necessary information to document
                if (employeeData != null)
                {
                    employee = new EmployeeView
                    {
                        EmployeeID = employeeData.EmployeeID,
                        FirstName = employeeData.FirstName,
                        LastName = employeeData.LastName,
                        Title = employeeData.Title,
                        TitleOfCourtesy = employeeData.TitleOfCourtesy,
                        BirthDate = employeeData.BirthDate,
                        HireDate = employeeData.HireDate,
                        Address = employeeData.Address,
                        City = employeeData.City,
                        Region = employeeData.Region,
                        PostalCode = employeeData.PostalCode,
                        Country = employeeData.Country,
                        HomePhone = employeeData.HomePhone,
                        Extension = employeeData.Extension,
                        Notes = employeeData.Notes,
                        ReportsTo = employeeData.ReportsTo
                    };

                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            //place the single employee document in the box created previously
            return View(employee);

        }
    }
}

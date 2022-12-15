# Assignment #1

Create a simple website that retrieves and displays data from the Northwind database.

## Requirements:
- [ ] Include separate header, body, and footer sections that are all put together through one `_layout.aspx` file.
- [ ] Header should include navigation to two destinations, Employees and Customer Orders

### Employees functionality:
- [ ] Landing page should display a list of all employees sorted by last name, first name
- [ ] Each name should be a hyperlink to a sub page that displays that employee's full information in an organized manner laid out as you see fit

### Customer orders functionality:
- [ ] Landing page should display a list of customers sorted by company name while also displaying the contact name and title below the company name. For example:
```
Alfreds Futterkiste
Contact: Maria Anders, Sales Representative
```
- [ ] Each company name should be a hyperlink to a sub page that lists the full customer information along with a list of all orders that customer has placed.

### Things to keep in mind:
- Try to use the ASP.NET tags in your HTML to get used to how they work and what the different tag attributes do
- Be sure to use the `DataGrid` ASP.NET tag to display lists of items to learn how to bind data to a list
﻿using System.ComponentModel;

namespace NorthwindProject.Models
{
    public class Customers
    {
        public string CustomerID { get; set; } = string.Empty;
        [DisplayName("Company Name")]
        public string CompanyName { get; set; } = string.Empty;
        [DisplayName("Contact Name")]
        public string ContactName { get; set; } = string.Empty;
        [DisplayName("Title")]
        public string ContactTitle { get; set; } = string.Empty;

    }
}
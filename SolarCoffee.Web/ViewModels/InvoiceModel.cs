﻿using SolarCoffee.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace SolarCoffee.Web.ViewModels
{
    /// <summary>
    /// View model for open SalesOrder
    /// </summary>
    public class InvoiceModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdateOn { get; set; }
        public int CustomerId { get; set; }
        public List<SalesOrderItemModel>  LineItems { get; set; }
    }
    /// <summary>
    /// View model for SalesOrderItems
    /// </summary>
    public  class SalesOrderItemModel
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public ProductModel Product { get; set; }
    }
}

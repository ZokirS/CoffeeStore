﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SolarCoffee.Data.Models
{
   public class Customer
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public CustomerAddress PrimaryAddress { get; set; }
    }
}

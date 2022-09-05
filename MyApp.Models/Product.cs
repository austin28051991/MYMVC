using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }
        [ValidateNever]
        public Category category { get; set; } 
    }
}

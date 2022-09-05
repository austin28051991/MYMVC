using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MyApp.Models.ViewModels
{
    public class ProductVM
    {
        public Product product { get; set; }

        [ValidateNever]
        public IEnumerable<Product> products { get; set; }=new List<Product>();
        [ValidateNever]
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}

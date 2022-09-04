﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Models.ViewModels
{
    public class CategoryVM
    {
        public Category category { get; set; }=new Category();
        public IEnumerable<Category> categories { get; set; }=new List<Category>();
    }
}

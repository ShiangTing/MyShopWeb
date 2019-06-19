﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyShopWeb.Models;

namespace MyshopWebDataAccess.SQL
{
    public class DataContext :DbContext
    {
        public DataContext()
            : base("DefaultConnection")
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
    }
}

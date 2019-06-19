using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyShopWeb.Models
{
    public class ProductCategory
    {
        public ProductCategory(ICollection<Product> products)
        {
            Products = products;
        }

        public string Name { get; set; }
        public int Id { get; set; }
       
        //ForeignKey
        public virtual ICollection<Product> Products { get; set; }
    }
}
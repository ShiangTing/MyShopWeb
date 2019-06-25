using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MyShopWeb.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [DisplayName("價格")]
        public decimal Price { get; set; }
       
        public string Image { get; set; }

        [DisplayName("產品簡介")]
        public string Description { get; set; }

        public ProductCategory Category { get; set; }
        public int? CategoryId { get; set; }


    }
}
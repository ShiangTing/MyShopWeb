using CoreMode.ViewModels;
using MyShopWeb.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CoreMode.Model
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("產品名稱")]
        public string Name { get; set; }

        [Range(10,500000)]
        [Required]
        [DisplayName("價格")]
        public decimal Price { get; set; }
       
        public string Image { get; set; }

        [DisplayName("產品簡介")]
        public string Description { get; set; }

        [DisplayName("產品類型")]
        public ProductCategory Category { get; set; }

        [Required]
        public int? CategoryId { get; set; }

        public Product()
        {
            new CartItemViewModel();
        }
        public virtual ICollection<CartItemViewModel> CartItemViewModels { get; set; }





    }
}
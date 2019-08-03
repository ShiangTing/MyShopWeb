using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMode.ViewModels
{
    public class CartItemViewModel
    {
        public int Id { get; set; }
        [DisplayName("數量")]
        public int Quantity { get; set; }
        [DisplayName("產品名稱")]
        public string ProductName { get; set; }
        [DisplayName("價格")]
        public decimal Price { get; set; }
        public string Image { get; set; }
    }
}

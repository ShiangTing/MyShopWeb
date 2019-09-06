using CoreMode.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMode.ViewModels
{
   public  class InAndDeViewModel
    {
        public Product Products { get; set; }
        public CartItem CartItems { get; set; }
        public virtual ICollection<CartItem> CartItem { get; set; }

    }
}

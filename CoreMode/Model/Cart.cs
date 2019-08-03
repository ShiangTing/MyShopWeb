using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMode.Model
{
    public class Cart
    {
        public int Id { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }

        public Cart()
        {
            this.CartItems = new List<CartItem>();

        }
    }
}

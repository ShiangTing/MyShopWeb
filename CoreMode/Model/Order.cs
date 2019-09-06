using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMode.Model
{
    public class Order
    {
        public Order()
        {
            this.OrderDetails= new List<OrderDetails>();
        }


        public virtual ICollection<OrderDetails> OrderDetails{ get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Addrress { get; set; }

        public string Status { get; set; }

    }
}

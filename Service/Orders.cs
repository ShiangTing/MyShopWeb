using CoreMode.Model;
using CoreMode.ViewModels;
using MyshopWebDataAccess.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
   public  class Orders
    {
        private DataContext context;
        public Orders()
        {
            context = new DataContext();
        }
        public void CreateOrder(Order baseOrder, List<CartItemViewModel> cartItems)
        {
            foreach (var item in cartItems)
            {
                baseOrder.OrderDetails.Add(new OrderDetails()
                {
                    ProductId = item.Id,
                    Image = item.Image,
                    Price = item.Price,
                    ProductName = item.ProductName,
                    Quantity = item.Quantity

                });


            }
            context.Orders.Add(baseOrder);
            //context.Orders.
            context.SaveChanges();
        }

        public List<Order> GetOrderList()
        {
            return context.Orders.ToList();
        }

        public Order GetOrder(int Id)
        {
            return context.Orders.ToList().FirstOrDefault(o => o.Id == Id);

        }

        public void UpdateOrder(Order updatedOrder)
        {
            //context.Update(updatedOrder);
            context.SaveChanges();
        }
    }
}


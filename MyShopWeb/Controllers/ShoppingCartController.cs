using CoreMode.Model;
using MyShopWeb.Models;
using MyshopWebDataAccess.SQL;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShopWeb.Controllers
{
    public class ShoppingCartController : Controller
    {
        private DataContext context;

        public ShoppingCartController()
        {
            context = new DataContext();
        }
        // GET: ShoppingCart
        
        public ActionResult Index()
        {
            var cart = new Service.ShoppingCart();
            var model = cart.GetCartItems(this.HttpContext);
            return View(model);
        }


        //public ActionResult AddToCart(CartItem cartItem)
        //{
        //    var item = context.CartItems.FirstOrDefault(i => i.CartId == cartItem.Id);
        //    //將產品加入
        //    if (cartItem== null)
        //    {
        //        cartItem = new CartItem()
        //        {
        //            CartId = item.Id,
        //            ProductId = productId,
        //            Quantity = 1
        //        };
        //        else{

        //        }
        //    }
        //    return RedirectToAction("Index");
        //}

     
        public ActionResult AddToCart( int id, int quantity)
        {
            var cart = new Service.ShoppingCart();
            cart.AddtoCart(this.HttpContext, id, quantity);//Change

          //  return RedirectToAction("Index", "Home");
            return RedirectToAction("Details", "Home",new { Id=id});
            //return View("","Product");
        }


        [HttpPost]
        public ActionResult IncreaseOrDecreaseOne(ShoppingCart shoppingCart, int id, int quantity)
        {
            Product product = context.Products.ToList().FirstOrDefault(p=>p.Id==id);
            if (product != null)
            {
                shoppingCart.IncreaseOrDecreaseOne(product,quantity);
            }
            return Json(new
            {
                msg = true
            });
            //return RedirectToAction("CartIndex");
        }



        public ActionResult RemoveFromCart(int Id)
        {
            var cart = new Service.ShoppingCart();
            cart.RemoveFromCart(this.HttpContext, Id);

            return RedirectToAction("Index");
        }

        public PartialViewResult CartSummary()
        {
            var cart = new Service.ShoppingCart();
            var cartSummary = cart.GetCartSummary(this.HttpContext);

            return PartialView(cartSummary);
        }

        [Authorize]
        public ActionResult Checkout()
        { 
            
            var customer = context.Customers.ToList().FirstOrDefault(c => c.Name == User.Identity.Name);//Watch out

            if (customer != null)
            {
                Order order = new Order()
                {
                    Email = customer.Email,
                    Name = customer.Name,
                    Addrress = customer.Addrress

                };
          
                return View(order);
            }
            else
            {
                return RedirectToAction("Error");
            }

        }

        [HttpPost]
        [Authorize]
        public ActionResult Checkout(Order order)
        {
            var cart = new Service.ShoppingCart();
            var cartItems = cart.GetCartItems(this.HttpContext);
            order.Email = User.Identity.Name;

            var o = new Orders();
            o.CreateOrder(order, cartItems);

            cart.EmptyCart(this.HttpContext);

            return RedirectToAction("ThankYou", new { OrderId = order.Id });
        }

        [HttpGet]
        public ActionResult ThankYou(int OrderId)
        {
            //OrderDetails orderdetails = new OrderDetails() { };
            var Orders = new Order
            {
                OrderDetails = context.OrderDetails.ToList()
            };

            var o = new Service.Orders();
            var order = o.GetOrder(OrderId);
            ViewBag.OrderId = OrderId;
            return View(order);
        }

       
        public string Welcome(int quantity, int ID)
        {
            return HttpUtility.HtmlEncode("Hello " + quantity + ", ID: " + ID);
        }

    }
}
using CoreMode.Model;
using MyshopWebDataAccess.SQL;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;

namespace MyShopWeb.Controllers
{
    public class TestController : Controller
    {
        private DataContext context;

        public TestController()
        {
            context = new DataContext();
        }
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetCart()
        {

            var cart = new ShoppingCart();
            var carts = cart.GetCart(this.HttpContext);

           // var carts = Service.ShoppingCart.GetCart();
            if (carts.CartItems.Count == 0)
            {
                carts.CartItems.Add(
                    new CartItem()
                    {
                        Id = 1,
                        CartId =1,
                        Quantity=0,
                        
                    }
                    
                    );
            }
            else
            {
                carts.CartItems.First().Quantity += 1;
            }


            return Content(string.Format("目前產品數量{0}個",carts.CartItems.Count));
        }
    }
}
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
            var cart = new ShoppingCart();
            var model = cart.GetCartItems(this.HttpContext);
            return View(model);
        }

        public ActionResult AddToCart(int Id)
        {
            var cart = new ShoppingCart();
            cart.AddtoCart(this.HttpContext,Id);
            return RedirectToAction("Index","Home");
        }


        public ActionResult RemoveFromCart(int Id)
        {
            var cart = new ShoppingCart();
            cart.RemoveFromCart(this.HttpContext, Id);

            return RedirectToAction("Index");
        }

        public PartialViewResult CartSummary()
        {
            var cart = new ShoppingCart();
            var cartSummary = cart.GetCartSummary(this.HttpContext);

            return PartialView(cartSummary);
        }
    }
}
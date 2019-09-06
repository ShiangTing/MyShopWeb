using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoreMode.Model;
using CoreMode.ViewModels;
using Microsoft.Ajax.Utilities;
using MyShopWeb.Models;
using MyshopWebDataAccess.SQL;

namespace MyShopWeb.Controllers
{
    public class HomeController : Controller
    {
        private DataContext context;

        public HomeController()
        {
            context = new DataContext();
        }
        //Dispose
        public ActionResult Index()
        {
            List<Product> products=context.Products.ToList();
            List<ProductCategory> productCategories = context.ProductCategories.ToList();
            //new 一個product 物件
            ProductFormViewModel viewModel = new ProductFormViewModel
            {
                Products = products,
                ProductCategories = productCategories
            };
            
            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var productCategories = context.ProductCategories.ToList();
            var product = context.Products.ToList().SingleOrDefault(p=>p.Id==id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
              
                return View(product);
            }
            
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
     public ActionResult InandDeView(int id/*int quantity*/)
        {
            
            var product = context.Products.ToList().SingleOrDefault(p => p.Id == id);
            var cartItems = context.CartItems.ToList();
            //return view Model
            var viewModel = new InAndDeViewModel
            {

                Products = product,
                
                CartItems = new CartItem()
        };
            return PartialView(viewModel);
        //}
        //[HttpPost]
        //public ActionResult InandDeView(int quantity,int id)
        //{
        //    var product = context.Products.SingleOrDefault(p => p.Id == id);
        //    var cartItems = context.CartItems.SingleOrDefault(p => p.Id == id);
        //    var viewModel = new InAndDeViewModel()
        //    {
                  
                 
        //    CartItem = cartItems.Quantity

        //    };
        //    // Quantity = quantity (!)
        //    //quantity = carItems.Quantity
        //    return RedirectToAction("InandDeView",viewModel);

        }
    }
}
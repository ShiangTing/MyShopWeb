using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
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
            return View();
        }

        public ActionResult Details(int id)
        {
            var product = context.Products.SingleOrDefault(p => p.Id == id);
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
     

    }
}
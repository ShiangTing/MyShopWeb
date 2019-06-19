using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyShopWeb.Models;

namespace MyShopWeb.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            
            return View();
        }
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult New()
        {
            return View();
        }
    }
}
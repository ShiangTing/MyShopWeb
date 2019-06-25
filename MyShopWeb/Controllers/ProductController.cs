using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoreMode.ViewModels;
using MyShopWeb.Models;
using MyshopWebDataAccess.SQL;

namespace MyShopWeb.Controllers
{
    public class ProductController : Controller
    {
        private DataContext context;

        public ProductController()
        {
            context = new DataContext();
        }
        protected override void Dispose(bool disposing)
        {
            context.Dispose();
        }

        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Details(int id)
        //{
            
        //    return View();
        //}
        public ActionResult Edit(int id)
        {
            var product = context.Products.SingleOrDefault(p=>p.Id==id);
            if (product == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new ProductFormViewModel
                {
                    Product = new Product(),
                    ProductCategories = context.ProductCategories.ToList()

                };
                return View(viewModel);
            }
            
        }
        // [HttpPost]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Product product)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ProductFormViewModel
                {
                    Product = product,
                    ProductCategories = context.ProductCategories.ToList()
                };

                return View("Create", viewModel);
            }

            if (product.Id == 0)
                context.Products.Add(product);
            else
            {
                var productInDb = context.Products.Single(c => c.Id == product.Id);
                productInDb.Name = product.Name;
                productInDb.Price = product.Price;
                productInDb.Description = product.Description;
                productInDb.Image= product.Image;
            }

            context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        public ActionResult Create()
        {
            var productcategory = new List<ProductCategory>();

            var viewModel = new ProductFormViewModel
            {
                Product = new Product(),
                ProductCategories = productcategory.ToList()

            };
            context.SaveChanges();
            return View(viewModel);
        }

        public ActionResult Delete()
        {
            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CoreMode.Model;
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

            var product = context.Products.Include(p => p.Category).ToList();
          
            //如果是Ajax請求就返回部分網頁
       
            //如果不是Ajax則顯示完整頁面
            if(User.IsInRole("CanManageProduct"))

            return View(product);

            else {
                return View("ReadOnlyList", product);
                    }

        }


        //public ActionResult Search(string id)
        //{
        //    var products = from p in context.Products
        //                   select p;

        //    if (!String.IsNullOrEmpty(id))
        //    {
        //        products = products.Where(s => s.Name.Contains(id) || s.Name.Contains(id));
        //    }
        //    return View(products);
        //}
        //public ActionResult Details(int id)
        //{

        //    return View();
        //}

        //選擇DPList的id
        [HttpGet]
        public ActionResult CategoryMenu(int cateId)
        {


            var cateMenu = context.Products.Include(p => p.Category);//.Where(p => p.Category.ParentId==cateId || p.Category.Id==cateId).ToList();
          //要return view model較佳
          if (cateMenu == null)
            {
                return HttpNotFound();
            }
            else
            {
                var viewModel = new ProductFormViewModel
                {
                   Products = context.Products.Include(p => p.Category).ToList(),
                   ProductCategories = context.ProductCategories.Where(p => p.Id == cateId || p.ParentId == cateId).ToList()
                };
                return View("ProductPage",viewModel);

            }
            //var d = from c in Product select c.CategoryId == 1; //從資料庫選出資料 選出 特定category的資料


        }
    



        [Authorize(Roles = "CanManageProduct")]
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
                    
                    Product = product,
                    ProductCategories = context.ProductCategories.ToList()

                };
                return View("Create",viewModel);
            }
            
        }
        // [HttpPost]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Product product, HttpPostedFileBase Uploadfile)
        {
            foreach (var modelStateValue in ViewData.ModelState.Values)
            {
                foreach (var error in modelStateValue.Errors)
                {
                    // Do something useful with these properties
                    var errorMessage = error.ErrorMessage;
                    var exception = error.Exception;
                }
            }

            if (!ModelState.IsValid)
            {
                var viewModel = new ProductFormViewModel
                {
                    Product = product,
                    ProductCategories = context.ProductCategories.ToList()
                };

                return RedirectToAction("Index", "Home");
            }



            if (Uploadfile!=null)
            {

                //var fileName = Path.GetFileName(Uploadfile.FileName);
                //var path = Path.Combine(Server.MapPath("~/Content/ProductImage/"), fileName);
                //Uploadfile.SaveAs(path);

                product.Image = product.Id + Path.GetExtension(Uploadfile.FileName);
                Uploadfile.SaveAs(Server.MapPath("//Content//ProductImage//") + product.Image);
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
                productInDb.CategoryId = product.CategoryId;
            }

            context.SaveChanges();

            return RedirectToAction("Index", "Product");
        }

        [Authorize(Roles ="CanManageProduct")]
        public ActionResult Create()
        {
           
            var producategory  =context.ProductCategories.ToList();


            var viewModel = new ProductFormViewModel
            {
                Product = new Product(),
               // ProductCategories = productcategory.ToList()
               ProductCategories = producategory

            };
            context.SaveChanges();
            return View(viewModel);
        }


        [Authorize(Roles = "CanManageProduct")]
        [ActionName("Delete")]
        [HttpPost]
        public ActionResult ConfirmDelete(int id)
        {
            Product productToDelete = context.Products.SingleOrDefault(p => p.Id == id);
          //  var product = context.Products.SingleOrDefault(p => p.Id == id);
            if (productToDelete == null)
            {
                return HttpNotFound();
            }
            else
            {
                context.Products.Remove(productToDelete);
                context.SaveChanges();
                return RedirectToAction("Index");
            }


        }


    }
}
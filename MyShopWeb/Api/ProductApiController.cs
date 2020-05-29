using System;
using System.Collections.Generic;
using System.IO;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CoreMode.Model;
using MyShopWeb.Models;
using MyshopWebDataAccess.SQL;
using System.Diagnostics;

namespace MyShopWeb.Api
{
    public class ProductApiController : ApiController
    {



        private DataContext context;

        public ProductApiController()
        {
            context = new DataContext();
        }
        //GET/api/ProductApi
        //巡覽所有product
        public IHttpActionResult GetProducts(string query=null)
        {
          

            var productsQuery = context.Products.Include(p => p.Category);
            if (!String.IsNullOrWhiteSpace(query))
                productsQuery = productsQuery.Where(c => c.Name.Contains(query));

            var getProducts = productsQuery.ToList();
            return Ok(getProducts);
        }

        //GET/api/ProductApi/[para]
        //指定取得某個產品
        public IHttpActionResult GetProduct(int id)
        {
            var product = context.Products.SingleOrDefault(p => p.Id == id);
            if (product == null)
            {
                return  NotFound();

            }

            return Ok(product);

        }
        //選擇DPList的id
        public IHttpActionResult SelectId(int cateId)
        {
            var selectProduct = context.Products.SingleOrDefault(p => p.CategoryId == cateId);
            if (selectProduct == null)
            {
                return NotFound();
            }
            return Ok(selectProduct);
        }

        [Route("api/productapi/GetCategory/{cateId}")]
        [HttpGet, HttpPost]
        public IHttpActionResult GetCategory(int cateId)
        {
            //[FromUri]ProductCategory productCategory
       
            

            var getCategory = context.Products.Include(p => p.Category).Where(p => p.CategoryId == cateId || p.Category.ParentId ==cateId).ToList();
            if(getCategory== null)
            {
                return NotFound();
            }
            return Ok(getCategory);

        }

        //public ProductCategory Test(ProductCategory testCate)
        //{
        //    var gate = context.Products.Include(p => p.Category).Where(p => p.Category.SubCategories == testCate.SubCategories).ToList();
        //    return ();

        //}


        //public Product GetProductabc(int id)
        //{
        //    var product = context.Products.SingleOrDefault(p => p.Id == id);
        //    //if (product == null)
        //    //{
        //    //    throw new HttpResponseException(HttpStatusCode.NotFound);

        //    //}
        //    Product apple = new Product
        //    {
        //        Id = 2,
        //        Name = "apple",
        //        Price = 120,
        //        Image = "abc.jpg",
        //        Description = "aaa",
        //        CategoryId = 6



        //    };
        //    return apple;

        //}

        //POST/api/Product
        [HttpPost]
        public Product CreateProduct(Product product, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            

            context.Products.Add(product);
            context.SaveChanges();
            return product;
        }

        //Put/api/Product
        [HttpPut]
        public void EditProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var productInDb = context.Products.SingleOrDefault(p => p.Id == id);
            if (productInDb==null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            productInDb.Name = product.Name;
            productInDb.Description = product.Description;
            productInDb.Image = product.Image;
            productInDb.Price = product.Price;
            productInDb.CategoryId = product.CategoryId;
            context.SaveChanges();

        }

        //DELETE/api/Product

        [HttpDelete]
        public void DeleteProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var productInDb = context.Products.SingleOrDefault(p => p.Id == id);
            if (productInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            context.Products.Remove(productInDb);
            context.SaveChanges();

        }





    }
}

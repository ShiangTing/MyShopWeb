using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CoreMode.Model;
using MyShopWeb.Models;
using MyshopWebDataAccess.SQL;



namespace MyShopWeb.Api
{
    public class ProductApiController : ApiController
    {
        private DataContext context;

        public ProductApiController()
        {
            context = new DataContext();
        }
        //GET/api/Product
        public IEnumerable<Product> GetProducts()
        {
            return context.Products.ToList();
        }

        //GET/api/Product/1
      
        public Product GetProduct(int id)
        {
            var product = context.Products.SingleOrDefault(p => p.Id == id);
            if (product == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);

            }

            return product;
        }

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

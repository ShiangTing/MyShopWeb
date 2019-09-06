using CoreMode.Model;
using CoreMode.ViewModels;
using MyShopWeb.Models;
using MyshopWebDataAccess.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services;


namespace Service
{
    public class ShoppingCart
    {
        private DataContext context;
        public ShoppingCart()
        {
           context = new DataContext();
        }

        public const string CartSessionKey = "Cart";
        string ShoppingCartId { get; set; }

        [WebMethod(EnableSession = true)]
        public Cart GetCart(HttpContextBase httpContext)
        {

            //先找現在是否有Session
            var session = httpContext.Session;
            
            if (session != null)
            {
                Cart cart = new Cart();
                //var cartSessionName = httpContext.Session.ToString();
                //if (!string.IsNullOrWhiteSpace(cartSessionName))
                //{


                //}
                if (httpContext.Session[CartSessionKey] == null)
                {

                    httpContext.Session[CartSessionKey] = cart;
                }
                return (Cart)httpContext.Session[CartSessionKey];
            }

            else
            {
                throw new InvalidOperationException("Session 為空,請檢查");
            }

        }
            public string GetCartId(HttpContextBase context)
        {
            if (context.Session[CartSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CartSessionKey] =
                        context.User.Identity.Name;
                }
                else
                {
                    // Generate a new random GUID using System.Guid class
                    Guid tempCartId = Guid.NewGuid();
                    // Send tempCartId back to client as a cookie
                    context.Session[CartSessionKey] = tempCartId.ToString();
                }
            }
            return context.Session[CartSessionKey].ToString();
        }

        //[HttpPost]
        public void AddtoCart(HttpContextBase httpContext, int productId, int quantity) //quantity
        {
            Cart cart = GetCart(httpContext);
            CartItem item = cart.CartItems.SingleOrDefault(p => p.ProductId == productId);
            if (item ==null)
            {
                // Create a new cart item if no cart item exists

                item = new CartItem()
                {
                    CartId = cart.Id,
                    ProductId = productId,
                    Quantity = quantity
                };
                cart.CartItems.Add(item);
            }
            else
            {
                cart.CartItems.First().Quantity += 1;
            }
            context.SaveChanges();

        }
        //public void IncreaseOrDecreaseOne(int productId, HttpContextBase httpContext,int quantity)
        //{
        //    Cart cart = GetCart(httpContext);
        //    CartItem item = cart.CartItems.SingleOrDefault(p => p.ProductId == productId);
        //    if (item == null)
        //    {
        //        item.Quantity = quantity;
        //    }
        //}

        public void IncreaseOrDecreaseOne(Product product, int quantity)
        {
            CartItem item = context.CartItems.ToList().FirstOrDefault(p => p.ProductId == product.Id);
           // CartLine line = lineCollection.Where(p => p.Product.Id == product.Id).FirstOrDefault();
            if (item != null)
            {
                item.Quantity = quantity;
            }
        }

        public void RemoveFromCart(HttpContextBase httpContext, int itemId)
        {
            Cart cart = GetCart(httpContext);
            CartItem item = cart.CartItems.FirstOrDefault(p => p.Id == itemId);

            if (item != null)
            {
                if (item.Quantity > 1)
                {
                    item.Quantity = item.Quantity - 1;
                }
                else
                {
                    cart.CartItems.Remove(item);
                }
                context.SaveChanges();
            }
        }

        public void EmptyCart(HttpContextBase httpContext)
        {
            Cart cart = GetCart(httpContext);
            cart.CartItems.Clear();
            context.SaveChanges();


        }


        public List<CartItemViewModel> GetCartItems(HttpContextBase httpContext)
        {
            Cart cart = GetCart(httpContext);
            if (cart != null)
            {
                var results = (from b in cart.CartItems
                               join p in context.Products.ToList() on b.ProductId equals p.Id
                               select new CartItemViewModel()
                               {
                                   Id = b.Id,
                                   Quantity = b.Quantity,
                                   ProductName = p.Name,
                                   Image = p.Image,
                                   Price = p.Price
                               }
                              ).ToList();

                return results;
            }
            else
            {
                return new List<CartItemViewModel>();
            }

        }

        public CartSummaryViewModel GetCartSummary(HttpContextBase httpContext)
        {
            Cart cart = GetCart(httpContext);
            CartSummaryViewModel model = new CartSummaryViewModel(0, 0);
            if (cart != null)
            {
                int? basketCount = (from item in cart.CartItems
                                    select item.Quantity).Sum();

                decimal? basketTotal = (from item in cart.CartItems
                                        join p in context.Products.ToList() on item.ProductId equals p.Id
                                        select item.Quantity * p.Price).Sum();

                model.BasketCount = basketCount ?? 0;
                model.BasketTotal = basketTotal ?? decimal.Zero;

                return model;
            }
            else
            {
                return model;
            }
        }

        

    }
}

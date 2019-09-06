using CoreMode.Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyShopWeb.Controllers
{

    public class OrderManageController : Controller
    {
        // GET: OrderManage
        public ActionResult Index()
        {
            var order = new Orders();
            List<Order> orders = order.GetOrderList();

            return View(orders);
        }

        public ActionResult OrderList(int Id)
        {
          var   order = new Orders();
            ViewBag.StatusList = new List<string>() {
                "訂單建立",
                "付款中",
                "Order Shipped",
                "訂單完成"
            };
            Order orders = order.GetOrder(Id);
            return View(orders);
        }

        [HttpPost]
        public ActionResult UpdateOrder(Order updatedOrder, int Id)
        {
            var o = new Orders();
            Order order = o.GetOrder(Id);

            order.Status = updatedOrder.Status;
            o.UpdateOrder(order);

            return RedirectToAction("Index");
        }
    }
}
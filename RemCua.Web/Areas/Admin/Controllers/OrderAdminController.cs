using RemCua.Entities.Models;
using RemCua.Service;
using RemCua.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RemCua.Web.Areas.Admin.Controllers
{
    public class OrderAdminController : Controller
    {
        private IOrderService _orderService;
        public OrderAdminController(IOrderService orderService)
        {
            this._orderService = orderService;
        }
        ShopRemCuaEntity _db = new ShopRemCuaEntity();
        // GET: Admin/OrderAdmin
        public ActionResult ViewOrder()
        {
            var lst = new OrderModel();
            var viewModel = from o in _db.Orders
                            join o2 in _db.OrderDetails on o.ID equals o2.OrderID
                            join o3 in _db.Products on o2.ProductID equals o3.ID
                            where o.ID.Equals(o2.OrderID) && o.Status == false
                            select new OrderModel { Order = o, OrderDetail = o2, Product = o3 };
            var list = _db.Orders.ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult TotalPrice(int id)
        {
            var list = _db.OrderDetails.Where(x => x.OrderID == id);
            decimal total = 0;
            foreach (var item in list)
            {
                total += (decimal)item.Price;
            }
            string result = String.Format("{0:N0}", total).Replace(",", ".") + " VNĐ";
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail(int id)
        {
            var lst = new OrderModel();
            var viewModel = from o in _db.Orders
                            join o2 in _db.OrderDetails on o.ID equals o2.OrderID
                            join o3 in _db.Products on o2.ProductID equals o3.ID
                            where o.ID.Equals(o2.OrderID) && o.ID == id
                            select new OrderModel { Order = o, OrderDetail = o2, Product = o3 };
            foreach (var item in viewModel)
            {
                ViewBag.ShipName = item.Order.CustomerName;
                ViewBag.ShipMobile = item.Order.CustomerMobile;
                ViewBag.ShipAddress = item.Order.CustomerAddress;
                ViewBag.ShipEmail = item.Order.CustomerEmail;
            }

            return View(viewModel);
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var result = _orderService.ChangeStatus(id);
            _orderService.SaveChanges();
            return Json(new
            {
                Status = result
            });
        }
    }
}
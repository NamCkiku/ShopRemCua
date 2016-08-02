using RemCua.Common;
using RemCua.Entities.Models;
using RemCua.Service;
using RemCua.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RemCua.Web.Controllers
{
    public class PaymentController : Controller
    {
        private IOrderDetailService _orderDetailService;
        private IOrderService _orderService;
        public PaymentController(IOrderService orderService, IOrderDetailService orderDetailService)
        {
            this._orderService = orderService;
            this._orderDetailService = orderDetailService;
        }
        // GET: Payment
        public PartialViewResult Payment()
        {
            return PartialView();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateInput(false)]
        public ActionResult Payment(Order order)
        {
            order.CreatedDate = DateTime.Now;
            try
            {
                if (ModelState.IsValid)
                {
                    var orderID = _orderService.Add(order);
                    _orderService.SaveChanges();
                    decimal total = 0;
                    var cart = (List<ShoppingCart>)Session[CommonConstants.CartSession];
                    foreach (var item in cart)
                    {
                        var oderDetail = new OrderDetail();
                        oderDetail.ProductID = item.Product.ID;
                        oderDetail.OrderID = orderID.ID;
                        oderDetail.Price = item.Product.Price;
                        oderDetail.Quantity = item.Quantity;
                        _orderDetailService.Add(oderDetail);
                        _orderDetailService.SaveChanges();
                        total += (item.Product.Price * item.Quantity);
                    }
                    string content = System.IO.File.ReadAllText(Server.MapPath("~/Content/Client/template/newOrder.html"));
                    content = content.Replace("{{CustomerName}}", order.CustomerName);
                    content = content.Replace("{{Phone}}", order.CustomerMobile);
                    content = content.Replace("{{Email}}", order.CustomerEmail);
                    content = content.Replace("{{Address}}", order.CustomerAddress);
                    content = content.Replace("{{Total}}", total.ToString("N0"));
                    var toEmail = ConfigurationManager.AppSettings["ToEmailAddress"].ToString();
                    MailHelper.SendMail(order.CustomerEmail, "Đơn hàng mới từ Shop Rèm Cửa", content);
                    MailHelper.SendMail(toEmail, "Đơn hàng mới từ Shop Rèm Cửa", content);
                    return Redirect("/hoan-thanh");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View(order);
        }
        public ActionResult Success()
        {
            return View();
        }
        private void SendMail()
        {

        }
    }
}
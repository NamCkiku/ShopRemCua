using RemCua.Common;
using RemCua.Service;
using RemCua.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace RemCua.Web.Controllers
{
    public class CartController : Controller
    {
        private IProductService _productService;
        public CartController(IProductService productService)
        {
            this._productService = productService;
        }
        // GET: Cart
        public ActionResult Cart()
        {
            var cart = Session[CommonConstants.CartSession];//Gọi Session
            var list = new List<ShoppingCart>();//List CartItem
            if (cart != null)
            {
                list = (List<ShoppingCart>)cart;//Gán Session vào List CartItem
            }
            return View(list);
        }

        [HttpPost]
        public ActionResult AddCart(int productID, int quantity)
        {
            var product = _productService.GetById(productID);//Lấy ra Product Theo ID
            var cart = Session[CommonConstants.CartSession];//Khởi Tạo biến Session
            if (cart != null)//Nếu Chưa có Product nào
            {

                var list = (List<ShoppingCart>)cart;//Gán Session vào List CartItem
                if (list.Exists(x => x.Product.ID == productID))//Nếu có chưa ProductID
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ID == productID)
                        {
                            item.Quantity += quantity;//Số Lượng Cộng Thêm
                        }
                    }
                }
                else
                {
                    //tạo mới đối tượng cart Item
                    var item = new ShoppingCart();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                //Gán vào session
                Session[CommonConstants.CartSession] = list;
            }
            else
            {
                //tạo mới đối tượng cart Item
                var item = new ShoppingCart();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<ShoppingCart>();
                list.Add(item);
                //Gán vào session
                Session[CommonConstants.CartSession] = list;
            }
            return RedirectToAction("Cart");
        }
        [HttpPost]
        public JsonResult UpdateCart(string dataUpdate)
        {
            var product = new JavaScriptSerializer().Deserialize<List<ShoppingCart>>(dataUpdate);
            var cart = (List<ShoppingCart>)Session[CommonConstants.CartSession];
            foreach (var item in cart)
            {
                var itemCart = product.SingleOrDefault(x => x.Product.ID == item.Product.ID);
                if (itemCart != null)
                {
                    item.Quantity = itemCart.Quantity;
                }
            }
            Session[CommonConstants.CartSession] = cart;
            return Json(new
            {
                status = true
            });
        }
        [HttpPost]
        public JsonResult RemoveAt(int id)
        {
            var cart = (List<ShoppingCart>)Session[CommonConstants.CartSession];
            cart.RemoveAll(x => x.Product.ID == id);
            Session[CommonConstants.CartSession] = cart;
            return Json(new
            {
                status = true
            });
        }
        [HttpPost]
        public JsonResult DeleteAll()
        {
            Session[CommonConstants.CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public ActionResult Checkout()
        {
            if (Session[CommonConstants.CartSession] == null)
            {
                return RedirectToRoute("Cart");
            }
            else
            {
                return View();
            }
        }
    }
}
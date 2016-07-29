using RemCua.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RemCua.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        public HomeController(IProductService productService)
        {
            this._productService = productService;
        }
        public ActionResult Index()
        {
            ViewBag.NewProduct = _productService.ListNewProduct(4);//Hiển Thị theo ViewBag
            ViewBag.Feature = _productService.ListFeatureProduct(6);
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
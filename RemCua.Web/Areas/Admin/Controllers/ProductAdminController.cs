using RemCua.Entities.Models;
using RemCua.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RemCua.Web.Areas.Admin.Controllers
{
    public class ProductAdminController : Controller
    {
        private IProductService _productService;
        private IProductCategoryService _productCategoryService;
        public ProductAdminController(IProductService productService, IProductCategoryService productCategoryService)
        {
            this._productService = productService;
            this._productCategoryService = productCategoryService;
        }

        [HttpGet]
        public ActionResult ViewProduct()
        {
            var list = _productService.GetAll();
            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Product product)
        {
            return View();
        }
    }
}
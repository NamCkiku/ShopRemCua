using RemCua.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RemCua.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;
        private IProductCategoryService _productCategoryService;
        public ProductController(IProductService productService, IProductCategoryService productCategoryService)
        {
            this._productService = productService;
            this._productCategoryService = productCategoryService;
        }
        // GET: Product
        public ActionResult Detail(int id)
        {
            ViewBag.ReatedProduct = _productService.GetReatedProduct(id,4);//Hiển Thị theo ViewBag
            ViewBag.Feature = _productService.ListFeatureProduct(10);
            var model = _productService.GetById(id);
            return View(model);
        }
    }
}
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
        private readonly IProductCategoryService _productCategoryService;
        private readonly IPostService _postService;
        public HomeController(IProductService productService, IProductCategoryService productCategoryService, IPostService postService)
        {
            this._productService = productService;
            this._productCategoryService = productCategoryService;
            this._postService = postService;
        }
        public ActionResult Index()
        {
            ViewBag.NewProduct = _productService.ListNewProduct(4);//Hiển Thị theo ViewBag
            ViewBag.Feature = _productService.ListFeatureProduct(6);
            ViewBag.Category = _productCategoryService.GetProductByCategory(5);
            ViewBag.NewPost = _postService.GetNewPost(6);
            return View();
        }
    }
}
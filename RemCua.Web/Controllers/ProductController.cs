using RemCua.Common;
using RemCua.Entities.Models;
using RemCua.Service;
using RemCua.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RemCua.Web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IProductCategoryService _productCategoryService;
        private readonly IPostService _postService;
        public ProductController(IProductService productService, IProductCategoryService productCategoryService, IPostService postService)
        {
            this._productService = productService;
            this._productCategoryService = productCategoryService;
            this._postService = postService;
        }
        // GET: Product
        public ActionResult Detail(int id)
        {
            ViewBag.ReatedProduct = _productService.GetReatedProduct(id, 4);//Hiển Thị theo ViewBag
            ViewBag.Feature = _productService.ListFeatureProduct(10);
            var model = _productService.GetById(id);
            return View(model);
        }
        public ActionResult Category(int id, int page = 1)
        {
            int pageSize = 16;
            int totalRow = 0;
            var productModel = _productService.GetListProductByCategoryIdPaging(id, page, pageSize, out totalRow);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            var paginationSet = new PaginationSet<Product>()
            {
                Items = productModel,
                Page = page,
                MaxPage=5,
                TotalCount = totalRow,
                TotalPages = totalPage
            };
            ViewBag.Category = _productCategoryService.GetById(id);
            ViewBag.NewPost = _postService.GetNewPost(6);
            ViewBag.Feature = _productService.ListFeatureProduct(10);
            return View(paginationSet);
        }
    }
}
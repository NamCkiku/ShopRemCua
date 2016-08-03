using RemCua.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RemCua.Web.Controllers
{
    public class PageController : Controller
    {
        private readonly IPageService _pageService;
        private readonly IProductService _productService;
        private readonly IPostService _postService;
        public PageController(IPageService pageService, IProductService productService, IPostService postService)
        {
            this._pageService = pageService;
            this._productService = productService;
            this._postService = postService;
        }
        // GET: Page
        public ActionResult Page(string alias)
        {
            ViewBag.Feature = _productService.ListFeatureProduct(6);
            ViewBag.NewPost = _postService.GetNewPost(6);
            var page = _pageService.GetByAlias(alias);
            return View(page);
        }
    }
}
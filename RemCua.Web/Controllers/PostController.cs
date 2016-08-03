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
    public class PostController : Controller
    {
        private readonly IProductService _productService;
        private readonly IPostService _postService;
        public PostController(IPostService postService, IProductService productService)
        {
            this._postService = postService;
            this._productService = productService;
        }
        // GET: Post
        public ActionResult Post(int page = 1)
        {
            int pageSize = 10;
            int totalRow = 0;
            var postModel = _postService.GetListPosyPaging(page, pageSize, out totalRow);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);
            var paginationSet = new PaginationSet<Post>()
            {
                Items = postModel,
                Page = page,
                MaxPage = 5,
                TotalCount = totalRow,
                TotalPages = totalPage
            };
            ViewBag.Feature = _productService.ListFeatureProduct(10);
            return View(paginationSet);
        }

        public ActionResult Detail(int id)
        {
            ViewBag.ReatedPost = _postService.GetReatedPost(id, 4);//Hiển Thị theo ViewBag
            ViewBag.Feature = _productService.ListFeatureProduct(10);
            var model = _postService.GetById(id);
            return View(model);
        }
    }
}
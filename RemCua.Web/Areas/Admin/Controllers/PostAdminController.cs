using RemCua.Entities.Models;
using RemCua.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RemCua.Web.Areas.Admin.Controllers
{
    public class PostAdminController : Controller
    {
        private IPostService _postService;
        private IPostCategoryService _postCategoryService;
        public PostAdminController(IPostService postService, IPostCategoryService postCategoryService)
        {
            this._postService = postService;
            this._postCategoryService = postCategoryService;
        }

        public void SelectViewBag(long? selectedID = null)
        {
            ViewBag.CategoryID = new SelectList(_postCategoryService.GetAll(), "ID", "Name", selectedID);
        }
        [HttpGet]
        public ActionResult ViewPost()
        {
            var list = _postService.GetAll().OrderByDescending(x => x.CreatedDate);
            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            SelectViewBag();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateInput(false)]
        public ActionResult Add(Post post)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (post.CreatedDate == null)
                    {
                        post.CreatedDate = DateTime.Now;
                    }
                    _postService.Add(post);
                    _postService.SaveChanges();
                    ViewBag.Message = "Chúc Mừng Bạn Đã Thêm Thành Công";
                    return RedirectToAction("ViewPost", "PostAdmin");
                }

            }
            catch (Exception)
            {
                ViewBag.Message = "Thêm Không Thành Công";
            }
            SelectViewBag();
            return View(post);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = _postService.GetById(id);
            SelectViewBag();
            return View(product);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateInput(false)]
        public ActionResult Edit(Post post)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (post.CreatedDate == null)
                    {
                        post.CreatedDate = DateTime.Now;
                    }
                    _postService.Update(post);
                    _postService.SaveChanges();
                    ViewBag.Message = "Chúc Mừng Bạn Đã Sửa Thành Công";
                    return RedirectToAction("ViewPost", "PostAdmin");
                }

            }
            catch (Exception)
            {
                ViewBag.Message = "Sửa Không Thành Công";
            }
            SelectViewBag();
            return View(post);
        }

        [HttpGet]
        public ActionResult _DeletePost(int id)
        {
            SelectViewBag();
            var post = _postService.GetById(id);
            return View(post);
        }
        [HttpPost]
        public ActionResult DeletePost(int id)
        {
            var post = _postService.Delete(id);
            _postService.SaveChanges();
            return RedirectToAction("ViewPost", post);
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var result = _postService.ChangeStatus(id);
            _postService.SaveChanges();
            return Json(new
            {
                Status = result
            });
        }
    }
}
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

        public void SelectViewBag(long? selectedID = null)
        {
            ViewBag.CategoryID = new SelectList(_productCategoryService.GetAll(), "ID", "Name", selectedID);
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
            SelectViewBag();
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateInput(false)]
        public ActionResult Add(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (product.CreatedDate == null)
                    {
                        product.CreatedDate = DateTime.Now;
                    }
                    product.Status = true;
                    if (!string.IsNullOrEmpty(product.Tags))
                    {
                        product.Tags.Split(',');
                    }
                    _productService.Add(product);
                    _productService.SaveChanges();
                    ViewBag.Message = "Chúc Mừng Bạn Đã Thêm Thành Công";
                }

            }
            catch (Exception)
            {
                ViewBag.Message = "Thêm Không Thành Công";
            }
            return RedirectToAction("ViewProduct", "ProductAdmin");
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product=_productService.GetById(id);
            SelectViewBag();
            return View(product);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateInput(false)]
        public ActionResult Edit(Product product)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (product.CreatedDate == null)
                    {
                        product.CreatedDate = DateTime.Now;
                    }
                    product.Status = true;
                    if (!string.IsNullOrEmpty(product.Tags))
                    {
                        product.Tags.Split(',');
                    }
                    _productService.Update(product);
                    _productService.SaveChanges();
                    ViewBag.Message = "Chúc Mừng Bạn Đã Sửa Thành Công";
                }

            }
            catch (Exception)
            {
                ViewBag.Message = "Sửa Không Thành Công";
            }
            return RedirectToAction("ViewProduct", "ProductAdmin");
        }




        [HttpGet]
        public ActionResult _DeleteProduct(int id)
        {
            SelectViewBag();
            var product = _productService.GetById(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult DeleteProduct(int id)
        {
            var product = _productService.Delete(id);
            _productService.SaveChanges();
            return RedirectToAction("ViewProduct", product);
        }
    }
}
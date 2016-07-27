using RemCua.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RemCua.Web.Controllers
{
    public class ProductCategoryController : Controller
    {
        private IProductCategoryService _productCategoryService;
        public ProductCategoryController(IProductCategoryService productCategoryService)
        {
            this._productCategoryService = productCategoryService;
        }
        [ChildActionOnly]
        [OutputCache(Duration = 3600)]
        // GET: ProductCategory
        public PartialViewResult _ProductCategory()
        {
            var model = _productCategoryService.GetAll();
            return PartialView(model);
        }
    }
}
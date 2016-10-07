using RemCua.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RemCua.Web.Controllers
{
    public class SildeController : Controller
    {
        private ISlideService _slideService;
        public SildeController(ISlideService slideService)
        {
            this._slideService = slideService;
        }
        // GET: Silde
        [ChildActionOnly]
        //[OutputCache(Duration = 3600)]
        public PartialViewResult _Slide()
        {
            var model = _slideService.GetAll();
            return PartialView(model);
        }
    }
}
using RemCua.Common;
using RemCua.Entities.Models;
using RemCua.Service;
using RemCua.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RemCua.Web.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService productService)
        {
            this._userService = productService;
        }
        public ActionResult ViewUser()
        {
            var list = _userService.GetAll().OrderByDescending(x => x.CreatedDate);
            return View(list);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateInput(false)]
        public ActionResult Add(RegisterModel userModel)
        {
            if (ModelState.IsValid)
            {
                if (_userService.CheckUserName(userModel.UserName))
                {
                    ViewBag.Message = "Tên Tài Khoản Đã Tồn Tại";
                }
                else if (_userService.CheckUserName(userModel.Email))
                {
                    ViewBag.Message = "Email Đã Tồn Tại";
                }
                else
                {
                    var user = new User();
                    user.UserName = userModel.UserName;
                    user.Name = userModel.Name;
                    user.Password = EncryptAndDecrypt.MD5Hash(userModel.Password);
                    user.Phone = userModel.Phone;
                    user.Email = userModel.Email;
                    user.Address = userModel.Address;
                    user.CreatedDate = DateTime.Now;
                    user.Status = false;
                    var result = _userService.Add(user);
                    _userService.SaveChanges();

                    var maxid = _userService.GetById(user.ID);
                    //tao link de gui
                    var u = Request.Url.Authority;
                    var link = "http://" + u + "/Admin/Account/ActiveAcc?id=" + user.ID + "&active=true";
                    string content = System.IO.File.ReadAllText(Server.MapPath("~/Content/Admin/template/newuser.html"));
                    content = content.Replace("{{Name}}", user.Name);
                    content = content.Replace("{{UserName}}", user.UserName);
                    content = content.Replace("{{Password}}", user.Password);
                    content = content.Replace("{{Phone}}", user.Phone);
                    content = content.Replace("{{Email}}", user.Email);
                    content = content.Replace("{{Address}}", user.Address);
                    content = content.Replace("{{Status}}", link);
                    MailHelper.SendMail(user.Email, "Kích Hoạt Tài Khoản Từ Shop Rèm Cửa", content);
                    if (result != null)
                    {
                        ViewBag.Message = "Đăng Ký Thành Công Mời Bạn Vào Mail Kích Hoạt Tài Khoản";
                        userModel = new RegisterModel();
                        return RedirectToAction("ViewUser", "User");
                    }
                    else
                    {
                        ViewBag.Message = "Đăng Ký Không Thành Công";
                    }
                }
            }
            return View(userModel);
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = _userService.GetById(id);
            return View(user);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateInput(false)]
        public ActionResult Edit(User userModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (userModel.CreatedDate == null)
                    {
                        userModel.CreatedDate = DateTime.Now;
                    }
                    _userService.Update(userModel);
                    _userService.SaveChanges();
                    ViewBag.Message = "Chúc Mừng Bạn Đã Sửa Thành Công";
                    return RedirectToAction("ViewUser", "User");
                }

            }
            catch (Exception)
            {
                ViewBag.Message = "Sửa Không Thành Công";
            }
            return View(userModel);
        }




        [HttpGet]
        public ActionResult _DeleteUser(int id)
        {
            var user = _userService.GetById(id);
            return View(user);
        }
        [HttpPost]
        public ActionResult DeleteProduct(int id)
        {
            var user = _userService.Delete(id);
            _userService.SaveChanges();
            return RedirectToAction("ViewUser", user);
        }

        [HttpPost]
        public JsonResult ChangeStatus(int id)
        {
            var result = _userService.ChangeStatus(id);
            _userService.SaveChanges();
            return Json(new
            {
                Status = result
            });
        }
    }
}
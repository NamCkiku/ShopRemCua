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
    public class AccountController : Controller
    {

        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            this._userService = userService;
        }
        // GET: Admin/Account
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// Trang Đăng Nhập
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Login(UserViewModel usermodelview)
        {
            if (ModelState.IsValid)
            {
                var result = _userService.Login(usermodelview.UserName, EncryptAndDecrypt.MD5Hash(usermodelview.Password));
                if (result == 1)
                {
                    var user = _userService.GetByUserName(usermodelview.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;
                    Session.Add(CommonConstants.User_Session, userSession); //Thêm vào Session
                    return RedirectToAction("Index","HomeAdmin");
                }
                else if (result == 0)
                {
                    ViewBag.Message = "Tài Khoản Không Tồn Tại";
                }
                else if (result == -1)
                {
                    ViewBag.Message = "Tài Khoản Đang Bị Khóa";
                }
                else if (result == -2)
                {
                    ViewBag.Message = "Mật Khẩu Không Đúng";
                }
                else
                {
                    ViewBag.Message = "Đăng Nhập Không Thành Công";
                }
            }
            return View(usermodelview);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegisterModel userModel)
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
                    }
                    else
                    {
                        ViewBag.Message = "Đăng Ký Không Thành Công";
                    }
                }
            }
            return View(userModel);
        }

        public ActionResult Logout()
        {
            Session[CommonConstants.User_Session] = null;
            return RedirectToAction("Login", "Account");
        }
        public ActionResult ActiveAcc(int id, bool active)
        {
            if (active)
            {
                RedirectToAction("Login", "Account");
            }
            _userService.Active(id, active);
            return RedirectToAction("Login", "Account");
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        public ActionResult GetPassword(User model)
        {
            if (ModelState.IsValid)
            {
                //var data = db.User.Where(x => x.UserName == model.UserName && x.Email == model.Email).ToList();
                if (_userService.CheckEmail(model.Email) && _userService.CheckUserName(model.UserName))
                {
                    var newpass = MailHelper.RandomString(6);
                    var dataUpdate = _userService.GetByUserName(model.UserName);
                    dataUpdate.Password = newpass;
                    _userService.SaveChanges();
                    //string content = System.IO.File.ReadAllText(Server.MapPath("~/Content/Admin/template/newuser.html"));
                    //content = content.Replace("{{Name}}", user.Name);
                    //content = content.Replace("{{UserName}}", user.UserName);
                    //content = content.Replace("{{Password}}", user.Password);
                    //content = content.Replace("{{Phone}}", user.Phone);
                    //content = content.Replace("{{Email}}", user.Email);
                    //content = content.Replace("{{Address}}", user.Address);
                    //content = content.Replace("{{Status}}", link);
                    //MailHelper.SendMail(user.Email, "Kích Hoạt Tài Khoản Từ BabyShop", content);
                    ViewBag.Message = "Mật khẩu đã được gửi đến hòm thư của bạn !";
                }
                else
                {
                    ViewBag.Message = "Opps...! Tài khoản hoặc email không tồn tại.";
                }
            }
            return View("Login");
        }


        [Authorize]
        public ActionResult ViewChangePass()
        {
            return View();
        }

        //[HttpPost]
        //[Authorize]
        //public ActionResult ChangePass(User models)
        //{
        //    var data = db.User.Single(u => u.UserName.Equals(System.Web.HttpContext.Current.User.Identity.Name));
        //    if (data.Password == models.Password)
        //    {
        //        data.Password = models.Password;
        //        db.SaveChanges();
        //        ViewBag.Message = "Thay đổi thành công";
        //    }
        //    else
        //    {
        //        ViewBag.Message = "Password cũ không đúng";
        //    }
        //    return View("ViewChangePass");
        //}
    }
}
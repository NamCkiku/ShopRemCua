using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RemCua.Web.Areas.Admin.Models
{
    public class UserViewModel
    {
        [Required(ErrorMessage = "Mời Bạn Nhập Tên Tài Khoản")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mời Bạn Nhập Password")]
        public string Password { get; set; }
        public string RememberMe { get; set; }
    }
}
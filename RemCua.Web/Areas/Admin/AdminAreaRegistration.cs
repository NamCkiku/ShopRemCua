using System.Web.Mvc;

namespace RemCua.Web.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                 "orderDetail",
                 "chi-tiet-don-hang/{id}",
                 new { controller = "OrderAdmin", action = "Detail", id = UrlParameter.Optional }
             );

            context.MapRoute(
                 "Order",
                 "xem-don-hang",
                 new { controller = "OrderAdmin", action = "ViewOrder", id = UrlParameter.Optional }
             );


            context.MapRoute(
                 "suatintuc",
                 "sua-tin-tuc/{id}",
                 new { controller = "PostAdmin", action = "Edit", id = UrlParameter.Optional }
             );


            context.MapRoute(
                 "themtintuc",
                 "them-tin-tuc",
                 new { controller = "PostAdmin", action = "Add", id = UrlParameter.Optional }
             );

            context.MapRoute(
                 "tintuc",
                 "quan-ly-tin-tuc",
                 new { controller = "PostAdmin", action = "ViewPost", id = UrlParameter.Optional }
             );



            context.MapRoute(
                 "suasp",
                 "sua-san-pham/{id}",
                 new { controller = "ProductAdmin", action = "Edit", id = UrlParameter.Optional }
             );


            context.MapRoute(
                 "themsp",
                 "them-san-pham",
                 new { controller = "ProductAdmin", action = "Add", id = UrlParameter.Optional }
             );

            context.MapRoute(
                 "sanpham",
                 "quan-ly-san-pham",
                 new { controller = "ProductAdmin", action = "ViewProduct", id = UrlParameter.Optional }
             );

            context.MapRoute(
                 "index",
                 "trang-quan-tri",
                 new { controller = "HomeAdmin", action = "Index", id = UrlParameter.Optional }
             );


            context.MapRoute(
                 "login",
                 "dang-nhap",
                 new { controller = "Account", action = "Login", id = UrlParameter.Optional }
             );


            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DangKiNgayLaoDong
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            // Route cho Area Admin
            routes.MapRoute(
                name: "Admin",
                url: "Admin/{controller}/{action}/{id}",
                defaults: new { area = "Admin", controller = "Admin", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "DangKiNgayLaoDong.Areas.Admin.Controllers" }
            );

            // Route mặc định cho ứng dụng
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Dangnhap", id = UrlParameter.Optional }
            );
        }
    }
}
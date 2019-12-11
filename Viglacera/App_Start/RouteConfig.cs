using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Viglacera
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("ChitietNew", "2/{Tag}/{*catchall}", new { controller = "News", action = "NewsDetail", tag = UrlParameter.Optional }, new { controller = "^N.*", action = "^NewsDetail$" });
            routes.MapRoute("Danhsachnew", "3/{Tag}/{*catchall}", new { controller = "News", action = "ListNews", tag = UrlParameter.Optional }, new { controller = "^N.*", action = "^ListNews$" });
            routes.MapRoute("Danh_Sach_NPP", "9/{Tag}/{*catchall}", new { controller = "ManufacturersDisplay", action = "ListMenufacturers", tag = UrlParameter.Optional }, new { controller = "^M.*", action = "^ListMenufacturers$" });
            routes.MapRoute("Chi_tiet_NPP", "4/{Tag}/{*catchall}", new { controller = "ManufacturersDisplay", action = "ManufacturersDetail", tag = UrlParameter.Optional }, new { controller = "^M.*", action = "^ManufacturersDetail$" });
            routes.MapRoute("Chi_Tiet", "1/{Tag}/{*catchall}", new { controller = "Product", action = "ProductDetail", tag = UrlParameter.Optional }, new { controller = "^P.*", action = "^ProductDetail$" });
            routes.MapRoute("Danh_Sach", "0/{Tag}/{*catchall}", new { controller = "Product", action = "ListProduct", tag = UrlParameter.Optional }, new { controller = "^P.*", action = "^ListProduct$" });
            routes.MapRoute(name: "ban-tin-khuyen-mai", url: "ban-tin-khuyen-mai", defaults: new { controller = "sale", action = "detail" });
            routes.MapRoute("ProductSyn", "Syn/{Tag}/{*catchall}", new { controller = "ProductSyn", action = "ProductSyn_Detail", tag = UrlParameter.Optional }, new { controller = "^P.*", action = "^ProductSyn_Detail$" });
            routes.MapRoute(name: "combo-vilacera", url: "combo-vilacera", defaults: new { controller = "ProductSyn", action = "list" });

            routes.MapRoute(name: "Tin-tuc", url: "Tin-tuc.aspx", defaults: new { controller = "News", action = "ListNews" });
            routes.MapRoute(name: "Contact", url: "Lien-he.aspx", defaults: new { controller = "Contacts", action = "Index" });
            routes.MapRoute(name: "SearchProduct", url: "SearchProduct", defaults: new { controller = "Product", action = "Search" });
            routes.MapRoute(name: "Order", url: "Order", defaults: new { controller = "Order", action = "OrderIndex" });
            routes.MapRoute(name: "Maps", url: "Ban-do.aspx", defaults: new { controller = "MapsDisplay", action = "Index" });
            routes.MapRoute(name: "Admin", url: "Admin", defaults: new { controller = "Login", action = "LoginIndex" });
            routes.MapRoute(name: "He-thong-phan-phoi", url: "He-Thong-phan-phoi.aspx", defaults: new { controller = "ManufacturersDisplay", action = "ListMenufacturers" });
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
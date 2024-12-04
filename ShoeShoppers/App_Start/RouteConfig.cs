using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace ShoeShoppers
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            settings.AutoRedirectMode = RedirectMode.Permanent;
            routes.EnableFriendlyUrls(settings);

            routes.Ignore("{resource}.axd/{*pathInfo}");


            routes.MapPageRoute("Login", "Login", "~/Pages/Login.aspx");
            routes.MapPageRoute("Registration", "registration", "~/Pages/Registration.aspx");


            routes.MapPageRoute("AdminDashboard", "admin", "~/Pages/admin/Dashboard.aspx" );


            routes.MapPageRoute("Default", "", "~/Default.aspx");

            routes.MapPageRoute("Products", "products", "~/Pages/Products.aspx");
            routes.MapPageRoute("ProductDetail", "product/{id}", "~/Pages/ProductDetail.aspx");


        }
    }
}

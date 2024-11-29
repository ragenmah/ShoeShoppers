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


            routes.MapPageRoute("Default", "", "~/Pages/Login.aspx");
            routes.MapPageRoute("RegistrationRoute", "registration", "~/Pages/Registration.aspx");
            routes.MapPageRoute("AdminDashboard", "admin", "~/Pages/admin/Dashboard.aspx"
       );
        }
    }
}

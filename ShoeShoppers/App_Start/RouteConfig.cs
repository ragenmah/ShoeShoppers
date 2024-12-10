using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;
using ShoeShoppers.Pages;
using ShoeShoppers.Pages.Admin;

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


         

            
            routes.MapPageRoute("Default", "", "~/Default.aspx");
            routes.MapPageRoute("Faqs", "faqs", "~/Faqs.aspx");

            routes.MapPageRoute("Products", "products", "~/Pages/Products.aspx");
            routes.MapPageRoute("ProductDetail", "product/{ProductId}", "~/Pages/ProductDetail.aspx");

            //Admin Routes
            routes.MapPageRoute("AdminDashboard", "admin", "~/Pages/admin/Dashboard.aspx");
            routes.MapPageRoute("ProductList", "product-list", "~/Pages/Admin/Products/ProductList.aspx");
            routes.MapPageRoute("AddProduct", "add-product", "~/Pages/Admin/Products/AddProduct.aspx");
            routes.MapPageRoute("EditProduct", "edit-product/{ProductId}", "~/Pages/Admin/Products/AddProduct.aspx");

            routes.MapPageRoute("ProductImageList", "add-product-images/{ProductId}", "~/Pages/Admin/Products/ProductImageList.aspx");

            // Manage Categories
            routes.MapPageRoute("CategoryList", "category-list", "~/Pages/Admin/Categories/CategoryList.aspx");


            //Manage Cart
            routes.MapPageRoute("Cart", "cart/{ProductId}", "~/Pages/Admin/Products/ProductImageList.aspx");

            //Logout
            routes.MapPageRoute("Logout", "logout", "~/Pages/Logout.aspx");

        }
    }
}

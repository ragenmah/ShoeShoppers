using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeShoppers.Database.Helpers
{
    public static class UserHelper
    {
        public static int GetUserIdFromCookie()
        {
            HttpCookie loginCookie = HttpContext.Current.Request.Cookies["UserLogin"];
            if (loginCookie != null)
            {
                string userId = loginCookie["UserId"];
                if (userId != null)
                {
                    return int.Parse(userId);
                }
            }

            return 0;
        }

        public static string GetEmailFromCookie()
        {
            HttpCookie loginCookie = HttpContext.Current.Request.Cookies["UserLogin"];
            if (loginCookie != null)
            {
                string userEmail = loginCookie["Email"];
                if (userEmail != null)
                {
                    return userEmail;
                }
            }

            return "";
        }

        public static string GetRoleFromCookie()
        {
            HttpCookie loginCookie = HttpContext.Current.Request.Cookies["UserLogin"];
            if (loginCookie != null)
            {
                string userEmail = loginCookie["Role"];
                if (userEmail != null)
                {
                    return userEmail;
                }
            }

            return "";
        }
    }
}
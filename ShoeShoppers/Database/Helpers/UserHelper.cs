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
                if (userId!=null)
                {
                    

                    return int.Parse(userId);


                }

            }

            return 0;
        }
    }
}
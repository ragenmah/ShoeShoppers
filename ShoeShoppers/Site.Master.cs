using ShoeShoppers.Database.Helpers;
using ShoeShoppers.Database.Repository;
using ShoeShoppers.Model;
using ShoeShoppers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoeShoppers
{
    public partial class SiteMaster : MasterPage
    {
        private readonly CartService _cartService;
        private readonly int userId;

        public SiteMaster()
        {

            _cartService = new CartService(new CartRepository());

            userId = UserHelper.GetUserIdFromCookie();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CountCartItems();
            }
        }

        private void CountCartItems()
        {
            List<Cart> cartItems = _cartService.GetAllCartItemsByUser(userId);
            cartCount.InnerText = cartItems.Count.ToString();
        }
    }
}
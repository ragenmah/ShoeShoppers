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

                if (userId > 0) {
                    ddlMyAccount.Visible = true;
                    btnShopNow.Visible = false;
                }
            }
        }

        private void CountCartItems()
        {
            List<Cart> cartItems = _cartService.GetAllCartItemsByUser(userId);
            cartCount.InnerText = cartItems.Count.ToString();
        }

        protected void ddlMyAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected value from the dropdown
            string selectedValue = ddlMyAccount.SelectedValue;

            // Redirect to the selected page if a value is chosen
            if (!string.IsNullOrEmpty(selectedValue))
            {
                Response.Redirect(selectedValue);
            }
        }
    }
}
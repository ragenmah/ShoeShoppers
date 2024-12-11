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

namespace ShoeShoppers.Pages
{
    public partial class MyCart : System.Web.UI.Page
    {
        private readonly CartService _cartService;

        private readonly int userId;

        public MyCart()
        {
           
            _cartService = new CartService(new CartRepository());

            userId = UserHelper.GetUserIdFromCookie();
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCartData();
            }
        }

        private void BindCartData()
        {
            List<Cart> cartItems = _cartService.GetAllCartItemsByUser(userId);
            if (cartItems.Count > 0) {
                emptyCartDiv.Visible = false;
            }

            GridViewCart.DataSource = cartItems;
            GridViewCart.DataBind();
        }

       

      

        protected void GridViewCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewCart.Rows[index];
                //TxtCartId.Text = row.Cells[0].Text;
                //TxtProductId.Text = row.Cells[1].Text;
                //TxtQuantity.Text = row.Cells[2].Text;
                //TxtUserId.Text = row.Cells[3].Text;
            }
            else if (e.CommandName == "DeleteRow")
            {
                int cartId = Convert.ToInt32(e.CommandArgument);
               _cartService.DeleteCart(cartId);
                BindCartData();
            }
        }
    }
}
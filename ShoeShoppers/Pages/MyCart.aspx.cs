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
        private readonly CartService _cartService = new CartService(new CartRepository());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCartData();
            }
        }

        private void BindCartData()
        {
            List<Cart> cartItems = _cartService.GetAllCarts();
            if (cartItems.Count > 0) {
                emptyCartDiv.Visible = false;
            }

            GridViewCart.DataSource = cartItems;
            GridViewCart.DataBind();
        }

        protected void BtnAddToCart_Click(object sender, EventArgs e)
        {
            
          var cart = new Cart
          {
              ProductId = int.Parse(TxtProductId.Text),
              Quantity = int.Parse(TxtQuantity.Text),
              UserId = int.Parse(TxtUserId.Text)
          };
            _cartService.AddCart(cart);
            BindCartData();
            BindCartData();
        }

        protected void BtnUpdateCart_Click(object sender, EventArgs e)
        {
            var cart = new Cart
            {
                CartId = int.Parse(TxtCartId.Text),
                ProductId = int.Parse(TxtProductId.Text),
                Quantity = int.Parse(TxtQuantity.Text),
                UserId = int.Parse(TxtUserId.Text)
            };
            _cartService.UpdateCart(cart);
            BindCartData();
        }

        protected void BtnDeleteCart_Click(object sender, EventArgs e)
        {
            int cartId = int.Parse(TxtCartId.Text);
            _cartService.DeleteCart(cartId);
            BindCartData();
        }

        protected void GridViewCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "EditRow")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridViewCart.Rows[index];
                TxtCartId.Text = row.Cells[0].Text;
                TxtProductId.Text = row.Cells[1].Text;
                TxtQuantity.Text = row.Cells[2].Text;
                TxtUserId.Text = row.Cells[3].Text;
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
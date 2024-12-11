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

        decimal totalCartAmount = 0;

        

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
            List<Cart> cartItems= _cartService.GetAllCartItemsByUser(userId);
            if (cartItems.Count > 0) {
                emptyCartDiv.Visible = false;
                CalculateTotalPrice(cartItems);

            }

            GridViewCart.DataSource = cartItems;
            GridViewCart.DataBind();
        }

        private void CalculateTotalPrice(List<Cart> cartItems) {
            foreach (var item in cartItems)
            {
                totalCartAmount += item. TotalPrice;
            }

            lblTotalAmount.Text = $"Total (After Discount): ${totalCartAmount:N2}";
        }
       

      

        protected void GridViewCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            int cartId = Convert.ToInt32(GridViewCart.DataKeys[rowIndex].Value);

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
               _cartService.DeleteCart(cartId);
                BindCartData();
            }
        }

        protected void GridViewCart_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TextBox txtQuantity = (TextBox)e.Row.FindControl("txtQuantity");
                if (txtQuantity != null)
                {
                    txtQuantity.Attributes["min"] = "1";
                    txtQuantity.Attributes["max"] = "100";
                }
            } 
        }

        protected void QuantityChanged(object sender, EventArgs e)
        {
            TextBox txtQuantity = (TextBox)sender;

            GridViewRow row = (GridViewRow)txtQuantity.NamingContainer;


            int cartId = Convert.ToInt32(GridViewCart.DataKeys[row.RowIndex].Values["CartId"]);
            int productId = Convert.ToInt32(GridViewCart.DataKeys[row.RowIndex].Values["ProductId"]);
            
            int quantity;
            if (!int.TryParse(txtQuantity.Text, out quantity) || quantity < 1)
            {
                txtQuantity.Text = "1"; 
                quantity = 1;
            }
             
            UpdateCartItem(cartId, productId, quantity);

        }

        private void UpdateCartItem(int cartId, int productId, int quantity  )
        {
            var cart = new Cart
            {ProductId= productId,
                CartId = cartId,
                Quantity = quantity,
                UserId = userId
            };
            _cartService.UpdateCart(cart);
            BindCartData();
        }

    }
}
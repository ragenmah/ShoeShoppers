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
                // Find the quantity TextBox in the row
                TextBox txtQuantity = (TextBox)e.Row.FindControl("txtQuantity");

                // Calculate the TotalPrice for the row if necessary
                if (txtQuantity != null)
                {
                    int quantity = Convert.ToInt32(txtQuantity.Text);
                    decimal price = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "Price"));
                    decimal discountedPrice = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "DiscountedPrice"));
                    decimal totalPrice = discountedPrice * quantity;

                    // Update the TotalPrice field in the GridView
                    e.Row.Cells[6].Text = totalPrice.ToString("C2"); // Assuming TotalPrice is in the 7th column
                }
            }
        }

        protected void QuantityChanged(object sender, EventArgs e)
        {
            // Get the row that was updated
            GridViewRow row = (sender as TextBox).NamingContainer as GridViewRow;

            // Find the controls in the row
            TextBox txtQuantity = (TextBox)row.FindControl("txtQuantity");
            Label lblTotalPrice = (Label)row.FindControl("lblTotalPrice");  // Assuming a Label for TotalPrice in the row

            if (txtQuantity != null && lblTotalPrice != null)
            {
                // Get the new quantity value
                int quantity = Convert.ToInt32(txtQuantity.Text);

                // Get the current price and discounted price
                decimal price = Convert.ToDecimal(DataBinder.Eval(row.DataItem, "Price"));
                decimal discountedPrice = Convert.ToDecimal(DataBinder.Eval(row.DataItem, "DiscountedPrice"));

                // Calculate the new TotalPrice
                decimal totalPrice = discountedPrice * quantity;

                // Update the TotalPrice label
                lblTotalPrice.Text = totalPrice.ToString("C2");

                // Optionally, save this updated total back to your data source
                // Update the database or session with the new TotalPrice for this row
            }
        }

    }
}
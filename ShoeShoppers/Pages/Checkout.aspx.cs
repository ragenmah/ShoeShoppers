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
    public partial class Checkout : System.Web.UI.Page
    {
        private readonly int userId;
        private readonly CartService _cartService;

        decimal totalCartAmount = 0;

        public Checkout()
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
            if (cartItems.Count > 0)
            {
               

                CalculateTotalPrice(cartItems);

            }

            rptCart.DataSource = cartItems;
            rptCart.DataBind();
        }

        private void CalculateTotalPrice(List<Cart> cartItems)
        {
            foreach (var item in cartItems)
            {
                totalCartAmount += item.TotalPrice;
            }

            lblTotalAmount.Text = $"Total (After Discount): ${totalCartAmount:N2}";
        }

        protected void RepeaterCart_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int cartId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Update")
            {
                TextBox txtQuantity = (TextBox)e.Item.FindControl("txtQuantity");
                int newQuantity = int.Parse(txtQuantity.Text);

            }
            else if (e.CommandName == "Remove")
            {
                _cartService.DeleteCart(cartId);
            }


            BindCartData();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Retrieve user input
            string ownerName = txtOwnerName.Text.Trim();
            string cardNo = txtCardNo.Text.Trim();
            string expiryDate = txtExpiryDate.Text.Trim();
            int.TryParse(txtCvvNo.Text.Trim(), out int cvvNo);
            string billingAddress = txtBillingAddress.Text.Trim();
            string paymentMethod = ddlPaymentMethod.SelectedValue;

            // Validate inputs
            if (string.IsNullOrEmpty(ownerName) || string.IsNullOrEmpty(paymentMethod))
            {
                // Display error message (e.g., using a Label)
                //lblErrorMessage.Text = "Owner Name and Payment Method are required.";
                return;
            }

            // Save to database
            //SavePayment(ownerName, cardNo, expiryDate, cvvNo, billingAddress, paymentMethod);

            // Provide success feedback
            //lblSuccessMessage.Text = "Payment submitted successfully!";
            //ClearForm();
        }

        protected void ddlPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            PaymentFormPanel.Visible = true;
        }
    }
}
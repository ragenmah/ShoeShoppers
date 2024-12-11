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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulatePaymentMethods();
            }
        }

        private void PopulatePaymentMethods()
        {
            // Define the payment methods
            var paymentMethods = new List<string>
    {
        "Credit Card",
        "PayPal",
        "Bank Transfer",
        "Cash on Delivery"
    };

            // Bind the payment methods to the dropdown
            ddlPaymentMethod.DataSource = paymentMethods;
            ddlPaymentMethod.DataBind();

            // Optionally, add a default "Select" item
            ddlPaymentMethod.Items.Insert(0, new ListItem("-- Select Payment Method --", ""));
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
    }
}
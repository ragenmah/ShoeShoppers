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

namespace ShoeShoppers.Pages.Admin.Contacts
{
    public partial class Contacts : System.Web.UI.Page
    {
        private readonly ContactUsService _contactUsService;
            private readonly int userId;

        public Contacts()
        {

            _contactUsService = new ContactUsService(new ContactUsRepository());
            userId = UserHelper.GetUserIdFromCookie();

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadContactUs();
            }
        }

        private void LoadContactUs()
        { 
            var productReviews = _contactUsService.GetContactUsList();
            if (!(productReviews.Count > 0))
            {
                lblNoContacts.Visible = true;
            }
            rptContactUs.DataSource = productReviews;
            rptContactUs.DataBind();
        }

        protected void rptContactUs_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ReplyContact")
            {
                // Get the ContactUsId from the CommandArgument
                int contactUsId = Convert.ToInt32(e.CommandArgument);

                // Find the TextBox within the Repeater item
                TextBox txtReply = (TextBox)e.Item.FindControl("txtReply");

                if (txtReply != null)
                {
                    string replyContent = txtReply.Text;

                    if (!string.IsNullOrEmpty(replyContent))
                    {
                        // Save the reply to the database
                        //SaveContactReply(contactUsId, replyContent);

                        // Reload the data to reflect changes
                        LoadContactUs();
                    }
                }
            }
        }
    }
}
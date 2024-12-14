using ShoeShoppers.Database.Helpers;
using ShoeShoppers.Database.Repository;
using ShoeShoppers.Model;
using ShoeShoppers.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoeShoppers
{
    public partial class Contact : Page
    {
        private readonly ContactUsService _contactUsService;


        public Contact()
        {

            _contactUsService = new ContactUsService(new ContactUsRepository());

        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendMessageBtn_Click(object sender, EventArgs e)
        {

            string email = txtEmail.Text.Trim();

            ContactUs contactUs = new ContactUs
            {
                FullName = txtFullName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                PhoneNumber = txtPhoneNumber.Text.Trim(),
                Message = txtMessage.Text.Trim(),
            };

            _contactUsService.AddContactUs(contactUs);

        }
    }
}
using Microsoft.Ajax.Utilities;
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

namespace ShoeShoppers.Pages
{
    public partial class MyAccount : System.Web.UI.Page
    {
        private readonly UserService _userService;

        private readonly int userId;

        public MyAccount()
        {

            _userService = new UserService(new UserRepository());

            userId = UserHelper.GetUserIdFromCookie();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PrepopulateUserDetail();
            }
        }
        private void PrepopulateUserDetail()
        {
            User user = _userService.GetUserById(userId);
            if (user != null)
            {
                txtFirstName.Text = user.FirstName;
                txtLastName.Text = user.LastName;
                txtEmail.Text = user.Email;
                txtMobileNumber.Text = user.MobileNumber;
                if (user.DateOfBirth.HasValue)
                    txtDateOfBirth.Text = user.DateOfBirth.Value.ToString("dd-MM-yyyy");
                txtAddress.Text = user.Address;
                txtCity.Text = user.City;
                txtPostalCode.Text = user.PostalCode;
                txtCountry.Text = user.Country;

                lblFullNameField.InnerText = $"{user.FirstName} {user.LastName}";
                lblEmailField.InnerText = user.Email;

                if (!user.AccountImage.IsNullOrWhiteSpace()) {
                    iconField.Visible = false;
                    accountImageField.Src = user.AccountImage;
                    accountImageField.Visible = true;
                }
                else
                {
                    accountImageField.Visible = false;
                    iconField.Visible = true;
                }

            }
        }

        protected void UpdateDetailsBtn_Click(object sender, EventArgs e)
        {

            string email = txtEmail.Text.Trim();
            string imagePath = null;
            if (fileAccountImage.HasFile)
            {
                string folderPath = Server.MapPath("~/Uploads/Users/");
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                string fileName = Path.GetFileName(fileAccountImage.FileName);
                imagePath = "~/Uploads/Users/" + fileName;
                fileAccountImage.SaveAs(folderPath + fileName);
            }

            User user = new User
            {
                UserId = userId,
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                Country = txtCountry.Text.Trim(),
                City = txtCity.Text.Trim(),
                PostalCode = txtPostalCode.Text.Trim(),
                MobileNumber = txtMobileNumber.Text.Trim(),
                AccountImage = imagePath,
            };

            _userService.UpdateUser(user);
            Response.Redirect(Request.RawUrl);
            PrepopulateUserDetail();
        }

    }
}
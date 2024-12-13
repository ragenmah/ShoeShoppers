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
        User userDetail;
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
            userDetail = _userService.GetUserById(userId);
            if (userDetail != null)
            {
                txtFirstName.Text = userDetail.FirstName;
                txtLastName.Text = userDetail.LastName;
                txtEmail.Text = userDetail.Email;
                txtMobileNumber.Text = userDetail.MobileNumber;
                if (userDetail.DateOfBirth.HasValue)
                    txtDateOfBirth.Text = userDetail.DateOfBirth.Value.ToString("yyyy-MM-dd");
                txtAddress.Text = userDetail.Address;
                txtCity.Text = userDetail.City;
                txtPostalCode.Text = userDetail.PostalCode;
                txtCountry.Text = userDetail.Country;

                lblFullNameField.InnerText = $"{userDetail.FirstName} {userDetail.LastName}";
                lblEmailField.InnerText = userDetail.Email;

                if (!userDetail.AccountImage.IsNullOrWhiteSpace()) {
                    iconField.Visible = false;
                    accountImageField.Src = userDetail.AccountImage;
                    accountImageField.Visible = true;
                    hfOldImageLink.Value= userDetail.AccountImage;
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
            else  {
                imagePath = hfOldImageLink.Value;
            }

                User user = new User
            {
                UserId = userId,
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Address = txtAddress.Text.Trim(),
                DateOfBirth = txtDateOfBirth.Text.IsNullOrWhiteSpace()? (DateTime?)null : Convert.ToDateTime(txtDateOfBirth.Text.Trim()),
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
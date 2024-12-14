using ShoeShoppers.Database;
using ShoeShoppers.Database.Repository;
using ShoeShoppers.Model;
using ShoeShoppers.Services;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoeShoppers.Pages.Admin.Categories
{
    public partial class CategoryList : System.Web.UI.Page
    {
        private readonly CategoryService _categoryBLL;
        string imagePath;
        public CategoryList()
        {
            _categoryBLL = new CategoryService(new CategoryRepository());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
            }
        }

        private void LoadCategories()
        {

            var categories = _categoryBLL.GetAllCategories();

            if (categories != null && categories.Count > 0)
            {
                gvCategories.DataSource = categories;
                gvCategories.DataBind();
                gvCategories.Visible = true;
                lblNoCategories.Visible = false; // Hide the "No categories" message
            }
            else
            {
                gvCategories.Visible = false;
                lblNoCategories.Visible = true; // Show the "No categories" message
            }
           
        }
        private void ClearForm()
        {
            txtCategoryName.Text = string.Empty;
            imagePath = string.Empty;
            chkIsActive.Checked = false;
        }

        protected void SaveCategory(object sender, EventArgs e)
        {
            string imageUrl = string.Empty;

            if (fuCategoryImage.HasFile)
            {
                try
                {
                    // Define the folder to save the image
                    string folderPath = Server.MapPath("~/Uploads/Images/");

                    // Ensure the directory exists
                    if (!System.IO.Directory.Exists(folderPath))
                    {
                        System.IO.Directory.CreateDirectory(folderPath);
                    }

                    // Generate a unique file name to prevent overwrites
                    string fileName = Guid.NewGuid().ToString() + "_" + fuCategoryImage.FileName;

                    // Save the file
                    string filePath = folderPath + fileName;
                    fuCategoryImage.SaveAs(filePath);

                    // Set the URL for the database
                    imageUrl = "~/Uploads/Images/" + fileName;
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error while uploading image: " + ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return; // Stop further execution if image upload fails
                }
            }
            else
            {
                lblMessage.Text = "Please select an image to upload.";
                lblMessage.ForeColor = System.Drawing.Color.Red;
                return; // Stop execution if no image is uploaded
            }

            // Proceed with saving the category
            try
            {
                var category = new Category
                {
                    CategoryName = txtCategoryName.Text.Trim(),
                    CategoryImageUrl = imageUrl,
                    IsActive = chkIsActive.Checked
                };

                _categoryBLL.AddCategory(category);

                lblMessage.Text = "Category added successfully.";
                lblMessage.ForeColor = System.Drawing.Color.Green;

                // Clear form fields after saving
               

                LoadCategories(); ClearForm();

            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error while saving category: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }

        }
        protected void gvCategories_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvCategories.EditIndex = e.NewEditIndex;
            LoadCategories();
        }

        protected void gvCategories_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                // Retrieve the primary key
                int categoryId = Convert.ToInt32(gvCategories.DataKeys[e.RowIndex]?.Value);

                // Retrieve controls from the GridView row
                GridViewRow row = gvCategories.Rows[e.RowIndex];
                TextBox txtCategoryName = row.FindControl("txtCategoryName") as TextBox;
                FileUpload fuCategoryImage = row.FindControl("fuCategoryImage") as FileUpload;
                HiddenField hfCategoryImageUrl = row.FindControl("hfCategoryImageUrl") as HiddenField;
                CheckBox chkIsActive = row.FindControl("chkIsActive") as CheckBox;

                // Ensure controls are found
                if (txtCategoryName == null || fuCategoryImage == null || hfCategoryImageUrl == null || chkIsActive == null)
                {
                    lblMessage.Text = "Error: Could not find controls.";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    return;
                }

                // Determine the image URL
                string imageUrl = hfCategoryImageUrl.Value; // Default to existing URL
                if (fuCategoryImage.HasFile)
                {
                    // Save the new file
                    string folderPath = Server.MapPath("~/Uploads/Images/");
                    if (!System.IO.Directory.Exists(folderPath))
                    {
                        System.IO.Directory.CreateDirectory(folderPath);
                    }

                    string fileName = Guid.NewGuid().ToString() + "_" + fuCategoryImage.FileName;
                    string filePath = folderPath + fileName;
                    fuCategoryImage.SaveAs(filePath);

                    // Update the image URL
                    imageUrl = "~/Uploads/Images/" + fileName;
                }

                // Prepare the update query
                string updateQuery = @"
            UPDATE Categories
            SET 
                CategoryName = @CategoryName,
                CategoryImageUrl = @CategoryImageUrl,
                IsActive = @IsActive
            WHERE CategoryId = @CategoryId";

                // Execute the update
                using (SqlConnection conn = DatabaseConnection.Instance.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@CategoryName", txtCategoryName.Text.Trim());
                        cmd.Parameters.AddWithValue("@CategoryImageUrl", imageUrl);
                        cmd.Parameters.AddWithValue("@IsActive", chkIsActive.Checked);
                        cmd.Parameters.AddWithValue("@CategoryId", categoryId);

                        cmd.ExecuteNonQuery();
                    }
                }

                // Exit edit mode and reload the data
                gvCategories.EditIndex = -1;
                LoadCategories();
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = "Category updated successfully.";

            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void gvCategories_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCategories.EditIndex = -1;
            LoadCategories();
        }

        protected void gvCategories_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            // Set the new page index
            gvCategories.PageIndex = e.NewPageIndex;

            // Rebind the data to reflect the new page
            LoadCategories();
        }

        protected void gvCategories_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int categoryId = Convert.ToInt32(gvCategories.DataKeys[e.RowIndex].Value);
            _categoryBLL.DeleteCategory(categoryId);
            lblMessage.ForeColor = System.Drawing.Color.White;
            lblMessage.BackColor = System.Drawing.Color.DarkRed;
            lblMessage.Text = "Category deleted successfully.";
            LoadCategories();
        }


        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

    }
}
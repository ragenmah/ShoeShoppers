using ShoeShoppers.Database.Repository;
using ShoeShoppers.Model;
using ShoeShoppers.Services;
using System;
using System.Collections.Generic;
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
            var connection = Database.DatabaseConnection.Instance.GetConnection();
            _categoryBLL = new CategoryService(new CategoryRepository(connection));
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
            gvCategories.DataSource = _categoryBLL.GetAllCategories();
            gvCategories.DataBind();
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
            // Retrieve the row being edited
            GridViewRow row = gvCategories.Rows[e.RowIndex];
            int categoryId = Convert.ToInt32(gvCategories.DataKeys[e.RowIndex].Value);

            string categoryName = ((TextBox)row.Cells[1].Controls[0]).Text;
            bool isActive = ((CheckBox)row.Cells[3].Controls[0]).Checked;

            // Update logic
            var category = new Category
            {
                CategoryId = categoryId,
                CategoryName = categoryName,
                IsActive = isActive
            };
            _categoryBLL.UpdateCategory(category); // Example method

            gvCategories.EditIndex = -1;
            LoadCategories();
        }

        protected void gvCategories_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvCategories.EditIndex = -1;
            LoadCategories();
        }

        protected void gvCategories_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int categoryId = Convert.ToInt32(gvCategories.DataKeys[e.RowIndex].Value);
            _categoryBLL.DeleteCategory(categoryId); // Example method
            LoadCategories();
        }
    }
}
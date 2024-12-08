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

namespace ShoeShoppers.Pages.Admin.Products
{
    public partial class AddProduct : System.Web.UI.Page
    {
        private readonly ProductService _service = new ProductService(new ProductRepository());
        private readonly CategoryService _categoryBLL = new CategoryService(new CategoryRepository());

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCategories();
            }
        }

        private void LoadCategories()
        {
            // Example: Bind categories to dropdown (assume CategoryService exists)
            var categories =  _categoryBLL.GetAllCategories();
            ddlCategory.DataSource = categories;
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryId";
            ddlCategory.DataBind();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate and save the uploaded image
                string imagePath = null;
                if (fileUpload.HasFile)
                {
                    string folderPath = Server.MapPath("~/Images/Products/");
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }

                    string fileName = Path.GetFileName(fileUpload.FileName);
                    imagePath = "~/Images/Products/" + fileName;
                    fileUpload.SaveAs(folderPath + fileName);
                }

                // Create and save the product
                var product = new Product
                {
                    ProductName = txtProductName.Text.Trim(),
                    ProductDescription = txtDescription.Text.Trim(),
                    Price = decimal.Parse(txtPrice.Text),
                    DiscountPercentage = decimal.Parse(txtDiscount.Text),
                    StockQuantity = int.Parse(txtStock.Text),
                    Size = txtSize.Text.Trim(),
                    Color = txtColor.Text.Trim(),
                    CategoryId = int.Parse(ddlCategory.SelectedValue),
                    ImageUrl = imagePath,
                    IsActive = chkIsActive.Checked
                };

                _service.AddProduct(product);
                lblMessage.Text = "Product added successfully!";
                lblMessage.ForeColor = System.Drawing.Color.Green;

                ClearForm();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("/product-list"); 
        }

        private void ClearForm()
        {
            txtProductName.Text = string.Empty;
            txtDescription.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtDiscount.Text = string.Empty;
            txtStock.Text = string.Empty;
            txtSize.Text = string.Empty;
            txtColor.Text = string.Empty;
            ddlCategory.SelectedIndex = -1;
            chkIsActive.Checked = false;
        }
    }
}
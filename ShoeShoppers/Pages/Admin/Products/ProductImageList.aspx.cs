﻿using ShoeShoppers.Model;
using ShoeShoppers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShoeShoppers.Pages.Admin.Products
{
    public partial class ProductImageList : System.Web.UI.Page
    {
        private ProductImageService _productImageService = new ProductImageService();
        string productId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (RouteData.Values["ProductId"] != null)
                {
                     productId = RouteData.Values["ProductId"].ToString();
                    txtProductId.Text = productId.ToString();
                }
                else
                {
                    // Handle the case where the ProductId is missing from the URL
                    Response.Redirect("~/Admin/Products/ProductList.aspx");
                }
                LoadProducts();
            }

        }

        protected void DeleteImage(object sender, CommandEventArgs e)
        {
            int imageId = Convert.ToInt32(e.CommandArgument);
            _productImageService.DeleteProductImage(imageId);
            //BindProductImages(); // Refresh the images grid
        }
        private void LoadProducts()
        {
            gvProductImages.DataSource = _productImageService.GetProductImages(productId);
            gvProductImages.DataBind();
        }


        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (fileUpload.HasFile)
            {
                string fileName = fileUpload.FileName;
                string imageUrl = "~/Uploads/Products/" + fileName;
                string savePath = Server.MapPath(imageUrl);

                try
                {
                    // Save the file to the server
                    fileUpload.SaveAs(savePath);

                    // Create a ProductImage object and store it in the database
                    ProductImage productImage = new ProductImage
                    {
                        ProductId = int.Parse(txtProductId.Text),
                        ImageUrl = imageUrl,
                        CreatedAt = DateTime.Now
                    };

                    _productImageService.AddProductImage(productImage);
                    productId = txtProductId.Text;

                    // Redirect to another page or show success message
                    //Response.Redirect("~/Admin/Products/ProductImages.aspx");
                    LoadProducts();
                }
                catch (Exception ex)
                {
                    // Handle file save exceptions
                    Response.Write("Error: " + ex.Message);
                }
            }
            else
            {
                Response.Write("No file selected.");
            }
        }
    }
}
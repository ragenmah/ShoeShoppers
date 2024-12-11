using ShoeShoppers.Database.Helpers;
using ShoeShoppers.Database.Repository;
using ShoeShoppers.Model;
using ShoeShoppers.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ShoeShoppers.Pages
{
    public partial class ProductDetail : System.Web.UI.Page
    {
        private readonly ProductService _productService;
        private ProductImageService _productImageService;
        private readonly CartService _cartService ;

        private readonly int userId;

        Product product;
        public ProductDetail()
        {
            _productService = new ProductService(new ProductRepository());
            _productImageService = new ProductImageService();
            _cartService = new CartService(new CartRepository());

            userId = UserHelper.GetUserIdFromCookie();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (RouteData.Values["ProductId"] != null) { 
            
            int productId = int.Parse((string)RouteData.Values["ProductId"]);
            if (productId>0)
            {
                LoadProductDetails(productId);
                    LoadProductImages(productId);
            }
            }
        }

        private void LoadProductDetails(int productId)
        {
             product = _productService.GetProductById(productId);

            if (product != null)
            {
                lblProductName.Text = product.ProductName;
                lblPrice.Text = $"${product.Price:N2}";
                lblDescription.Text = product.ProductDescription ?? "No description available.";
            }
            else
            {
                lblProductName.Text = "Product not found!";
                lblPrice.Text = "";
                lblDescription.Text = "";
            }
        }

        private void LoadProductImages(int productId)
        {
            var images = _productImageService.GetProductImages(productId.ToString());
            if (images != null && images.Any())
            {
                
                    rptProductImages.DataSource = images.Select(img => new { ImageUrl = ResolveUrl(img.ImageUrl) }).ToList();
            }
            else
            {
                rptProductImages.DataSource = new List<object> { new { ImageUrl = ResolveUrl(product.ImageUrl) } };

            }
            rptProductImages.DataBind();
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            var cart = new Cart
            {
                ProductId = product.ProductId,
                Quantity = int.Parse(TxtCartQuantity.Text),
                UserId = userId
            };
            _cartService.AddOrUpdateCart(cart);
           
            lblSuccessMessage.Text = "Item added to cart successfully!";
            lblSuccessMessage.Visible = true;
            //Response.Redirect("/my-cart");
         
            timerHideMessage.Enabled = true;
        }

        protected void timerHideMessage_Tick(object sender, EventArgs e)
        {
           
            lblSuccessMessage.Visible = false;

            timerHideMessage.Enabled = false;
        }
    }
}
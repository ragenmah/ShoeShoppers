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

namespace ShoeShoppers.Pages
{
    public partial class Invoice : System.Web.UI.Page
    {
        private readonly OrderService _orderService  ;
        private readonly OrderItemsService _orderItemService;

        private readonly int userId;



        public Invoice()
        {

            _orderService = new OrderService(new OrderRepository());
            _orderItemService = new OrderItemsService(new OrderItemRepository());

            userId = UserHelper.GetUserIdFromCookie();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int orderId = int.Parse((string)RouteData.Values["OrderId"]);

                LoadOrderDetails(orderId);
            }
        }

        private void LoadOrderDetails(int orderId)
        {
            //product = _productService.GetProductById(productId);

            //if (product != null)
            //{
            //    lblProductName.Text = product.ProductName;
            //    lblPrice.Text = $"${product.Price:N2}";
            //    lblDescription.Text = product.ProductDescription ?? "No description available.";
            //}
            //else
            //{
            //    lblProductName.Text = "Product not found!";
            //    lblPrice.Text = "";
            //    lblDescription.Text = "";
            //}
        }
    }
}
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

        decimal totalOrderAmount = 0;


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
            List<OrderItem> orderItems = _orderItemService.GetOrderItems(orderId);
            if (orderItems.Count > 0)
            {
                CalculateTotalPrice(orderItems);
            }
            rptOrderItems.DataSource = orderItems;
            rptOrderItems.DataBind();

            List<Order> orders = new List<Order>();
            orders.Add(_orderService.GetOrderDetailsById(orderId, userId));

            rptOrderDetails.DataSource = orders;
            rptOrderDetails.DataBind();
        }

        private void CalculateTotalPrice(List<OrderItem> orderItems)
        {
            foreach (var item in orderItems)
            {
                totalOrderAmount += item.UnitPrice;
            }

            lblSubTotalAmount.Text = $"${totalOrderAmount:N2}";
            lblTotalAmount.Text = $"${totalOrderAmount:N2}";

        }
    }
}
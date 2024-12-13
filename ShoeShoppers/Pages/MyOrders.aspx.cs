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
    public partial class MyOrders : System.Web.UI.Page
    {

        private readonly OrderService _orderService;

        private readonly int userId;

        public MyOrders()
        {

            _orderService = new OrderService(new OrderRepository());

            userId = UserHelper.GetUserIdFromCookie();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindOrderData();
            }
        }

        private void BindOrderData()
        {
            List<Order> orderItems = _orderService.GetAllOrderByUserId(userId);

            if (orderItems.Count > 0)
            {
                emptyOrderDiv.Visible = false;
            }

            GridViewOrder.DataSource = orderItems;
            GridViewOrder.DataBind();
        }

        protected void GridViewOrder_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            int orderId = Convert.ToInt32(GridViewOrder.DataKeys[rowIndex].Value);

            if (e.CommandName == "ViewOrder")
            {
                Response.Redirect($"/my/invoice/{orderId}");
            }
            else if (e.CommandName == "CancelOrder")
            {
                _orderService.CancelOrder(orderId);
                Response.Redirect(Request.RawUrl);
            }            else if (e.CommandName == "ReOrder")
            {
                _orderService.ReOrder(orderId);
                Response.Redirect(Request.RawUrl);
            }
        }
    }
}
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

namespace ShoeShoppers.Pages.Admin.Orders
{
    public partial class Orders : System.Web.UI.Page
    {
        private readonly OrderService _orderService;
        private readonly int userId;

        public Orders()
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
            List<Order> orderItems = _orderService.GetAllOrders();

            if (orderItems.Count > 0)
            {
                emptyOrderDiv.Visible = false;
            }

            gvOrders.DataSource = orderItems;
            gvOrders.DataBind();
        }

        protected void GridViewOrder_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = Convert.ToInt32(e.CommandArgument);

            int orderId = Convert.ToInt32(gvOrders.DataKeys[rowIndex].Value);

            if (e.CommandName == "ViewOrder")
            {
                //GetOrderDetailsById( orderId);
                Response.Redirect($"/my/invoice/{orderId}");
            }
            else if (e.CommandName == "CancelOrder")
            {
                _orderService.CancelOrder(orderId);
                Response.Redirect(Request.RawUrl);
            }
            else if (e.CommandName == "ReOrder")
            {
                _orderService.ReOrder(orderId);
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void ddlShippingStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the row where the dropdown is located
            GridViewRow row = (sender as DropDownList).NamingContainer as GridViewRow;

            // Retrieve the Order ID (or any unique identifier) from the GridView
            int orderId = Convert.ToInt32(gvOrders.DataKeys[row.RowIndex].Value);

            // Get the selected shipping status
            DropDownList ddlShippingStatus = (DropDownList)row.FindControl("ddlShippingStatus");
            string newStatus = ddlShippingStatus.SelectedValue;

            // Update the shipping status in the database
            _orderService. UpdateShippingStatus(orderId, newStatus);

            // Optionally, rebind the GridView to reflect the updated data
            BindOrderData();
        }
    }
}
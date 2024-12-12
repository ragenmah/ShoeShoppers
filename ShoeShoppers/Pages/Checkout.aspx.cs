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
    public partial class Checkout : System.Web.UI.Page
    {
        private readonly int userId;
        private readonly CartService _cartService;
        private readonly UserService _userService;

        private readonly PaymentService _paymentService;
        private readonly OrderService _orderService;
        private readonly OrderItemsService _orderItemsService;

        decimal totalCartAmount = 0;

        public Checkout()
        {

            _cartService = new CartService(new CartRepository());
            _userService = new UserService(new UserRepository());
            _paymentService = new PaymentService(new PaymentRepository());
            _orderService = new OrderService(new OrderRepository());
            _orderItemsService = new OrderItemsService(new OrderItemRepository());

            userId = UserHelper.GetUserIdFromCookie();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCartData();
            }
        }

        private List<Cart> BindCartData()
        {
            List<Cart> cartItems = _cartService.GetAllCartItemsByUser(userId);
            if (cartItems.Count > 0)
            {


                CalculateTotalPrice(cartItems);

            }

            rptCart.DataSource = cartItems;
            rptCart.DataBind();

            return cartItems;
        }

        private void CalculateTotalPrice(List<Cart> cartItems)
        {
            foreach (var item in cartItems)
            {
                totalCartAmount += item.TotalPrice;
            }

            lblTotalAmount.Text = $"Total (After Discount): ${totalCartAmount:N2}";
        }

        protected void RepeaterCart_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int cartId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Update")
            {
                TextBox txtQuantity = (TextBox)e.Item.FindControl("txtQuantity");
                int newQuantity = int.Parse(txtQuantity.Text);

            }
            else if (e.CommandName == "Remove")
            {
                _cartService.DeleteCart(cartId);
            }


            BindCartData();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int paymentId = savePayment();
            updateUser();
            saveOrders(paymentId);
        }

        private void updateUser()
        {


            User user = new User
            {
                UserId = userId,
                FirstName = txtFirstName.Text.Trim(),
                LastName = txtLastName.Text.Trim(),
                Email= Request.Cookies["UserLogin"]["Email"],
                Address = txtShippingAddress.Text.Trim(),
                Country = txtCountry.Text.Trim(),
                City = txtCity.Text.Trim(),
                PostalCode = txtPostalCode.Text.Trim(),
                MobileNumber = txtPhoneNumber.Text.Trim(),
            };

            _userService.UpdateUser(user);

        }

        private int savePayment()
        {
            Payment payment = new Payment
            {
                PaymentMethod = ddlPaymentMethod.SelectedValue,
                OwnerName = txtOwnerName.Text.Trim(),
                CardNo = txtCardNo.Text.Trim(),
                ExpiryDate = txtExpiryDate.Text.Trim(),
                CvvNo = int.Parse(txtCvvNo.Text.Trim()),
                BillingAddress = txtBillingAddress.Text.Trim(),
            };

            return _paymentService.AddPayment(payment);
        }

        private void saveOrders(int paymentId)
        {
            if (paymentId > 0)
            {
                Order order = new Order
                {
                    OrderNumber = $"SN-ON-{userId}",
                    UserId = userId,
                    Status = "Pending",
                    PaymentId = paymentId,
                    IsCancelled = false
                };

                int orderId = _orderService.AddOrder(order);

                if (orderId > 0)
                {
                    foreach (var item in BindCartData())
                    {
                        OrderItem orderItem = new OrderItem {
                        OrderId=orderId,
                        ProductId=item.ProductId,
                        Quantity=item.Quantity,
                        UnitPrice=item.DiscountedPrice
                        };

                        _orderItemsService.AddOrderItems(orderItem);

                    }
                    _cartService.DeleteCartByUserId(userId);
                    Response.Redirect("/my/invoice");

                }
            }

        }
        protected void ddlPaymentMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            PaymentFormPanel.Visible = true;
        }
    }
}
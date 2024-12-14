<%@ Page Title="Checkout" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Checkout.aspx.cs" Inherits="ShoeShoppers.Pages.Checkout" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="m-5">
        <section id="place-order" class="container">
            <h2 class=" mb-4">Place Your Order</h2>

            <div class="card p-4 shadow-sm">


                <div class="row">

                    <div class="col-md-6">
                        <form id="form1" enctype="multipart/form-data">
                            <h5 class="mb-3">Delivery Details<span><hr />
                            </span></h5>
                            <div class="mb-3">
                                <asp:Label ID="lblFirstName" runat="server" Text="First Name:" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                <asp:TextBox ID="txtFirstName" runat="server" Width="100%" Height="35px" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator
                                    ID="rfvFirstName"
                                    runat="server"
                                    ControlToValidate="txtFirstName"
                                    ErrorMessage="First name is required."
                                    ForeColor="Red"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>

                            </div>
                            <div class="mb-3">
                                <asp:Label ID="lblLastName" runat="server" Text="Last Name:" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                <asp:TextBox ID="txtLastName" runat="server" Width="100%" Height="35px" CssClass="form-control"></asp:TextBox>

                                <asp:RequiredFieldValidator
                                    ID="RequiredFieldValidator1"
                                    runat="server"
                                    ControlToValidate="txtLastName"
                                    ErrorMessage="Last name is required."
                                    ForeColor="Red"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                            </div>

                            <%--<div class="mb-3">
                                <asp:Label ID="lblEmail" runat="server" Text="Email:" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" Height="35px" Width="100%" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator
                                    ID="rfvEmail"
                                    runat="server"
                                    ControlToValidate="txtEmail"
                                    ErrorMessage="Email is required."
                                    ForeColor="Red"
                                    Display="Dynamic">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Enter correct email address" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </div>--%>
                            <div class="mb-3">

                                <asp:Label ID="lblShippingAddress" runat="server" Text="Shipping address:" Font-Bold="true" Font-Size="Medium"></asp:Label>

                                <asp:TextBox ID="txtShippingAddress" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="mb-3">

                                <asp:Label ID="lblCountry" runat="server" Text="Country:" Font-Bold="true" Font-Size="Medium"></asp:Label>

                                <asp:TextBox ID="txtCountry" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <asp:Label ID="lblCity" runat="server" Text="City:" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                <asp:TextBox ID="txtCity" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <asp:Label ID="lblPostalCode" runat="server" Text="Postal code:" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                <asp:TextBox ID="txtPostalCode" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <asp:Label ID="lblPhoneNumber" runat="server" Text="Phone number:" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                <asp:TextBox ID="txtPhoneNumber" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="payment">
                                <h5 class="mb-3 ">Payment Details<span><hr />
                                </span></h5>
                                <div class="mb-3">
                                    <asp:Label ID="lblPaymentMethod" runat="server" Text="Payment Method:" Font-Bold="true" Font-Size="Medium"></asp:Label>

                                    <asp:DropDownList ID="ddlPaymentMethod" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPaymentMethod_SelectedIndexChanged">
                                        <asp:ListItem Text="-- Select Payment Method --" Value="" />
                                        <asp:ListItem Text="Credit Card" Value="Credit Card" />
                                        <asp:ListItem Text="PayPal" Value="PayPal" />
                                        <asp:ListItem Text="Bank Transfer" Value="Bank Transfer" />
                                        <asp:ListItem Text="Cash on Delivery" Value="Cash on Delivery" />
                                    </asp:DropDownList>
                                </div>

                                <asp:Panel ID="PaymentFormPanel" runat="server" CssClass="payment-form" Visible="false">
                                    <div class="form-group mb-3">
                                        <asp:Label ID="Label2" runat="server" Text="Owner Name:" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                        <asp:TextBox ID="txtOwnerName" runat="server" CssClass="form-control" MaxLength="50" />
                                    </div>
                                    <div class="form-group mb-3">
                                        <asp:Label ID="Label3" runat="server" Text="Card Number:" Font-Bold="true" Font-Size="Medium"></asp:Label>

                                        <asp:TextBox ID="txtCardNo" runat="server" CssClass="form-control" MaxLength="50" />
                                    </div>
                                    <div class="form-group mb-3">
                                        <asp:Label ID="Label4" runat="server" Text="Expiry Date:" Font-Bold="true" Font-Size="Medium"></asp:Label>

                                        <asp:TextBox ID="txtExpiryDate" runat="server" CssClass="form-control" Placeholder="MM/YY" MaxLength="5" />
                                    </div>
                                    <div class="form-group mb-3">
                                        <asp:Label ID="Label5" runat="server" Text="CVV:" Font-Bold="true" Font-Size="Medium"></asp:Label>

                                        <asp:TextBox ID="txtCvvNo" runat="server" CssClass="form-control" MaxLength="3" TextMode="Number" />
                                    </div>
                                    <div class="form-group mb-3">
                                        <asp:Label ID="Label6" runat="server" Text="Billing Address:" Font-Bold="true" Font-Size="Medium"></asp:Label>

                                        <asp:TextBox ID="txtBillingAddress" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
                                    </div>

                                    <div class="form-group mb-3">
                                    </div>
                                    <div class=" mt-4">
                                        <div class="d-flex">
                                            <div class="ms-auto">
                                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn custom-btn" Text="Place Order" OnClick="btnSubmit_Click" />

                                            </div>
                                        </div>

                                    </div>
                                </asp:Panel>
                            </div>
                        </form>
                    </div>

                    <!-- Right Column -->
                    <div class="col-md-6">
                        <h5 class="mb-3">Cart Summary<span><hr />
                        </span></h5>
                        <asp:Repeater ID="rptCart" runat="server" OnItemCommand="RepeaterCart_ItemCommand">
                            <ItemTemplate>
                                <div class="card mb-4 shadow-sm">
                                    <div class="row g-0 align-items-center">
                                        <div class="col-md-4">
                                            <img src='<%# Eval("ImageUrl") %>'
                                                alt="Product Image"
                                                class="img-fluid rounded-start"
                                                style="height: 120px; object-fit: cover;" runat="server" />
                                        </div>
                                        <div class="col-md-8">
                                            <div class="card-body">
                                                <h5 class="card-title">
                                                    <a href='<%# "/product/" + Eval("ProductId") %>'><%#  $"{Eval("ProductName")}" %></a>
                                                </h5>
                                                <p class="card-text">
                                                    <strong>Price:</strong> $<%# Eval("Price", "{0:N2}") %><br />
                                                    <strong>Discounted Price:</strong> $<%# Eval("DiscountedPrice", "{0:N2}") %>   (<%# Eval("DiscountPercentage") %>%)<br />
                                                    <strong>Total Price:</strong> <%# Eval("Quantity") %> x $<%# Eval("DiscountedPrice", "{0:N2}") %> = 
                                                    <span><b>$<%# Eval("TotalPrice", "{0:N2}") %></b></span>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                        <div class=" mt-4">
                            <div class="d-flex">
                                <div class=" card shadow-sm w-100 p-4">
                                    <div class="ms-auto">

                                        <asp:Label ID="lblTotalAmount" runat="server" CssClass="text-bold" Text="Sub Total (After Discount): $ 0.00" />
                                    </div>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>

            </div>

        </section>

    </div>
</asp:Content>

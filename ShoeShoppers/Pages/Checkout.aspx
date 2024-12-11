<%@ Page Title="Cart" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Checkout.aspx.cs" Inherits="ShoeShoppers.Pages.Checkout" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="m-5">
        <section id="place-order" class="container">
            <h2 class=" mb-4">Place Your Order</h2>

            <div class="card p-4 shadow-sm">

                <form id="form1" enctype="multipart/form-data">
                    <div class="row">

                        <div class="col-md-6">
                            <h5 class="mb-3">Delivery Details<span><hr /></span></h5>
                            <div class="mb-3">
                                <asp:Label ID="lblFirstName" runat="server" Text="First Name:" Font-Bold="true" Font-Size="Larger"></asp:Label>
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
                                <asp:Label ID="lblLastName" runat="server" Text="Last Name:" Font-Bold="true" Font-Size="Larger"></asp:Label>
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

                            <div class="mb-3">
                                <asp:Label ID="lblEmail" runat="server" Text="Email:" Font-Bold="true" Font-Size="Larger"></asp:Label>
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
                            </div>
                            <div class="mb-3">

                                <asp:Label ID="lblShippingAddress" runat="server" Text="Shipping address:" Font-Bold="true" Font-Size="Larger"></asp:Label>

                                <asp:TextBox ID="txtShippingAddress" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="mb-3">

                                <asp:Label ID="lblCountry" runat="server" Text="Country:" Font-Bold="true" Font-Size="Larger"></asp:Label>

                                <asp:TextBox ID="txtCountry" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <asp:Label ID="lblCity" runat="server" Text="City:" Font-Bold="true" Font-Size="Larger"></asp:Label>
                                <asp:TextBox ID="txtCity" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <asp:Label ID="lblPostalCode" runat="server" Text="Postal code:" Font-Bold="true" Font-Size="Larger"></asp:Label>
                                <asp:TextBox ID="txtPostalCode" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>

                            <h5 class="mb-3">Payment Details<span><hr /></span></h5>
                            <div class="mb-3">
                                <asp:DropDownList
                                    ID="ddlPaymentMethod"
                                    runat="server"
                                    CssClass="form-control">
                                </asp:DropDownList>
                            </div>

                            <asp:Panel ID="PaymentFormPanel" runat="server" CssClass="payment-form">
    <div class="form-group">
        <label for="txtOwnerName">Owner Name:</label>
        <asp:TextBox ID="txtOwnerName" runat="server" CssClass="form-control" MaxLength="50" />
    </div>
    <div class="form-group">
        <label for="txtCardNo">Card Number:</label>
        <asp:TextBox ID="txtCardNo" runat="server" CssClass="form-control" MaxLength="50" />
    </div>
    <div class="form-group">
        <label for="txtExpiryDate">Expiry Date:</label>
        <asp:TextBox ID="txtExpiryDate" runat="server" CssClass="form-control" Placeholder="MM/YY" MaxLength="5" />
    </div>
    <div class="form-group">
        <label for="txtCvvNo">CVV:</label>
        <asp:TextBox ID="txtCvvNo" runat="server" CssClass="form-control" MaxLength="3" TextMode="Number" />
    </div>
    <div class="form-group">
        <label for="txtBillingAddress">Billing Address:</label>
        <asp:TextBox ID="txtBillingAddress" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
    </div>
   
    <div class="form-group">
        <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Submit Payment" OnClick="btnSubmit_Click" />
    </div>
</asp:Panel>
                        </div>

                        <!-- Right Column -->
                        <div class="col-md-6">
                            <h5 class="mb-3">Cart Summary<span><hr /></span></h5>

                            <div class="mb-3">
                                <asp:Label ID="Label1" runat="server" Text="Postal code:" Font-Bold="true" Font-Size="Larger"></asp:Label>
                                <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class=" mt-4">
                                <%--    <asp:Button ID="btnSubmit" CssClass="btn btn-warning me-2" runat="server" Text="Add Product" OnClick="btnSubmit_Click" />
                     <asp:Button ID="btnAddProductImages" CssClass="btn btn-info me-2 " runat="server" Text="Add Product Images" OnClick="btnAddProductImages_Click" />
                     <asp:Button ID="btnCancel" CssClass="btn btn-secondary" runat="server" Text="Cancel" OnClick="btnCancel_Click" />--%>
                            </div>

                        </div>
                    </div>


                    <!-- Buttons -->

                </form>
            </div>

        </section>

    </div>
</asp:Content>

<%@ Page Title="Cart" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Checkout.aspx.cs" Inherits="ShoeShoppers.Pages.Checkout" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="m-5">
        <section id="place-order" class="container">
            <h2 class=" mb-4">Place Your Order</h2>

            <div class="card p-4 shadow-sm">

                <form id="form1" enctype="multipart/form-data">
                    <div class="row">

                        <div class="col-md-6">

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
                                <label for="txtDiscount" class="form-label">Discount Percentage:</label>
                                <asp:TextBox ID="txtDiscount" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label for="ddlCategory" class="form-label">Category:</label>
                                <asp:DropDownList ID="ddlCategory" CssClass="form-select" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                        <!-- Right Column -->
                        <div class="col-md-6">
                            <div class="mb-3">
                                <label for="txtStock" class="form-label">Stock Quantity:</label>
                                <asp:TextBox ID="txtStock" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label for="txtSize" class="form-label">Size:</label>
                                <asp:TextBox ID="txtSize" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <label for="txtColor" class="form-label">Color:</label>
                                <asp:TextBox ID="txtColor" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="mb-3">
                                <asp:Image ID="imgPreview" runat="server" CssClass="img-thumbnail" Width="150px" Height="150px" AlternateText="No Image Available" />
                            </div>
                            <div class="mb-3">
                                <label for="fileUpload" class="form-label">Upload Image:</label>
                                <asp:FileUpload ID="fileUpload" CssClass="form-control" runat="server" />
                            </div>
                            <div class="form-check mb-3">

                                <label for="chkIsActive" class="form-check-label">Is Active</label>
                                <asp:CheckBox ID="chkIsActive" runat="server" />
                            </div>
                            <asp:HiddenField ID="hfProductId" runat="server" />

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

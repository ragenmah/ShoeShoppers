<%@ Page Title="Cart" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MyAccount.aspx.cs" Inherits="ShoeShoppers.Pages.MyAccount" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="m-5">
        <section id="my-cart" class="container">
            <h2 class=" mb-4">My Account</h2>

            <div class="mt-4 row">

                <div class="sn-myac-sidebar col-md-4 col-12">
                    <div class="d-flex align-items-center mb-3">
                        <div class="me-3">
                            <asp:Label ID="lblUserIcon" runat="server" CssClass="rounded-circle bg-secondary d-flex justify-content-center align-items-center"
                                Style="width: 100px; height: 100px; color: white; font-size: 40px;">
                                <i class="fas fa-user"></i>
                            </asp:Label>
                        </div>
                        <div>
                            <h5>ragen</h5>
                            <p>ragenmah99@gmail.com</p>
                        </div>
                    </div>

                    <span><a class="btn custom-btn w-100 me-2" href="/my-orders">My Orders</a></span><span>
                        <a class="btn custom-btn w-100 mt-2" href="/my-cart">My Cart</a></span>
                </div>
                <div class="pt-5 col-md-8 col-12">
                    <h3>Update Profile</h3>
                  <asp:Panel ID="pnlUserForm" runat="server">
            
            <!-- First Name -->
            <div class="form-group mb-3">
                <asp:Label ID="lblFirstName" runat="server" AssociatedControlID="txtFirstName" ForeColor="Black">First Name</asp:Label>
                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control" Placeholder="Enter first name"></asp:TextBox>
            </div>

            <!-- Last Name -->
            <div class="form-group mb-3">
                <asp:Label ID="lblLastName" runat="server" AssociatedControlID="txtLastName"  ForeColor="Black">Last Name</asp:Label>
                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" Placeholder="Enter last name"></asp:TextBox>
            </div>

            <!-- Email -->
            <div class="form-group mb-3">
                <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail"  ForeColor="Black">Email</asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" Placeholder="Enter email" Enabled="false"></asp:TextBox>
            </div>

            <!-- Password -->
            <%--<div class="form-group mb-3">
                <asp:Label ID="lblPassword" runat="server" AssociatedControlID="txtPassword"  ForeColor="Black">Password</asp:Label>
                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Enter password"></asp:TextBox>
            </div>--%>

            <!-- Role ID -->
            <div class="form-group mb-3">
                <asp:Label ID="lblRoleId" runat="server" AssociatedControlID="ddlRoleId"  ForeColor="Black">Role</asp:Label>
                <asp:DropDownList ID="ddlRoleId" runat="server" CssClass="form-control">
                    <asp:ListItem Text="Select Role" Value="" />
                    <asp:ListItem Text="Admin" Value="1" />
                    <asp:ListItem Text="User" Value="2" />
                </asp:DropDownList>
            </div>

            <!-- Mobile Number -->
            <div class="form-group mb-3">
                <asp:Label ID="lblMobileNumber" runat="server" AssociatedControlID="txtMobileNumber"  ForeColor="Black">Mobile Number</asp:Label>
                <asp:TextBox ID="txtMobileNumber" runat="server" CssClass="form-control" Placeholder="Enter mobile number"></asp:TextBox>
            </div>

            <!-- Date of Birth -->
            <div class="form-group mb-3">
                <asp:Label ID="lblDateOfBirth" runat="server" AssociatedControlID="txtDateOfBirth"  ForeColor="Black">Date of Birth</asp:Label>
                <asp:TextBox ID="txtDateOfBirth" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
            </div>

            <!-- Address -->
            <div class="form-group mb-3">
                <asp:Label ID="lblAddress" runat="server" AssociatedControlID="txtAddress"  ForeColor="Black">Address</asp:Label>
                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" TextMode="MultiLine" Placeholder="Enter address"></asp:TextBox>
            </div>

            <!-- City -->
            <div class="form-group mb-3">
                <asp:Label ID="lblCity" runat="server" AssociatedControlID="txtCity"  ForeColor="Black">City</asp:Label>
                <asp:TextBox ID="txtCity" runat="server" CssClass="form-control" Placeholder="Enter city"></asp:TextBox>
            </div>

            <!-- Postal Code -->
            <div class="form-group mb-3">
                <asp:Label ID="lblPostalCode" runat="server" AssociatedControlID="txtPostalCode"  ForeColor="Black">Postal Code</asp:Label>
                <asp:TextBox ID="txtPostalCode" runat="server" CssClass="form-control" Placeholder="Enter postal code"></asp:TextBox>
            </div>

            <!-- Country -->
            <div class="form-group mb-3">
                <asp:Label ID="lblCountry" runat="server" AssociatedControlID="txtCountry"  ForeColor="Black">Country</asp:Label>
                <asp:TextBox ID="txtCountry" runat="server" CssClass="form-control" Placeholder="Enter country"></asp:TextBox>
            </div>

            <!-- Account Image -->
            <div class="form-group mb-3">
                <asp:Label ID="lblAccountImage" runat="server" AssociatedControlID="fileAccountImage"  ForeColor="Black">Account Image</asp:Label>
                <asp:FileUpload ID="fileAccountImage" runat="server" CssClass="form-control" />
            </div>

            <!-- Submit Button -->
            <div class="form-group mb-3">
                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary" Text="Submit" />
            </div>
        </asp:Panel>
                </div>
            </div> 
        </section>

    </div>
</asp:Content>

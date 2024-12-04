<%@ Page Title="Membership Registration" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Registration.aspx.cs" Inherits="ShoeShoppers.Pages.Registration" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-container">
        <div class="form">
            <form id="form1">
                <div>
                    <asp:Label ID="Label1" runat="server" Text="Member Register Form" Font-Size="XX-Large" Font-Bold="true" ForeColor="#9900CC"></asp:Label>
                </div>
                <div class="url-link">
                    Already have an account? <a href="/login">Login</a>
                </div>

                <%--<div>
                <asp:Label ID="Label2" runat="server" Text="Username:" Font-Bold="true" Font-Size="Larger"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" Height="35px" Width="100%"></asp:TextBox>
            </div>--%>

                <div>
                    <asp:Label ID="lblFullName" runat="server" Text="Full Name:" Font-Bold="true" Font-Size="Larger"></asp:Label>

                    <asp:TextBox ID="txtFullName" runat="server" TextMode="Password" Width="100%" Height="35px"></asp:TextBox>

                    <asp:RequiredFieldValidator
                        ID="rfvFullName"
                        runat="server"
                        ControlToValidate="txtFullName"
                        ErrorMessage="Fullname is required."
                        ForeColor="Red"
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>

                </div>
                <div>
                    <asp:Label ID="lblEmail" runat="server" Text="Email:" Font-Bold="true" Font-Size="Larger"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" Height="35px" Width="100%"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="rfvEmail"
                        runat="server"
                        ControlToValidate="txtEmail"
                        ErrorMessage="Password is required."
                        ForeColor="Red"
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>
                <div>
                    <asp:Label ID="lblPassword" runat="server" Text="Password: " Font-Bold="true" Font-Size="Larger"></asp:Label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="100%" Height="35px"></asp:TextBox>
                    <asp:RequiredFieldValidator
                        ID="rfvPassword"
                        runat="server"
                        ControlToValidate="txtPassword"
                        ErrorMessage="Password is required."
                        ForeColor="Red"
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>
                </div>

                <div>
                    <asp:Label ID="Label2" runat="server" Text="Re-enter Password: " Font-Bold="true" Font-Size="Larger"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" TextMode="Password" Width="100%" Height="35px"></asp:TextBox>
                </div>

                <%--<asp:Label ID="lblGender" runat="server" Text="Gender:" Font-Bold="true" Font-Size="Larger"></asp:Label>--%>

                <%-- <asp:DropDownList ID="ddlGender" runat="server" CssClass="styled-dropdown" Height="40px" Width="100%">
                <asp:ListItem Text="Select Gender" Value="" />
                <asp:ListItem Text="Male" Value="Male" />
                <asp:ListItem Text="Female" Value="Female" />
                <asp:ListItem Text="Other" Value="Other" />
            </asp:DropDownList>
            <div>
                <asp:Label ID="lblContactNumber" runat="server" Text="Contact Number:" Font-Bold="true" Font-Size="Larger"></asp:Label>
                <asp:TextBox ID="txtContactNumber" runat="server" TextMode="Password" Width="100%" Height="35px"></asp:TextBox>
            </div>--%>
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

                <div>
                    <asp:Button class="btn custom-btn btn-register" Font-Size="Large" ID="RegisterBtn" runat="server" Text="Register"
                        Height="40px" Width="90px" OnClick="RegisterBtn_Click" />
                    <%--<asp:Button CssClass="btn-cancel" ID="Button2" runat="server" Font-Size="Large" Text="Cancel" ForeColor="White" BackColor="Red" Height="40px" Width="90px" />--%>
                </div>
            </form>
        </div>
    </div>
</asp:Content>

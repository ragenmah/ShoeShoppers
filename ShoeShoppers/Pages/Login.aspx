<%@ Page Title="Login" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Login.aspx.cs" Inherits="ShoeShoppers.Pages.Login" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-container">
        <div class="form">
            <form id="form1">
                <div>
                    <asp:Label ID="Label1" runat="server" Text="Login Form" Font-Size="XX-Large" Font-Bold="true" ForeColor="#9900CC"></asp:Label>
                </div>
                <div class="url-link">
                    Need a Membership account? <a href="registration">Create an account</a>
                </div>
                <div>
                    <asp:Label ID="lblEmail" runat="server" Text="Email:" Font-Bold="true" Font-Size="Larger"></asp:Label>
                    <asp:TextBox ID="txtEmail" runat="server" TextMode="Email" Height="35px" Width="100%"></asp:TextBox>
                </div>
                <div>
                    <div style="display: flex; align-items: center; justify-content: space-between">
                        <asp:Label ID="lblPassword" runat="server" Text="Password: " Font-Bold="true" Font-Size="Larger"></asp:Label>
                        <label style="display: flex; align-items: center;">
                            <input type="checkbox" id="showPassword" onclick="document.getElementById('txtPassword').type = this.checked ? 'text' : 'password'" />
                            <span style="margin-left: 5px;">Show Password</span>
                        </label>
                    </div>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="100%" Height="35px" ClientIDMode="Static"></asp:TextBox>
                </div>
                <label style="display: flex; align-items: center;">
                    <asp:CheckBox CssClass="checkbox" runat="server" ID="chkRememberMe" />
                    <span style="margin-left: 5px;">Keep me logged in</span>
                </label>

                <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>

                <div>
                    <asp:Button class="btn custom-btn mt-3" Font-Size="Large" ID="LoginBtn" runat="server" Text="Login"
                        Height="40px" Width="90px" OnClick="LoginBtn_Click" />
                </div>
            </form>
        </div>

    </div>
</asp:Content>

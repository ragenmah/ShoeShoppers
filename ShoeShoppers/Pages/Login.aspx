﻿<%@ Page Title="Login" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ShoeShoppers.Login" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="~/Content/css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="form-container">

        <form id="form1" runat="server" class="form">
            <div>
                <asp:Label ID="Label1" runat="server" Text="Login Form" Font-Size="XX-Large" Font-Bold="true" ForeColor="#9900CC"></asp:Label>
            </div>
            <div class="url-link">
                Need a Membership account? <a href="registration">Create an account</a>
            </div>

            <div>
                <asp:Label ID="Label2" runat="server" Text="Email:" Font-Bold="true" Font-Size="Larger"></asp:Label>
                <asp:TextBox ID="TextBoxEmail" runat="server" TextMode="Email" Height="35px" Width="100%"></asp:TextBox>
            </div>
            <div>
                <div style="display: flex; align-items: center; justify-content:space-between">
                    <asp:Label ID="Label3" runat="server" Text="Password: " Font-Bold="true" Font-Size="Larger"></asp:Label>
                    <label style="display: flex; align-items: center;">
                        <input type="checkbox" id="showPassword" onclick="document.getElementById('textBoxPassword').type=this.checked? 'text': 'password'" />
                        <span style="margin-left: 5px;">Show Password</span>
                    </label>
                </div>
                <asp:TextBox ID="textBoxPassword" runat="server" TextMode="Password" Width="100%" Height="35px"></asp:TextBox>
            </div>
            <input class="checkbox" type="checkbox" />
            Keep me logged in
            <div>
                <asp:Button class="btn-common btn-login" Font-Size="Large" ID="LoginBtn" runat="server" Text="Login"
                    Height="40px" Width="90px" OnClick="LoginBtn_Click" />
                <%--<asp:Button CssClass="btn-cancel" ID="Button2" runat="server" Font-Size="Large" Text="Cancel" ForeColor="White" BackColor="Red" Height="40px" Width="90px" />--%>
            </div>
        </form>
    </div>
</body>
</html>

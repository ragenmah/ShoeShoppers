﻿<%@ Page Title="Membership Registration" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ShoeShoppers.Login" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="~/favicon.ico" rel="shortcut icon" type="image/x-icon" />
    <link href="~/Content/css/main.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <div class="login">

        <form id="form1" runat="server" class="form">
            <div>
                <asp:Label ID="Label1" runat="server" Text="Member Register Form" Font-Size="XX-Large" Font-Bold="true" ForeColor="#9900CC"></asp:Label>
            </div>
            <div class="url-link">
                Already have an account? <a href="/">Login</a>
            </div>

            <div>
                <asp:Label ID="Label2" runat="server" Text="Email:" Font-Bold="true" Font-Size="Larger"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" Height="35px" Width="100%"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label3" runat="server" Text="Password: " Font-Bold="true" Font-Size="Larger"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Width="100%" Height="35px"></asp:TextBox>
            </div>
            
            <div>
                <asp:Button CssClass="btn-register" Font-Size="Large" ID="Button1" runat="server" Text="Register"
                    Height="40px" Width="90px" />
                <%--<asp:Button CssClass="btn-cancel" ID="Button2" runat="server" Font-Size="Large" Text="Cancel" ForeColor="White" BackColor="Red" Height="40px" Width="90px" />--%>
            </div>
        </form>
    </div>
</body>
</html>

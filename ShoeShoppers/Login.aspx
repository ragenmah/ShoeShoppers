<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ShoeShoppers.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <style>
        body {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
            background-color: #f5f5f5;
            font-family: Arial, sans-serif;
        }

        form {
            background: #ffffff;
            padding: 20px 30px;
            border-radius: 8px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            width: 90%;
            max-width: 400px;
        }

        form div {
            margin-bottom: 15px;
        }

        .btn-login,
        .btn-cancel {
            display: inline-block;
            text-align: center;
            cursor: pointer;
            border: none;
            border-radius: 5px;
            transition: all 0.3s ease;
        }

        .btn-login:hover {
            background-color: #28a745;
        }

        .btn-cancel:hover {
            background-color: darkred;
        }

        .checkbox {
            margin: 10px 0;
        }
    </style>
</head>
<body>
     <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="Login Form" Font-Size="XX-Large" Font-Bold="true" ForeColor="#9900CC"></asp:Label>
        </div>
        <div>
            <asp:Label ID="Label2" runat="server" Text="Username:" Font-Bold="true" Font-Size="Larger"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" Height="35px" Width="100%"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="Label3" runat="server" Text="Password: " Font-Bold="true" Font-Size="Larger"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Width="100%" Height="35px"></asp:TextBox>
        </div>
        <input class="checkbox" type="checkbox" onchange="document.getElementById('TextBox2').type=this.checked? 'text': 'password'" /> Show Password
        <div>
            <asp:Button CssClass="btn-login" Font-Size="Large" ID="Button1" runat="server" Text="Login" ForeColor="White" BackColor="#33CC33" Height="40px" Width="90px" />
            <asp:Button CssClass="btn-cancel" ID="Button2" runat="server" Font-Size="Large" Text="Cancel" ForeColor="White" BackColor="Red" Height="40px" Width="90px" />
        </div>
    </form>
</body>
</html>

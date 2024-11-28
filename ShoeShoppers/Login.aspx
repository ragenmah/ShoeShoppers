<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ShoeShoppers.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style>
        :root {
            --primary-color: #33CC33; 
            --secondary-color: #FF5733;
            --text-color: #9900CC; 
            --background-color: #f5f5f5;
            --form-color: #ffffff;
        }
        * {
            /*    box-sizing: border-box;*/
            padding: 0;
            margin: 0;
            font-family: Arial, sans-serif;
        }

        .login {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
            background-color:var(--background-color);
       
        }

        .form {
            background: var(--form-color);
            padding: 20px 30px;
            border-radius: 8px;
            box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
            width: 90%;
            max-width: 400px;
        }

            .form div {
                margin-bottom: 15px;
            }
          label {
            color: var(--text-color);
            font-weight: bold;
        }

        .btn-login {
            display: inline-block;
            align-content: center;
            text-align: center;
            cursor: pointer;
            border: none;
            border-radius: 5px;
            transition: all 0.3s ease;
            color: white;
             background-color: var(--primary-color);
            margin-top: 15px;
        }

       

            .btn-login:hover {
            background-color: darkgreen;
        }

          

        .register-link {
            display: block;
            margin-top: 15px;
            font-size: 14px;
        }

            .register-link a {
                text-decoration: none;
                color: #007bff;
                font-weight: bold;
                transition: color 0.3s ease;
            }

                .register-link a:hover {
                    color: #0056b3;
                }
    </style>
</head>
<body>
    <div class="login">

        <form id="form1" runat="server" class="form">
            <div>
                <asp:Label ID="Label1" runat="server" Text="Login Form" Font-Size="XX-Large" Font-Bold="true" ForeColor="#9900CC"></asp:Label>
            </div>
            <div class="register-link">
                Need a Membership account? <a href="register.aspx">Create an account</a>
            </div>

            <div>
                <asp:Label ID="Label2" runat="server" Text="Email:" Font-Bold="true" Font-Size="Larger"></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" Height="35px" Width="100%"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label3" runat="server" Text="Password: " Font-Bold="true" Font-Size="Larger"></asp:Label>
                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Width="100%" Height="35px"></asp:TextBox>
            </div>
                <input class="checkbox" type="checkbox" onchange="document.getElementById('TextBox2').type=this.checked? 'text': 'password'" /> Keep me logged in
            <div>
                <asp:Button CssClass="btn-login" Font-Size="Large" ID="Button1" runat="server" Text="Login"
                     Height="40px" Width="90px" />
                <%--<asp:Button CssClass="btn-cancel" ID="Button2" runat="server" Font-Size="Large" Text="Cancel" ForeColor="White" BackColor="Red" Height="40px" Width="90px" />--%>
            </div>
        </form>
    </div>
</body>
</html>

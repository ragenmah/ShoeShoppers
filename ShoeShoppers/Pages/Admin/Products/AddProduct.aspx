<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/Admin/Admin.Master" CodeBehind="AddProduct.aspx.cs" Inherits="ShoeShoppers.Pages.Admin.Products.AddProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="AdminDashboardContentPlaceHolder" runat="server">
    <form id="form1" >
       <h1>Add New Product</h1>
    <asp:TextBox ID="txtName" runat="server" Placeholder="Name" />
    <asp:TextBox ID="txtPrice" runat="server" Placeholder="Price" />
    <asp:TextBox ID="txtDescription" runat="server" Placeholder="Description" />
    <asp:TextBox ID="txtStock" runat="server" Placeholder="Stock" />
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
    </form>
    </asp:Content>
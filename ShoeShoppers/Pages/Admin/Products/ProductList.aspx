﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/Admin/Admin.Master" CodeBehind="ProductList.aspx.cs" Inherits="ShoeShoppers.Pages.Admin.Products.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminDashboardContentPlaceHolder" runat="server">
    <h1>Your Products</h1>
    <asp:Label ID="lblWelcome" runat="server" Text="">List of products</asp:Label>

    <div class="form-container">
        <a href="/add-product">Add New Product</a>
        <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CssClass="table table-bordered table-striped  table-hover">
            <Columns>
                <asp:BoundField DataField="ProductId" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="ProductName" HeaderText="Name" />
                <asp:BoundField DataField="CategoryName" HeaderText="Category" />

                <asp:BoundField DataField="Price" HeaderText="Price" />
                <asp:BoundField DataField="DiscountedPrice" HeaderText="Discounted Price" />

                <asp:CommandField HeaderText="Action" ShowEditButton="true" ShowDeleteButton="true" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

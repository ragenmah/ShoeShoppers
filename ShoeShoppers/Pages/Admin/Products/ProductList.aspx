<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/Admin/Admin.Master" CodeBehind="ProductList.aspx.cs" Inherits="ShoeShoppers.Pages.Admin.Products.ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminDashboardContentPlaceHolder" runat="server">
    <h1>Your Products</h1>
    <asp:Label ID="lblWelcome" runat="server" Text="">List of products</asp:Label>

    <div class="form-container">
        <a href="/add-product">Add New Product</a>
        <asp:GridView ID="gvProducts" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductId" OnRowCommand="GridView1_RowCommand" OnRowDeleting="gvProducts_RowDeleting" CssClass="table table-bordered table-striped  table-hover">
            <Columns>
                <asp:BoundField DataField="ProductId" HeaderText="ID" ReadOnly="True" />
                <asp:TemplateField HeaderText="Image">
                    <ItemTemplate>
                        <asp:Image ID="imgCategory" runat="server" ImageUrl='<%# Eval("ImageUrl") %>'
                            Width="32px" Height="32px" AlternateText="No Image Available" />

                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ProductName" HeaderText="Name" />
                <asp:BoundField DataField="CategoryName" HeaderText="Category" />
                <asp:BoundField DataField="Price" HeaderText="Price" />
                <asp:TemplateField HeaderText="Discounted Price (%)">
                    <ItemTemplate>
                        <%# Eval("DiscountedPrice") %> <span>(<%# Eval("DiscountPercentage") %>%)</span>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:Button ID="btnEdit" runat="server" CommandName="Edit" CommandArgument="<%# Container.DataItemIndex %>" Text="Edit" />
                        <asp:Button ID="btnDelete" runat="server" CommandName="Delete" CommandArgument="<%# Container.DataItemIndex %>" Text="Delete" />
                                                <asp:Button ID="btnImage" runat="server" CommandName="ImageClick" CommandArgument="<%# Container.DataItemIndex %>"  Text="Images" />

                        <%--<asp:ImageButton ID="btnImage" runat="server"
                            ImageUrl='~/Assets/Icons/add-product.png'
                            Width="32px" Height="32px" AlternateText="Product Images"
                            CommandName="ImageClick" CommandArgument='<%# Container.DataItemIndex %>' />--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--                <asp:CommandField HeaderText="Action" ShowEditButton="true" ShowDeleteButton="true" />--%>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>

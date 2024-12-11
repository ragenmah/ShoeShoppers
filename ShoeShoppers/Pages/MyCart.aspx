<%@ Page Title="Cart" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MyCart.aspx.cs" Inherits="ShoeShoppers.Pages.MyCart" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="m-5">
        <section id="my-cart" class="container">
            <h2 class=" mb-4">Your cart</h2>

            <div class="text-center mt-5" style="height: 50vh" id="emptyCartDiv" runat="server">
                <img src="/Assets/Icons/trolley.png" height="120" width="120" />
                <p>Your cart is empty.</p>

                <a href="/products" class="btn custom-btn">Explore more</a>
            </div>
            <div>
                <asp:GridView ID="GridViewCart" runat="server" AutoGenerateColumns="False" OnRowCommand="GridViewCart_RowCommand" CssClass="table table-bordered table-striped  table-hover">
                    <Columns>
                        <asp:BoundField DataField="CartId" HeaderText="Cart ID" />
                        <asp:BoundField DataField="ProductId" HeaderText="Product ID" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                        <asp:BoundField DataField="UserId" HeaderText="User ID" />
                        <asp:BoundField DataField="CreatedAt" HeaderText="Created At" />
                        <asp:ButtonField CommandName="EditRow" Text="Edit" />
                        <asp:ButtonField CommandName="DeleteRow" Text="Delete" />
                    </Columns>
                </asp:GridView>

                <asp:TextBox ID="TxtCartId" runat="server" Placeholder="Cart ID"></asp:TextBox>
                <asp:TextBox ID="TxtProductId" runat="server" Placeholder="Product ID"></asp:TextBox>
                <asp:TextBox ID="TxtQuantity" runat="server" Placeholder="Quantity"></asp:TextBox>
                <asp:TextBox ID="TxtUserId" runat="server" Placeholder="User ID"></asp:TextBox>

                <asp:Button ID="BtnAddToCart" runat="server" Text="Add" OnClick="BtnAddToCart_Click" />
                <asp:Button ID="BtnUpdateCart" runat="server" Text="Update" OnClick="BtnUpdateCart_Click" />
                <asp:Button ID="BtnDeleteCart" runat="server" Text="Delete" OnClick="BtnDeleteCart_Click" />
            </div>

        </section>

    </div>
</asp:Content>

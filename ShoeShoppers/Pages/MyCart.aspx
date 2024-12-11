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
                        <asp:TemplateField HeaderText="Image">
                            <ItemTemplate>
                                <asp:Image ID="imgCategory" runat="server" ImageUrl='<%# Eval("ImageUrl") %>'
                                    Width="32px" Height="32px" AlternateText="No Image" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ProductName" HeaderText="Name" />
                        <asp:BoundField DataField="Quantity" HeaderText="Quantity" />

                        <asp:TemplateField HeaderText="Original Price">
                            <ItemTemplate>
                                $ <%#  $"{Eval( "Price"):N2}" %>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Discounted Price (%)">
                            <ItemTemplate>
                                $ <%#  $"{Eval( "DiscountedPrice"):N2}" %> <span>(<%# Eval("DiscountPercentage") %>%)</span>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Total Price">
                            <ItemTemplate>
                                $ <%#  $"{Eval( "TotalPrice"):N2}" %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:ButtonField CommandName="EditRow" Text="Edit" />
                        <asp:ButtonField CommandName="DeleteRow" Text="Delete" />
                    </Columns>
                </asp:GridView>



            </div>

        </section>

    </div>
</asp:Content>

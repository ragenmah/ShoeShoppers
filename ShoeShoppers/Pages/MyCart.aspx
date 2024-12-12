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
                <asp:GridView ID="GridViewCart" runat="server" DataKeyNames="CartId,ProductId"
                    AutoGenerateColumns="False"
                    OnRowDataBound="GridViewCart_RowDataBound"
                    OnRowCommand="GridViewCart_RowCommand"
                    CssClass="table table-bordered table-striped table-hover">


                    <Columns>
                        <asp:BoundField DataField="CartId" HeaderText="Cart ID" />
                        <asp:TemplateField HeaderText="Image">
                            <ItemTemplate>
                                <asp:Image ID="imgCategory" runat="server" ImageUrl='<%# Eval("ImageUrl") %>'
                                    Width="32px" Height="32px" AlternateText="No Image" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ProductId" HeaderText="Product ID" Visible="False" />
                         
                        <asp:TemplateField HeaderText="Name">
                            <ItemTemplate>
                                <a href='<%# "/product/" + Eval("ProductId") %>'><%#  $"{Eval( "ProductName")}" %></a>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Quantity">
                            <ItemTemplate>
                                <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Eval("Quantity") %>' TextMode="Number" OnTextChanged="QuantityChanged" AutoPostBack="True" CssClass="form-control" />
                                <asp:RangeValidator ID="rvQuantity" runat="server" 
                    ControlToValidate="txtQuantity" 
                    MinimumValue="1" 
                    MaximumValue=<%# Eval("StockQuantity") %> 
                    Type="Integer" 
                    ErrorMessage="Product unavailable" 
                    ForeColor="Red" />
                            </ItemTemplate>
                        </asp:TemplateField>
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


                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>
                                <asp:Button
                                    ID="btnDelete"
                                    runat="server"
                                    CommandName="DeleteRow"
                                    Text="Remove" CommandArgument="<%# Container.DataItemIndex %>"
                                    CssClass="btn btn-danger" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>


                </asp:GridView>

                <div class="my-5" id="totalAmountDiv" runat="server" visible="false">
                    <div class="d-flex">
                        <div class="ms-auto">
                            <asp:Label ID="lblTotalAmount" runat="server" CssClass="text-bold" Text="Total (After Discount): $ 0.00" />
                            <p><a class="btn custom-btn mt-3" href="my-cart/checkout">Checkout</a></p>
                        </div>
                    </div>
                </div>

            </div>

        </section>

    </div>
</asp:Content>

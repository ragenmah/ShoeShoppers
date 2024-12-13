<%@ Page Title="My Orders" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MyOrders.aspx.cs" Inherits="ShoeShoppers.Pages.MyOrders" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="m-5">
        <section id="my-orders" class="container">
            <h2 class=" mb-4">Your Orders</h2>

            <div class="text-center mt-5" style="height: 50vh" id="emptyOrderDiv" runat="server">
                <img src="/Assets/Icons/trolley.png" height="120" width="120" />
                <p>Your orders are empty.</p>

                <a href="/products" class="btn custom-btn">Explore more</a>
            </div>
            <div>
                <asp:GridView ID="GridViewOrder" runat="server" DataKeyNames="OrderId"
                    AutoGenerateColumns="False"
                    OnRowCommand="GridViewOrder_RowCommand"
                    CssClass="table table-bordered table-striped table-hover my-5">


                    <Columns>
                        <asp:BoundField DataField="OrderId" HeaderText="Order ID" />

                        <asp:BoundField DataField="OrderNumber" HeaderText="Order Number" Visible="True" />

                        <asp:TemplateField HeaderText="Payment Method">
                            <ItemTemplate>
                                <p><%# Eval("Payment.PaymentMethod") %></p>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Payment Status">
                            <ItemTemplate>
                                <p><%# Eval("Payment.PaymentMethod")=="Cash on Delivery"? "Unpaid":"Paid" %></p>

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Shipping status">
                            <ItemTemplate>
                                <%# Eval("Status") %>
                            </ItemTemplate>
                        </asp:TemplateField>


                        <asp:TemplateField HeaderText="Total Price">
                            <ItemTemplate>
                                $ <%#  $"{Eval( "TotalOrderPrice"):N2}" %>
                            </ItemTemplate>
                        </asp:TemplateField>

                                                <asp:BoundField DataField="OrderDate" HeaderText="Order Date" Visible="True" />

                        <asp:TemplateField HeaderText="Action">
                            <ItemTemplate>

                                <asp:Button
                                    ID="btnCancelOrder"
                                    runat="server"
                                    Text="Cancel Order"
                                    CssClass="btn btn-danger"
                                    CommandName="CancelOrder"
                                    CommandArgument="<%# Container.DataItemIndex %>"
                                    Visible='<%# !(bool)Eval("IsCancelled") %>' />


                                <asp:Button
                                    ID="btnReOrder"
                                    runat="server"
                                    Text="ReOrder"
                                    CssClass="btn btn-primary"
                                    CommandName="ReOrder"
                                    CommandArgument="<%# Container.DataItemIndex %>" Visible='<%# (bool)Eval("IsCancelled") %>' />

                                <asp:Button
                                    ID="btnView"
                                    runat="server"
                                    CommandName="ViewOrder"
                                    Text="View" CommandArgument="<%# Container.DataItemIndex %>"
                                    CssClass="btn btn-warning" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>


                </asp:GridView>



            </div>

        </section>

    </div>
</asp:Content>

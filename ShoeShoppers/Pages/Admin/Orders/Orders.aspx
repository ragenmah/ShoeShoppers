
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/Admin/Admin.Master"CodeBehind="Orders.aspx.cs" Inherits="ShoeShoppers.Pages.Admin.Orders.Orders"%>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminDashboardContentPlaceHolder" runat="server">
    <h1>Orders</h1>
    <asp:Label ID="lblWelcome" runat="server" Text="">List of orders</asp:Label>

    <div class="form-container">
         <div class="text-center mt-5" style="height: 50vh" id="emptyOrderDiv" runat="server">
     <img src="/Assets/Icons/trolley.png" height="120" width="120" />
     <p> Orders are empty.</p>

 </div>
        <asp:GridView ID="gvOrders" runat="server" DataKeyNames="OrderId"
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
                          <asp:DropDownList 
            ID="ddlShippingStatus" 
            runat="server" 
            CssClass="btn custom-btn text-start" 
            AutoPostBack="true" 
            SelectedValue='<%# Eval("Status") %>' 
            OnSelectedIndexChanged="ddlShippingStatus_SelectedIndexChanged">
            <asp:ListItem Text="Pending" Value="Pending" />
            <asp:ListItem Text="Shipped" Value="Shipped" />
            <asp:ListItem Text="Completed" Value="Completed" />
            <asp:ListItem Text="Cancelled" Value="Cancelled" />
        </asp:DropDownList>
            </ItemTemplate>
        </asp:TemplateField>


        <asp:TemplateField HeaderText="Ordered By">
            <ItemTemplate>
                <%#  $"{Eval( "User.FirstName")} {Eval( "User.LastName")}" %>
            </ItemTemplate>
        </asp:TemplateField>

                                <asp:BoundField DataField="OrderDate" HeaderText="Order Date" Visible="True" />
            <asp:TemplateField HeaderText="Order Status">
        <ItemTemplate>
            <%# Eval("Status") %>
        </ItemTemplate>
    </asp:TemplateField>
        <asp:TemplateField HeaderText="Action">
            <ItemTemplate>

                <%--<asp:Button
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
                    CommandArgument="<%# Container.DataItemIndex %>" Visible='<%# (bool)Eval("IsCancelled") %>' />--%>

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
    
</asp:Content>

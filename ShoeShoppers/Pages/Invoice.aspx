<%@ Page Title="Invoice" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Invoice.aspx.cs" Inherits="ShoeShoppers.Pages.Invoice" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-5">

        <div class="btn-group">
            <button class="btn custom-btn" onclick="printInvoice();">Print Invoice</button>
        </div>
       
                <div class="d-block ">
                    <div class="print-content">
                         <asp:Repeater ID="rptOrderDetails" runat="server">
                            <ItemTemplate>
                                <div class="sn-invoice-header mb-3">
                                    <h1 class="text-bold text-center">Order Invoice #<%# Eval("OrderNumber") %> <span class="bg-success d-inline-block badge bg-primary" style="font-size: 20px;"><%# Eval("Status") %></span></h1>
                                </div>
                                <h3 class="text-bold">Customer Details</h3>
                                <hr>
                                <div class="row">
                                    <div class="col-md-6">
                                        <p>First Name: <%# Eval("User.FirstName") %></p>
                                        <p>Last Name: <%# Eval("User.LastName") %></p>
                                        <p>Email: <%# Eval("User.Email") %></p>
                                        <p>Payment Status: <%# Eval("Payment.PaymentMethod")=="Cash on Delivery"? "Unpaid":"Paid" %></p>
                                    </div>
                                    <div class="col-md-6">
                                        <p>Address: <%# Eval("User.Address") %></p>
                                        <p>City: <%# Eval("User.City") %></p>
                                        <p>ZIP Code: <%# Eval("User.PostalCode") %></p>
                                        <p>Payment Method: <%# Eval("Payment.PaymentMethod") %></p>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <h3 class="text-bold">Order Details</h3>
                        <hr>
                        <table class="table">
                            <thead>
                                <tr>
                                    <th>Product Name</th>
                                    <th>Unit Price</th>
                                    <th>Discount</th>


                                    <th>Quantity</th>
                                    <th>Subtotal</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:Repeater ID="rptOrderItems" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td><%# Eval("Product.ProductName") %></td>
                                            <td>$ <%#$"{Eval( "UnitPrice"):N2}"%></td>
                                            <td><%# Eval("Product.DiscountPercentage") %>%</td>
                                            <td><%# Eval("Quantity") %></td>
                                            <td>$<%# String.Format("{0:N2}", Convert.ToDecimal(Eval("Quantity")) * Convert.ToDecimal(Eval("UnitPrice"))) %></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </tbody>
                            <tfoot>

                                <tr>
                                    <th></th>
                                    <th colspan="3">Sub Total: </th>
                                    <th>
                                        <asp:Label ID="lblSubTotalAmount" runat="server" Text="$ 0" CssClass="strong"></asp:Label></th>

                                </tr>
                                <tr>
                                    <th></th>
                                    <th colspan="3">Shipping Charge: </th>
                                    <th>
                                        <asp:Label ID="lblShippingCharge" runat="server" Text="$ 0" CssClass="strong"></asp:Label></th>
                                </tr>
                                <tr>
                                    <th></th>
                                    <th colspan="3">Total: </th>
                                    <th>
                                        <asp:Label ID="lblTotalAmount" runat="server" Text="$ 0" CssClass="strong"></asp:Label></th>
                                </tr>
                            </tfoot>
                        </table>
                    </div>
                </div>
          
    </div>


    <script>
        function printInvoice() {
            // Hide all content except the print content
            var originalContent = document.body.innerHTML;  // Save the original body content
            var printContent = document.querySelector('.print-content').innerHTML; // Get the content to print
            document.body.innerHTML = printContent;  // Replace the body content with the print content

            window.print();  // Trigger the print dialog

            // Restore the original content after printing
            document.body.innerHTML = originalContent;
        }
</script>
</asp:Content>

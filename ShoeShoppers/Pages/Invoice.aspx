<%@ Page Title="Invoice" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Invoice.aspx.cs" Inherits="ShoeShoppers.Pages.Invoice" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container mt-5">
       
        <div class="btn-group">
            <button class="btn btn-primary" onclick="printInvoice();">Print Invoice</button></div>
        <div class="d-block ">
            <div class="print-content">
                <div class="sn-invoice-header mb-3">
                    <h1 class="text-bold text-center">Order Invoice #SN108 <span class="bg-success d-inline-block badge bg-primary" style="font-size: 20px;">new</span></h1>
                </div>
                <h3 class="text-bold">Customer Details</h3>
                <hr>
                <div class="row">
                    <div class="col-md-6">
                        <p>First Name: </p>
                        <p>Last Name: test</p>
                        <p>Email: test@231.com</p>
                        <p>Payment Status: unpaid</p>
                    </div>
                    <div class="col-md-6">
                        <p>Address: test</p>
                        <p>City: test</p>
                        <p>ZIP Code: 40202</p>
                        <p>Payment Method: cod</p>
                    </div>
                </div>
                <h3 class="text-bold">Order Details</h3>
                <hr>
                <table class="table">
                    <thead>
                        <tr>
                            <th>Product Name</th>
                            <th>Original Price</th>
                            <th>Discount</th>
                            <th>Quantity</th>
                            <th>Subtotal</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>Iconic – Ceiling Lamp</td>
                            <td>UGX 55000.00</td>
                            <td>0.00%</td>
                            <td>1</td>
                            <td>UGX 55000.00</td>
                        </tr>
                    </tbody>
                    <tfoot>
                        <tr>
                            <th></th>
                            <th colspan="3">Coupon Code:</th>
                            <th></th>
                        </tr>
                        <tr>
                            <th></th>
                            <th colspan="3">Coupon Discount:</th>
                            <th>%</th>
                        </tr>
                        <tr>
                            <th></th>
                            <th colspan="3">Sub Total: </th>
                            <th><strong>UGX 55000.00</strong></th>
                        </tr>
                        <tr>
                            <th></th>
                            <th colspan="3">Shipping Charge: </th>
                            <th><strong>UGX 200</strong></th>
                        </tr>
                        <tr>
                            <th></th>
                            <th colspan="3">Total: </th>
                            <th><strong>UGX 55200.00</strong></th>
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

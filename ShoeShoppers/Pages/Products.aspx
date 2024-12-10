<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="ShoeShoppers.Pages.Products" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="m-5">
       <section id="products" class="container">

    <h2 class=" mb-4">Our Products</h2>


    <div class=" row">

          <asp:Repeater ID="rptProducts" runat="server">
    <ItemTemplate>
        <div class="col-md-3 col-sm-6 col-6">
            <span>
                <a class="card product-card" href='<%# "/product/" + Eval("ProductId") %>'>
                    <div class="card-img">
                         <asp:Image ID="imgCategory" runat="server" ImageUrl='<%# Eval("ImageUrl") %>'
      AlternateText='<%# Eval("ProductName") %>' />
                    </div>
                    <div class="card-body">
                        <h5 class="card-title"><%# Eval("ProductName") %></h5>
                        <div class="d-block d-md-flex justify-content-between">
                            <span class="text-muted">$<%# Eval("Price") %></span>
                        </div>
                    </div>
                </a>
            </span>
        </div>
    </ItemTemplate>
</asp:Repeater>
        

    </div>

</section>
    </div>


   
</asp:Content>

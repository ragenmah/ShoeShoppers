<%@ Page Title="Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="ShoeShoppers.Pages.Products" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="m-5">
       <section id="products" class="container">

    <h2 class=" mb-4 d-flex justify-content-between">Our Products

        <div class="mb-3">
   
    <asp:DropDownList ID="ddlCategory" CssClass="form-select" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
</div>
    </h2>


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

<asp:PlaceHolder ID="phOfferBadge" runat="server" Visible='<%# Convert.ToDouble(Eval("DiscountPercentage")) > 0 %>'>
    <div class="offer-badge"><%# Eval("DiscountPercentage", "{0:0.##}") %>% off</div>

</asp:PlaceHolder> 
                    <div class="wishlist-badge">
    <i class="fa fa-heart"></i>

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

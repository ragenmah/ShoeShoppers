
<%@ Page Title="Cart" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Cart.aspx.cs" Inherits="ShoeShoppers.Pages.Cart" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
     <div class="m-5" >
     <section id="my-cart" class="container">
         <h2 class=" mb-4">Your cart</h2>

      <div class="text-center mt-5" style="height:50vh"><img  src="/Assets/Icons/trolley.png" height="120" width="120"/> 
             <p>Your cart is empty.</p>

               <a href="/products" class="btn custom-btn">Explore more</a>
      </div>

     </section>
 </div>
</asp:Content>

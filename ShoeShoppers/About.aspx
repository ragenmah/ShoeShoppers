<%@ Page Title="About Us" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="ShoeShoppers.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="m-5" style="height: 75vh;">
        <section id="products" class="container">
            <h2 class=" mb-4">Simon Necktie.</h2>
            <p>Welcome to Simon Necktie, where we specialize in handcrafted leather shoes for men. Located in a popular shopping center, we are open daily from 10 AM to 8 PM. Today we have a lot of customers: the cool young technologists; very high on tech, both local and international - all value what good quality and style mean.</p>

            <p>To keep up with changing trends, we are excited to offer our products online, making it easier for you to shop and experience the premium quality of Simon Necktie shoes, wherever you are.</p>
           <p>Meet our team.</p>
            <div class="row text-center">
                <div class="col-md-3 mb-4">
                    <img src="/Assets/Images/owners/business-owner.jpg" alt="Owner" class="img-fluid rounded-rectangle" style="width: 256px; height: 256px;">
                    <h4 class="mt-3">Mr. Jimmy</h4>
                    <p>Owner of ShoeShoppers</p>
                </div>

                <div class="col-md-3 mb-4">
                    <img src="/Assets/Images/owners/operator.jpg" alt="Owner" class="img-fluid rounded-rectangle" style="width: 256px; height: 256px;">
                    <h4 class="mt-3">David Simon</h4>
                    <p>Operations Manager</p>
                </div>

                <div class="col-md-3 mb-4">
                    <img src="/Assets/Images/owners/designer.jpg" alt="Owner" class="img-fluid rounded-rectangle" style="width: 256px; height: 256px;">
                    <h4 class="mt-3">Emily Sam</h4>
                    <p>Lead Designer</p>
                </div>
            </div>
        </section>
    </div>
</asp:Content>

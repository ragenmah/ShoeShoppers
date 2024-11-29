<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ShoeShoppers._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
<section class="hero">
        <div>
            <h1>Welcome to YourBrand</h1>
            <p>Discover the best products and services tailored for you.</p>
            <a href="#services" class="btn btn-primary">Explore Now</a>
        </div>
    </section>

    <div class="container mt-5">
        <section id="products">
            <h2>Our Products</h2>
            <p>Browse through our exclusive collection of handmade footwear.</p>
        </section>
        <section id="about" class="mt-5">
            <h2>About Us</h2>
            <p>Learn more about our journey in crafting quality footwear.</p>
        </section>
        <section id="contact" class="mt-5">
            <h2>Contact</h2>
            <p>Get in touch with us for any queries or feedback.</p>
        </section>
    </div>

</asp:Content>

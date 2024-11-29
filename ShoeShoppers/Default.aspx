<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ShoeShoppers._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="hero">
        <div>
            <h1>Welcome to ShoeShoppers</h1>
            <p>Discover the best products tailored for you.</p>
            <a href="#products" class="btn btn-primary">Explore Now</a>
        </div>
    </section>

    <div class="container m-5">
        <section id="products" class="container-fluid">

            <h2 class=" mb-4">Our Products</h2>
            <div class="row row-cols-1 row-cols-md-3 g-4">
                <!-- Shoe Item 1 -->
                <div class="col">
                    <div class="card h-100">
                        <img src="https://cdn.shopify.com/s/files/1/0283/3917/5496/files/the-article-parallax-image-desktop-origins-of-chelsea-boot-1.jpg" class="card-img-top" alt="Classic Leather Shoes">
                        <div class="card-body">
                            <h5 class="card-title">Classic Leather Shoes</h5>
                            <p class="card-text">Premium handmade leather shoes for a sophisticated look.</p>
                            <p class="text-muted">Price: $120</p>
                            <a href="#" class="btn btn-primary">View Details</a>
                        </div>
                    </div>
                </div>
                <!-- Shoe Item 2 -->
                <div class="col">
                    <div class="card h-100">
                        <img src="https://cdn.shopify.com/s/files/1/0283/3917/5496/files/the-article-parallax-image-desktop-origins-of-chelsea-boot-1.jpg" class="card-img-top" alt="Formal Black Shoes">
                        <div class="card-body">
                            <h5 class="card-title">Formal Black Shoes</h5>
                            <p class="card-text">Elegant black leather shoes suitable for office and events.</p>
                            <p class="text-muted">Price: $150</p>
                            <a href="#" class="btn btn-primary">View Details</a>
                        </div>
                    </div>
                </div>
                <!-- Shoe Item 3 -->
                <div class="col">
                    <div class="card h-100">
                        <img src="https://cdn.shopify.com/s/files/1/0283/3917/5496/files/the-article-parallax-image-desktop-origins-of-chelsea-boot-1.jpg" class="card-img-top" alt="Brown Casual Shoes">
                        <div class="card-body">
                            <h5 class="card-title">Brown Casual Shoes</h5>
                            <p class="card-text">Comfortable and stylish shoes perfect for daily wear.</p>
                            <p class="text-muted">Price: $100</p>
                            <a href="#" class="btn btn-primary">View Details</a>
                        </div>
                    </div>
                </div>
                <div class="col">
                    <div class="card h-100">
                        <img src="/images/shoe3.jpg" class="card-img-top" alt="Brown Casual Shoes">
                        <div class="card-body">
                            <h5 class="card-title">Brown Casual Shoes</h5>
                            <p class="card-text">Comfortable and stylish shoes perfect for daily wear.</p>
                            <p class="text-muted">Price: $100</p>
                            <a href="#" class="btn btn-primary">View Details</a>
                        </div>
                    </div>
                </div>
            </div>


        </section>
        <section id="about" class="mt-5">
            <h2>About Us</h2>
            <p></p>
        </section>
        <section id="contact" class="mt-5">
            <h2>Contact</h2>
            <p></p>
        </section>
    </div>

</asp:Content>

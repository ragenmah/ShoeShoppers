<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ShoeShoppers._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="hero">
        <div>
            <h1>Welcome to ShoeShoppers</h1>
            <p>Discover the best products tailored for you.</p>
            <a href="#products" class="btn custom-btn">Explore Now</a>
        </div>
    </section>

    <div class="m-5">
        <section id="products" class="container">

            <h2 class=" mb-4">Our Products</h2>


            <div class=" row">
                <div class="col-md-3 col-sm-6 col-6">
                    <span>
                        <a class="card product-card" href="/product/id">
                            <div class="card-img">
                                <img src="https://raw.githubusercontent.com/luisDanielRoviraContreras/img/master/files/1.png" class="card-img-top" alt="Iconic – Ceiling Lamp">
                            </div>
                            <div class="card-body">
                                <h5 class="card-title">Iconic – Ceiling Lamp</h5>
                                <div class="d-block d-md-flex justify-content-between"><span class="text-muted">$100</span></div>
                            </div>
                        </a>
                    </span>
                </div>
                <div class="col-md-3 col-sm-6 col-6">
                    <span>
                        <a class="card product-card" href="/product/id">
                            <div class="card-img">
                                <img src="https://raw.githubusercontent.com/luisDanielRoviraContreras/img/master/files/1.png" class="card-img-top" alt="Iconic – Ceiling Lamp">
                            </div>
                            <div class="card-body">
                                <h5 class="card-title">Iconic – Ceiling Lamp</h5>
                                <div class="d-block d-md-flex justify-content-between"><span class="text-muted">$100</span></div>
                            </div>
                        </a>
                    </span>
                </div>
                <div class="col-md-3 col-sm-6 col-6">
                    <span>
                        <a class="card product-card" href="/product/id">
                            <div class="card-img">
                                <img src="https://raw.githubusercontent.com/luisDanielRoviraContreras/img/master/files/1.png" class="card-img-top" alt="Iconic – Ceiling Lamp">
                            </div>
                            <div class="card-body">
                                <h5 class="card-title">Iconic – Ceiling Lamp</h5>
                                <div class="d-block d-md-flex justify-content-between"><span class="text-muted">$100</span></div>
                            </div>
                        </a>
                    </span>
                </div>
                <div class="col-md-3 col-sm-6 col-6">
                    <span>
                        <a class="card product-card" href="/product/id">
                            <div class="card-img">
                                <img src="https://raw.githubusercontent.com/luisDanielRoviraContreras/img/master/files/1.png" class="card-img-top" alt="Iconic – Ceiling Lamp">
                            </div>
                            <div class="card-body">
                                <h5 class="card-title">Iconic – Ceiling Lamp</h5>
                                <div class="d-block d-md-flex justify-content-between"><span class="text-muted">$100</span></div>
                            </div>
                        </a>
                    </span>
                </div>
                <div class="col-md-3 col-sm-6 col-6">
                    <span>
                        <a class="card product-card" href="/product/my">
                            <div class="card-img">
                                <img src="https://raw.githubusercontent.com/luisDanielRoviraContreras/img/master/files/1.png" class="card-img-top" alt="Iconic – Ceiling Lamp">
                            </div>
                            <div class="card-body">
                                <h5 class="card-title">Iconic – Ceiling Lamp</h5>
                                <div class="d-block d-md-flex justify-content-between"><span class="text-muted">$100</span></div>
                            </div>
                        </a>
                    </span>
                </div>
                <div class="col-md-3 col-sm-6 col-6">
                    <span>
                        <a class="card product-card" href="/product/id">
                            <div class="card-img">
                                <img src="https://raw.githubusercontent.com/luisDanielRoviraContreras/img/master/files/1.png" class="card-img-top" alt="Iconic – Ceiling Lamp">
                            </div>
                            <div class="card-body">
                                <h5 class="card-title">Iconic – Ceiling Lamp</h5>
                                <div class="d-block d-md-flex justify-content-between"><span class="text-muted">$100</span></div>
                            </div>
                        </a>
                    </span>
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

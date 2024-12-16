<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ShoeShoppers._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <section class="hero">
        <div>
            <h1>Welcome to Simon Necktie.</h1>
            <p>Discover the best products tailored for you.</p>
            <a href="#products" class="btn custom-btn">Explore Now</a>
        </div>
    </section>

    <div class="m-5">
        <section id="categories" class="container mt-5 my-5">
            <h2 class=" mb-4">Categories</h2>


            <div class="categories-container">
                <asp:Repeater ID="rptCategories" runat="server">
                    <ItemTemplate>
                        <div class="category-card">
                            <asp:Image ID="imgCategory" runat="server" ImageUrl='<%# Eval("CategoryImageUrl") %>'
                                CssClass="category-image" AlternateText='<%# Eval("CategoryName") %>' />
                            <h3 class="category-title"><%# Eval("CategoryName") %></h3>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

        </section>

        <section id="products" class="container my-5">
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
                                    <asp:PlaceHolder ID="phOfferBadge" runat="server" Visible='<%# Convert.ToDouble(Eval("DiscountPercentage")) > 0 %>'>
                                        <div class="offer-badge"><%# Eval("DiscountPercentage", "{0:0.##}") %>% off</div> 
                                    </asp:PlaceHolder> 
                                </a>
                            </span>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>


            </div>

        </section>
        <%--<section id="about" class="container mt-5">
            <h2 class=" mb-4">Team</h2>
            <p>To keep up with changing trends, we are excited to offer our products online, making it easier for you to shop and experience the premium quality of Simon Necktie shoes, wherever you are.</p>
            <div class="row">
                <div class=" col-md-3 col-sm-6 col-6">
                    <img src="Assets/Images/owners/business-owner.jpg" alt="Owner" class="img-fluid rounded-rectangle" style="width: 250px; height: 250px;">
                    <h4 class="mt-3">Mr. Jimmy</h4>
                    <p>Owner of Simon Necktie.</p>
                </div>

                <div class="col-md-3 col-sm-6 col-6">
                    <img src="Assets/Images/owners/operator.jpg" alt="Owner" class="img-fluid rounded-rectangle" style="width: 250px; height: 250px;">
                    <h4 class="mt-3">Simon Necktie</h4>
                    <p>Business Operator</p>
                </div>
            </div>
        </section>--%>
        <section id="faq" class="container my-5">
            <h2 class="mb-4">FAQ (Frequently Asked Questions)</h2>
            <div class="accordion" id="faqAccordion">
                <div class="accordion-item">
                    <h2 class="accordion-header" id="headingOne">
                        <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                            What types of shoes do you offer?
               
                        </button>
                    </h2>
                    <div id="collapseOne" class="accordion-collapse collapse show" aria-labelledby="headingOne" data-bs-parent="#faqAccordion">
                        <div class="accordion-body">
                            We offer a variety of handmade leather shoes, including formal shoes, boots, sneakers, and slippers.
               
                        </div>
                    </div>
                </div>
                <div class="accordion-item">
                    <h2 class="accordion-header" id="headingTwo">
                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                            How do I place an online order?
               
                        </button>
                    </h2>
                    <div id="collapseTwo" class="accordion-collapse collapse" aria-labelledby="headingTwo" data-bs-parent="#faqAccordion">
                        <div class="accordion-body">
                            You can browse our product catalog, add items to your cart, and proceed to checkout. Payment can be made using credit cards or cash on delivery.
               
                        </div>
                    </div>
                </div>
                <div class="accordion-item">
                    <h2 class="accordion-header" id="headingThree">
                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                            Do you ship internationally?
               
                        </button>
                    </h2>
                    <div id="collapseThree" class="accordion-collapse collapse" aria-labelledby="headingThree" data-bs-parent="#faqAccordion">
                        <div class="accordion-body">
                            Yes, we ship internationally. Shipping charges and delivery time vary based on your location.
               
                        </div>
                    </div>
                </div>
                <div class="accordion-item">
                    <h2 class="accordion-header" id="headingFour">
                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseFour" aria-expanded="false" aria-controls="collapseFour">
                            Can I return or exchange an item?
               
                        </button>
                    </h2>
                    <div id="collapseFour" class="accordion-collapse collapse" aria-labelledby="headingFour" data-bs-parent="#faqAccordion">
                        <div class="accordion-body">
                            Yes, returns and exchanges are accepted within 30 days of purchase, provided the item is unused and in its original condition.
               
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>

</asp:Content>

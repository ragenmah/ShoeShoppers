<%@ Page Title="Product Detail" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="ShoeShoppers.Pages.ProductDetail" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="m-5">
        <section id="product-detail" class="container">
            <div class="row">
                <div class="col-md-5">
                    <div class="product-gallery-container">
                        <div class="zoom-container">
                            <asp:Repeater ID="rptProductImages" runat="server">
                                <HeaderTemplate>
                                    <div id="productCarousel" class="carousel slide" data-bs-ride="carousel">
                                        <div class="carousel-inner">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="carousel-item <%# Container.ItemIndex == 0 ? "active" : "" %>">
                                        <img src='<%# Eval("ImageUrl") %>' class="img-fluid zoomable-image" alt="Product Image">
                                    </div>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </div>
           
                                    <button class="carousel-control-prev" type="button" data-bs-target="#productCarousel" data-bs-slide="prev">
                                        <span class="carousel-control-prev-icon custom-carousel-icon" aria-hidden="true"></span>
                                        <span class="visually-hidden">Previous</span>
                                    </button>
                                    <button class="carousel-control-next" type="button" data-bs-target="#productCarousel" data-bs-slide="next">
                                        <span class="carousel-control-next-icon custom-carousel-icon" aria-hidden="true"></span>
                                        <span class="visually-hidden">Next</span>
                                    </button>
                                    </div>
   
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
                <div class="col-md-7">
                    <div class="main-description px-2">
                        <asp:Label ID="lblProductName" runat="server" CssClass="product-title text-bold mb-2 pt-0" />
                        <div class="price-area my-4">
                            <asp:Label ID="lblPrice" runat="server" CssClass="new-price text-bold mb-1" />
                            <%--<p class="text-secondary mb-1">(Additional tax may apply on checkout)</p>--%>
                        </div>
                        <div class="buttons d-flex my-5">
                            <div class="block">
                                <button type="button" class="shadow btn custom-btn" style="max-width: 100px;" >Buy Now</button>
                            </div>
                                <asp:Button class="shadow btn custom-btn" Font-Size="Large" ID="btnAddToCart" runat="server" Text="Add to cart"
        Height="40px" OnClick="btnAddToCart_Click" />
                            <div class="block quantity">
                                <input type="number" class="form-control" id="cart_quantity" min="0" placeholder="Enter Quantity"
                                    name="cart_quantity" value="1">
                            </div>
                        </div>
                    </div>
                    <div class="product-details my-4">
                        <p class="details-title text-color mb-1">Product Details</p>
                        <asp:Label ID="lblDescription" runat="server" CssClass="description" />
                    </div>
                </div>
            </div>

            <div class="sn-main-card card">
                <div class="sn-main-content card-body">
                    <h2>Write a Review</h2>
                    <form class="">
                        <label class="form-label">Rating</label><div>
                            <span style="cursor: pointer;">
                        </div>
                        <div>
                            <label class="form-label">Comment</label><textarea name="comment" required="" class="form-control">test</textarea>
                        </div>
                        <button type="submit" class="shadow btn custom-btn">Submit Review</button><p class="text-danger mt-2">Error: Please login first.</p>
                    </form>
                    <h2 class="mt-4">Reviews</h2>
                    <p>No reviews yet.</p>
                </div>
            </div>
        </section>
    </div>


    <script>
        document.addEventListener('mousemove', function (e) {
            const zoomableImages = document.querySelectorAll('.zoomable-image');

            zoomableImages.forEach(img => {
                const rect = img.getBoundingClientRect();
                const x = e.clientX - rect.left;
                const y = e.clientY - rect.top;

                if (
                    x >= 0 && x <= rect.width &&
                    y >= 0 && y <= rect.height
                ) {
                    const xPercent = (x / rect.width) * 100;
                    const yPercent = (y / rect.height) * 100;
                    img.style.transformOrigin = `${xPercent}% ${yPercent}%`;
                    img.style.transform = 'scale(1.5)';
                } else {
                    img.style.transform = 'scale(1)'; 
                }
            });
        });
    </script>

</asp:Content>

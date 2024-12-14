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

                            <div class="offer-badge"><%# Eval("DiscountPercentage", "{0:0.##}") %>% off</div>

                            <%--<p class="text-secondary mb-1">(Additional tax may apply on checkout)</p>--%>
                        </div>
                        <div class="buttons d-flex my-5">
                            <div class="block">
                                <button type="button" class="shadow btn custom-btn" style="max-width: 100px;">Buy Now</button>
                            </div>
                            <asp:Button class="shadow btn custom-btn" Font-Size="Large" ID="btnAddToCart" runat="server" Text="Add to cart"
                                Height="40px" OnClick="btnAddToCart_Click" />
                            <div class="block quantity">

                                <asp:TextBox ID="TxtCartQuantity" runat="server" CssClass="form-control" TextMode="Number" MinLength="0" Placeholder="Enter Quantity" Text="1"></asp:TextBox>
                            </div>
                        </div>
                        <asp:Label ID="lblSuccessMessage" runat="server" ForeColor="Green" Visible="false"></asp:Label>
                        <asp:Timer ID="timerHideMessage" runat="server" Interval="2000" OnTick="timerHideMessage_Tick" Enabled="false" />

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
                        <label class="form-label">Rating</label>
                        <div id="rating-container" style="display: flex; gap: 5px;">
                            <asp:TextBox ID="txtRating" runat="server" Text='1' TextMode="Number" Min="1"
                                Max="5" AutoPostBack="True" CssClass="form-control" OnTextChanged="txtRating_TextChanged" />

                            <span class="star" data-value="1" style="cursor: pointer; font-size: 24px;">&#9734;</span>
                            <span class="star" data-value="2" style="cursor: pointer; font-size: 24px;">&#9734;</span>
                            <span class="star" data-value="3" style="cursor: pointer; font-size: 24px;">&#9734;</span>
                            <span class="star" data-value="4" style="cursor: pointer; font-size: 24px;">&#9734;</span>
                            <span class="star" data-value="5" style="cursor: pointer; font-size: 24px;">&#9734;</span>
                        </div>
                        <asp:Label ID="lblCommentMessage" runat="server" ForeColor="Green" Visible="True" EnableViewState="True"></asp:Label>

                        <input type="hidden" id="rating-value" name="Rating" />

                        <div>
                            <span style="cursor: pointer;" />
                        </div>
                        <div class="mt-3">
                            <label class="form-label">Comment</label>
                            <asp:TextBox ID="txtComment" runat="server" Text="test" CssClass="form-control" TextMode="MultiLine" EnableViewState="True" Required="True"></asp:TextBox>
                        </div>
                        <asp:Button ID="btnSubmitReview" runat="server" Text="Submit Review" CssClass="shadow btn custom-btn mt-4" OnClick="SubmitReview_Click" />
                        <p><asp:Label ID="lblFormMessage" runat="server" ForeColor="Green" Visible="True" EnableViewState="True"></asp:Label></p>

                        <%--<p class="text-danger mt-2">Error: Please login first.</p>--%>
                    </form>
                    <h2 class="mt-4">Reviews</h2>
                    <p id="lblNoReview" visible="false" runat="server">No reviews yet.</p>
                    <asp:Repeater ID="rptReviews" runat="server">
                        <ItemTemplate>
                            <div class="card mb-3">

                                <div class="card-body">
                                    <div class="review">
                                        <h4><strong><%# Eval("User.Firstname") %> <%# Eval("User.Lastname") %></strong></h4>
                                        <h6>
                                            <i><%# Eval("CreatedAt") %></i>
                                        </h6>
                                        <div class="rating mb-2">
                                            <strong>Rating:</strong> <%# Eval("Rating") %> <span class="star" data-value="5" style="cursor: pointer; font-size: 24px;">&#9734;</span>
                                        </div>
                                        <div class="comment">
                                            <strong>Comment:</strong> <%# Eval("Comment") %>
                                        </div>
                                    </div>
                                </div>


                                <div class="card-footer">
                                    <%# Eval("ResponseContent") != null && !string.IsNullOrEmpty(Eval("ResponseContent").ToString()) ? Eval("ResponseContent") : "<i>No response yet.</i>" %>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
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

<%@ Page Title="Product Detail" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ShoeShoppers._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="m-5">
        <section id="product-detail" class="container">
            <div class="row">
                <div class="col-md-5">
                    <div class="product-gallery-container">
                        <div class="zoom-container">
                            <img id="productImage"
                                src="https://raw.githubusercontent.com/luisDanielRoviraContreras/img/master/files/1.png"
                                alt="Main thumb"
                                class="img-fluid zoomable-image">
                        </div>
                    </div>
                </div>
                <div class="col-md-7">
                    <div class="main-description px-2">
                        <div class="product-title text-bold mb-2 pt-0">IPHONE 12 PRO 256GB</div>
                        <div class="price-area my-4">
                            <p class="new-price text-bold mb-1">UGX 1700000</p>
                            <p class="text-secondary mb-1">(Additional tax may apply on checkout)</p>
                        </div>
                        <div class="buttons d-flex my-5">
                            <div class="block">
                                <button type="button" class="shadow btn custom-btn  " style="max-width: 100px;">Buy Now</button>
                            </div>
                            <button class="shadow btn custom-btn">Add to cart</button><div class="block quantity">
                                <input type="number" class="form-control" id="cart_quantity" min="0" placeholder="Enter Quantity" name="cart_quantity" value="1">
                            </div>
                        </div>
                    </div>
                    <div class="product-details my-4">
                        <p class="details-title text-color mb-1">Product Details</p>
                        <section class="description"></section>
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
            </div>

        </section>
    </div>


    <script>
        document.getElementById('productImage').addEventListener('mousemove', function (e) {
            var img = e.target;
            var rect = img.getBoundingClientRect();
            var x = e.clientX - rect.left;
            var y = e.clientY - rect.top;
            var xPercent = x / rect.width * 100;
            var yPercent = y / rect.height * 100;

            img.style.transformOrigin = `${xPercent}% ${yPercent}%`;
        });
</script>

</asp:Content>

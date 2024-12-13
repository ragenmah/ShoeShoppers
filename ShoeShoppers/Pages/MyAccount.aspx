<%@ Page Title="Cart" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="MyAccount.aspx.cs" Inherits="ShoeShoppers.Pages.MyAccount" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="m-5">
        <section id="my-cart" class="container">
            <h2 class=" mb-4">My Account</h2>

            <div class="mt-4 row">

                <div class="sn-myac-sidebar col-md-4 col-12">
                    <div class="d-flex align-items-center mb-3">
                        <div class="me-3">
                            <asp:Label ID="lblUserIcon" runat="server" CssClass="rounded-circle bg-secondary d-flex justify-content-center align-items-center"
                                Style="width: 100px; height: 100px; color: white; font-size: 40px;">
                                <i class="fas fa-user"></i>
                            </asp:Label>
                        </div>
                        <div>
                            <h5>ragen</h5>
                            <p>ragenmah99@gmail.com</p>
                        </div>
                    </div>

                    <span><a class="btn custom-btn w-100 me-2" href="/my-orders">My Orders</a></span><span>
                        <a class="btn custom-btn w-100 mt-2" href="/my-cart">My Cart</a></span>
                </div>
                <div class="pt-5 col-md-8 col-12">
                    <h3>Update Profile</h3>
                    <form method="post" class="">
                        <div class="mb-3">
                            <label class="form-label">Name</label><input name="firstName" required="" type="text" class="form-control" value="ragen">
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Email</label><input name="email" disabled="" type="email" class="form-control" value="ragenmah99@gmail.com">
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Phone</label><input name="phone" required="" type="number" class="form-control" value="">
                        </div>
                        <div class="mb-3">
                            <label class="form-label">Short Bio</label><input name="short_bio" type="text" class="form-control" value="">
                        </div>
                        <button type="submit" class="mt-3 btn custom-btn">Update Profile</button>
                    </form>
                </div>
            </div>


        </section>

    </div>
</asp:Content>

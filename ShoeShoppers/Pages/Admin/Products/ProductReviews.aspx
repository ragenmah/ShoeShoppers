<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/Admin/Admin.Master" CodeBehind="ProductReviews.aspx.cs" Inherits="ShoeShoppers.Pages.Admin.Products.ProductReviews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminDashboardContentPlaceHolder" runat="server">
    <div class="container-fluid mt-4">
        <nav aria-label="breadcrumb ">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="/admin">Dashboard</a></li>
                <li class="breadcrumb-item"><a href="/product-list">Products</a></li>
                <li class="breadcrumb-item active" aria-current="page">Product Reviews</li>
            </ol>
        </nav>
        <asp:Label ID="lblWelcome" runat="server" Text="">Product reviews</asp:Label>

        <div class="form-container">

            <p id="lblNoReview" visible="false" runat="server">No reviews yet.</p>
            <asp:Repeater ID="rptReviews" runat="server" OnItemCommand="rptReviews_ItemCommand">
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


                        <%# !string.IsNullOrEmpty(Eval("ResponseContent")?.ToString()) ? $@"
                                 <div class='card-footer mx-5'>
                                     <h4><strong>Admin</strong></h4>
                                     {Eval("ResponseContent")}
                                     <div><i>{Eval("RepliedAt")}</i></div>
                                 </div>" : "" %>
                        <div class="reply-section">
                            <asp:TextBox ID="txtReply" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" Placeholder="Write your reply here..."></asp:TextBox>
                            <asp:Button ID="btnReply" runat="server" CssClass="btn btn-warning mt-2" Text="Reply" CommandName="ReplyReview" CommandArgument='<%# Eval("ReviewId") %>' />
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

    </div>
</asp:Content>

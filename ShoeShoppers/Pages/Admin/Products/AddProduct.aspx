<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/Admin/Admin.Master" CodeBehind="AddProduct.aspx.cs" Inherits="ShoeShoppers.Pages.Admin.Products.AddProduct" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminDashboardContentPlaceHolder" runat="server">
    <div class="container-fluid mt-4 ">

        <nav aria-label="breadcrumb">
            <ol class="breadcrumb">
                <li class="breadcrumb-item"><a href="/admin">Dashboard</a></li>
                <li class="breadcrumb-item"><a href="/product-list">Products</a></li>
                <li class="breadcrumb-item active" aria-current="page">Add Product</li>
            </ol>
        </nav>

        <h2 class=" mb-4">Add New Product</h2>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
        <div class="card p-4 shadow-sm">

            <form id="form1" enctype="multipart/form-data">
                <div class="row">
                    <!-- Left Column -->
                    <div class="col-md-6">
                        <div class="mb-3">
                            <label for="txtProductName" class="form-label">Product Name:</label>
                            <asp:TextBox ID="txtProductName" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtDescription" class="form-label">Description:</label>
                            <asp:TextBox ID="txtDescription" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="4"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtPrice" class="form-label">Price:</label>
                            <asp:TextBox ID="txtPrice" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtDiscount" class="form-label">Discount Percentage:</label>
                            <asp:TextBox ID="txtDiscount" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="ddlCategory" class="form-label">Category:</label>
                            <asp:DropDownList ID="ddlCategory" CssClass="form-select" runat="server"></asp:DropDownList>
                        </div>
                    </div>

                    <!-- Right Column -->
                    <div class="col-md-6">
                        <div class="mb-3">
                            <label for="txtStock" class="form-label">Stock Quantity:</label>
                            <asp:TextBox ID="txtStock" CssClass="form-control" runat="server" TextMode="Number"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtSize" class="form-label">Size:</label>
                            <asp:TextBox ID="txtSize" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <label for="txtColor" class="form-label">Color:</label>
                            <asp:TextBox ID="txtColor" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                        <div class="mb-3">
                            <asp:Image ID="imgPreview" runat="server" CssClass="img-thumbnail" Width="150px" Height="150px" AlternateText="No Image Available" />
                        </div>
                        <div class="mb-3">
                            <label for="fileUpload" class="form-label">Upload Image:</label>
                            <asp:FileUpload ID="fileUpload" CssClass="form-control" runat="server" />
                        </div>
                        <div class="form-check mb-3">

                            <label for="chkIsActive" class="form-check-label">Is Active</label>
                            <asp:CheckBox ID="chkIsActive" runat="server" />
                        </div>
                        <asp:HiddenField ID="hfProductId" runat="server" />

                        <div class=" mt-4">
                            <asp:Button ID="btnSubmit" CssClass="btn btn-warning me-2" runat="server" Text="Add Product" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnAddProductImages" CssClass="btn btn-info me-2 " runat="server" Text="Add Product Images" OnClick="btnAddProductImages_Click" />
                            <asp:Button ID="btnCancel" CssClass="btn btn-secondary" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
                        </div>

                    </div>
                </div>


                <!-- Buttons -->

            </form>
        </div>

    </div>
</asp:Content>

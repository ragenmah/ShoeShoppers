<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/Admin/Admin.Master" CodeBehind="ProductImageList.aspx.cs" Inherits="ShoeShoppers.Pages.Admin.Products.ProductImageList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminDashboardContentPlaceHolder" runat="server">
 <div class="container-fluid mt-4">
    <nav aria-label="breadcrumb" >
    <ol class="breadcrumb">
        <li class="breadcrumb-item"><a href="/admin">Dashboard</a></li>
        <li class="breadcrumb-item"><a href="/product-list">Products</a></li>
<%--        <li class="breadcrumb-item"><a href="/product-list">Add Product</a></li>--%>
        <li class="breadcrumb-item active" aria-current="page">Product Images</li>
    </ol>
</nav>
    <h2 class=" mb-4">Product Images</h2>

        <div class="form-container">
    <h2>Add Product Image</h2>
    <form id="form1"  enctype="multipart/form-data">
        <div>
            <asp:Label ID="lblProductId" runat="server" Text="Product ID:" Font-Bold="true"></asp:Label>
            <asp:TextBox ID="txtProductId" runat="server" Width="100%" ReadOnly="true" Enabled="false"></asp:TextBox>
        </div>

      <div>
            <asp:Label ID="lblImage" runat="server" Text="Upload Image:" ></asp:Label>
            <asp:FileUpload ID="fileUpload" runat="server" cssClass="form-control" />
        </div>

        <div class=" mt-4" >
              <asp:Button ID="btnSubmit" CssClass="btn btn-warning me-2" runat="server" Text="Add Image" OnClick="btnSubmit_Click" />
  <asp:Button ID="btnCancel" CssClass="btn btn-secondary" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
        </div>
    </form>
</div> 
    
    <div class="form-container">
        <asp:GridView ID="gvProductImages" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered">

    <Columns>
        <asp:BoundField DataField="ImageId" HeaderText="Image ID" />
       <asp:TemplateField HeaderText="Image">
    <ItemTemplate>
        <asp:Image ID="imgCategory" runat="server" ImageUrl='<%# Eval("ImageUrl") %>'
            Width="32px" Height="32px" AlternateText="No Image Available" />
    </ItemTemplate>
</asp:TemplateField>
<%--        <asp:CommandField ShowDeleteButton="True" OnDeleteCommand="DeleteImage" />--%>
    </Columns>
</asp:GridView>
    </div>
 </div>
    
    
</asp:Content>

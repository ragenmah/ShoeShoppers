<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/Admin/Admin.Master" CodeBehind="ProductImageList.aspx.cs" Inherits="ShoeShoppers.Pages.Admin.Products.ProductImageList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminDashboardContentPlaceHolder" runat="server">
    <h1>Your Products</h1>
    <asp:Label ID="lblWelcome" runat="server" Text="">List of products</asp:Label>

   
       

        <div class="form-container">
    <h2>Add Product Image</h2>
    <form id="form1"  enctype="multipart/form-data">
        <div>
            <asp:Label ID="lblProductId" runat="server" Text="Product ID:" Font-Bold="true"></asp:Label>
            <asp:TextBox ID="txtProductId" runat="server" Width="100%"></asp:TextBox>
        </div>

      <div>
            <asp:Label ID="lblImage" runat="server" Text="Upload Image:"></asp:Label>
            <asp:FileUpload ID="fileUpload" runat="server" />
        </div>

        <div>
            <asp:Button ID="btnSubmit" runat="server" Text="Add Image" OnClick="btnSubmit_Click" />
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
</asp:Content>

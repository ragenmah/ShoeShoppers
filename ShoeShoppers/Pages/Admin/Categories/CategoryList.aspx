<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/Admin/Admin.Master" CodeBehind="CategoryList.aspx.cs" Inherits="ShoeShoppers.Pages.Admin.Categories.CategoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminDashboardContentPlaceHolder" runat="server">
    <div class="container mt-5">
        <h1 class=" mb-4">Your Categories</h1>
        <div class="card p-4 shadow-sm">
            <form id="categoryForm">
                <!-- Category Name -->
                <div class="mb-3">
                    <label for="txtCategoryName" class="form-label">Category Name</label>
                    <asp:TextBox ID="txtCategoryName" runat="server" CssClass="form-control" Placeholder="Enter Category Name"></asp:TextBox>
                </div>

                <!-- Upload Image -->
                <div class="mb-3">
                    <label for="fuCategoryImage" class="form-label">Upload Image</label>
                    <asp:FileUpload ID="fuCategoryImage" runat="server" CssClass="form-control" />
                </div>

                <!-- Is Active -->
                <div class="mb-3 form-check">
                    <asp:CheckBox ID="chkIsActive" runat="server" CssClass=" " />
                    <label class="form-check-label" for="chkIsActive">Active</label>
                </div>

                <!-- Message -->
                <div class="mb-3">
                    <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>
                </div>

                <!-- Save Button -->
                <div class="text-center">
                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-primary w-100" OnClick="SaveCategory" />
                </div>
            </form>
        </div>

        <!-- Categories Grid -->
        <div class="mt-5">
          <asp:GridView ID="gvCategories" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
    OnRowEditing="gvCategories_RowEditing" OnRowUpdating="gvCategories_RowUpdating" 
    OnRowCancelingEdit="gvCategories_RowCancelingEdit" OnRowDeleting="gvCategories_RowDeleting"
    DataKeyNames="CategoryId">
    <Columns>
        
        <asp:BoundField DataField="CategoryId" HeaderText="ID" ReadOnly="True" />

        
        <asp:BoundField DataField="CategoryName" HeaderText="Name" />

       
        <asp:TemplateField HeaderText="Image Preview">
            <ItemTemplate>
                <asp:Image ID="imgCategory" runat="server" ImageUrl='<%# Eval("CategoryImageUrl") %>'
                    Width="100px" Height="100px" AlternateText="No Image Available" />
            </ItemTemplate>
        </asp:TemplateField>

        <asp:CheckBoxField DataField="IsActive" HeaderText="Active" />

      
        <asp:CommandField HeaderText="Action" ShowEditButton="true" ShowDeleteButton="true" />
    </Columns>
</asp:GridView>
        </div>
    </div>
</asp:Content>


<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/Admin/Admin.Master" CodeBehind="CategoryList.aspx.cs" Inherits="ShoeShoppers.Pages.Admin.Categories.CategoryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminDashboardContentPlaceHolder" runat="server">
    <div class="container-fluid ">
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

                    <label class="form-check-label" for="chkIsActive">Is Active</label>
                                        <asp:CheckBox ID="chkIsActive" runat="server" CssClass=" " />
                </div>

                <!-- Message -->
                <div class="mb-3">
                    <asp:Label ID="lblMessage" runat="server" ForeColor="Red"></asp:Label>
                </div>

                <!-- Save Button -->
                
                 <div class="text-center mt-4">
     <asp:Button ID="btnSubmit" CssClass="btn btn-warning me-2" runat="server" Text="Add Category" OnClick="SaveCategory" />
     <asp:Button ID="btnCancel" CssClass="btn btn-secondary" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
 </div>
            </form>
        </div>

        <asp:Label ID="lblNoCategories" runat="server" Text="No categories available. Please add some categories." Visible="false" ForeColor="Red"></asp:Label>

        <!-- Categories Grid -->
        <div class="mt-5">
            <asp:GridView ID="gvCategories" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
                OnRowEditing="gvCategories_RowEditing" OnRowUpdating="gvCategories_RowUpdating"
                OnRowCancelingEdit="gvCategories_RowCancelingEdit" OnRowDeleting="gvCategories_RowDeleting"
                DataKeyNames="CategoryId" AllowPaging="True" PageSize="3"
                OnPageIndexChanging="gvCategories_PageIndexChanging">
                <Columns>

                    <asp:BoundField DataField="CategoryId" HeaderText="ID" ReadOnly="True" />


                    <asp:TemplateField HeaderText="Category Name">
                        <ItemTemplate>
                            <%# Eval("CategoryName") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:TextBox ID="txtCategoryName" runat="server" Text='<%# Bind("CategoryName") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>


                    <asp:TemplateField HeaderText="Image Preview">
                        <ItemTemplate>
                            <asp:Image ID="imgCategory" runat="server" ImageUrl='<%# Eval("CategoryImageUrl") %>'
                                Width="100px" Height="100px" AlternateText="No Image Available" />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:FileUpload ID="fuCategoryImage" runat="server" />
                            <asp:HiddenField ID="hfCategoryImageUrl" runat="server" Value='<%# Bind("CategoryImageUrl") %>' />
                            <asp:Image ID="imgCategoryEdit" runat="server" ImageUrl='<%# Bind("CategoryImageUrl") %>'
                                Width="100px" Height="100px" AlternateText="No Image Available" />
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Is Active">
                        <ItemTemplate>

                            <asp:CheckBox ID="chkIsActive" runat="server" Enabled="false" Checked=' <%# Eval("IsActive") %>' />
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:CheckBox ID="chkIsActive" runat="server" Checked='<%# Bind("IsActive") %>' />
                        </EditItemTemplate>
                    </asp:TemplateField>

                    <asp:CommandField HeaderText="Action" ShowEditButton="true" ShowDeleteButton="true" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>


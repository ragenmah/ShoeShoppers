
<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Pages/Admin/Admin.Master"CodeBehind="Contacts.aspx.cs" Inherits="ShoeShoppers.Pages.Admin.Contacts.Contacts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="AdminDashboardContentPlaceHolder" runat="server">
    <div class="container-fluid mt-4">
         <h1>Croducts</h1>
  <asp:Label ID="Label1" runat="server" Text="">List of contacts</asp:Label>


        <div class="form-container">

            <p id="lblNoContacts" visible="false" runat="server">No any contacts yet.</p>
            <asp:Repeater ID="rptContactUs" runat="server" OnItemCommand="rptContactUs_ItemCommand">
    <ItemTemplate>
        <div class="card mb-3">
            <div class="card-body">
                <h4><strong>Full Name:</strong> <%# Eval("FullName") %></h4>
                <p><strong>Email:</strong> <%# Eval("Email") %></p>
                <p><strong>Phone Number:</strong> <%# Eval("PhoneNumber") %></p>
                <p><strong>Message:</strong> <%# Eval("Message") %></p>
                <p><strong>Created At:</strong> <%# Eval("CreatedAt") %></p>
            </div>

            <%# Convert.ToBoolean(Eval("IsReplied")) ? $@"
            <div class='card-footer mx-5'>
                <h4><strong>Admin Response</strong></h4>
                <p>{Eval("RepliedBy")} replied on {Eval("RepliedAt")}</p>
            </div>" : "" %>

            <div class="reply-section">
                <asp:TextBox ID="txtReply" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" Placeholder="Write your reply here..."></asp:TextBox>
                <asp:Button ID="btnReply" runat="server" CssClass="btn btn-warning mt-2" Text="Reply" CommandName="ReplyContact" CommandArgument='<%# Eval("ContactUsId") %>' />
            </div>
        </div>
    </ItemTemplate>
</asp:Repeater>
        </div>

    </div>
</asp:Content>

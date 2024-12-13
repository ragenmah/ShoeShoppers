<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ShoeShoppers.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="m-5">
        <section id="contacts" class="container">

            <div class="row">
                <div class="col-md-5">
                    <h2 class=" mb-4">Simon Necktie.</h2>
                    <img src="Assets/Icons/shopping-bag.png" />
                    <h3>Opening Hours</h3>
                    <p>We are open every day!</p>
                </div>
                <div class="col-md-7">
                    <form id="form1" class="form">
                        <div>
                            <asp:Label ID="" Text="Contact Form" Font-Size="XX-Large" Font-Bold="true" ForeColor="#9900CC"></asp:Label>
                        </div>
                        <div class="url-link">
                            Fill out the form to reach us 
                        </div>

                          <div class="form-group mt-3">
            <asp:Label ID="lblFullName" runat="server" AssociatedControlID="txtFullName" ForeColor="Black">Full Name</asp:Label>
            <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" placeholder="Enter your full name" required="true"></asp:TextBox>
        </div>

      
        <div class="form-group mt-3">
            <asp:Label ID="lblEmail" runat="server" AssociatedControlID="txtEmail" ForeColor="Black">Email</asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter your email" type="email" required="true"></asp:TextBox>
        </div>

       
        <div class="form-group mt-3">
            <asp:Label ID="lblPhoneNumber" runat="server" AssociatedControlID="txtPhoneNumber" ForeColor="Black">Phone Number</asp:Label>
            <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control" placeholder="Enter your phone number" required="true"></asp:TextBox>
        </div>

        <!-- Message -->
        <div class="form-group mt-3">
            <asp:Label ID="lblMessage" runat="server" AssociatedControlID="txtMessage" ForeColor="Black">Message</asp:Label>
            <asp:TextBox ID="txtMessage" runat="server" CssClass="form-control" placeholder="Write your message" TextMode="MultiLine" Rows="5" required="true"></asp:TextBox>
        </div>

                    <div>
                        <asp:Button class="btn custom-btn mt-3" Font-Size="Large" ID="Button1" runat="server" Text="Send Message"
                            Height="40px" />
                    </div>
                    </form>
                </div>
            </div>
        </section>
    </div>

</asp:Content>

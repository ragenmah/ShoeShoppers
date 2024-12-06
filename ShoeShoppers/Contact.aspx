﻿<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="ShoeShoppers.Contact" %>

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

                        <div>
                            <asp:Label ID="Label2" runat="server" Text="Email:" Font-Bold="true" Font-Size="Larger"></asp:Label>
                            <asp:TextBox ID="TextBox1" runat="server" TextMode="Email" Height="35px" Width="100%"></asp:TextBox>
                        </div>
                        <div>
                            <div style="display: flex; align-items: center; justify-content: space-between">
                                <asp:Label ID="Label3" runat="server" Text="Password: " Font-Bold="true" Font-Size="Larger"></asp:Label>
                                <label style="display: flex; align-items: center;">
                                    <input type="checkbox" id="showPassword" onclick="document.getElementById('TextBox2').type=this.checked? 'text': 'password'" />
                                    <span style="margin-left: 5px;">Show Password</span>
                                </label>
                            </div>
                            <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" Width="100%" Height="35px"></asp:TextBox>
                        </div>
                        <asp:label ID="Label4" style="display: flex; align-items: center;">
                            <input class="checkbox" type="checkbox" />
                            <span style="margin-left: 5px;">Keep me logged in</span>

                        </asp:label>
        <div>
            <asp:Button class="btn custom-btn" Font-Size="Large" ID="Button1" runat="server" Text="Send Message"
                Height="40px" />
        </div>
                    </form>
                </div>
            </div>
        </section>
    </div>

</asp:Content>

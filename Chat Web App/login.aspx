﻿<%@ Page Title="Log In" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="Chat_Web_App.login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <section id="main-content" >
        <section id="wrapper" >
            <div class="row" >
                <div class=" col-lg-12" >
                    <section class="panel" >
                        <header class="panel-heading" >
                            <div class="col-md-4 col-md-offset-4" >
                                <h1><b>Log In</b></h1>
                            </div>
                        </header>

                        <div class="panel-body">
                            <div class="row">
                                <div class="col-md-4 col-md-offset-4">
                                    <div class="form-group">
                                        <asp:Label Text="Username:" runat="server" />
                                        <asp:TextBox ID="uname2" runat="server" Enabled="true" CssClass="form-control input-sm" placeholder="username" />
                                    </div>
                                </div>
                                <div class="col-md-4 col-md-offset-4">
                                    <div class="form-group">
                                        <asp:Label Text="Password:" runat="server" />
                                        <asp:TextBox ID="pwd2" runat="server" Enabled="true" TextMode="Password" CssClass="form-control input-sm" placeholder="password" />
                                    </div>
                                    <div class="col-md-8 col-md-offset-2">
                                        <asp:Button Text="Login" ID="logbutton" OnClick="logbutton_click" CssClass="btn btn-primary" Width="120px" runat="server" />
                                    </div>
                                </div>
                            </div>  

                        </div>
                    </section>
                </div>
            </div>
        </section>
    </section>

</asp:Content>

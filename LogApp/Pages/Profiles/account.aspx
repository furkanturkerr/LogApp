﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="account.aspx.cs" Inherits="LogApp.Pages.Profiles.account" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link rel="stylesheet" href="../../Styles/MainPage.css">
    <link rel="stylesheet" href="../../Styles/color.css">
    <link rel="stylesheet" href="Css/Profile.css">
    <link rel="stylesheet" href="Css/account.css">
</head>
<body>
    <form id="form1" runat="server" class="container">
            <header class="header">
        <div class="header-top">
            <div class="header-top-lr">
                <div class="header-top-left">
                    <a href="#"><i class="fa-solid fa-envelope"></i> logapp@gmail.com</a>
                    <a href="#"><i class="fa-solid fa-location-dot"></i> İstanbul, Türkiye</a>
                </div>
                <div class="header-top-right">
                    <div class="top-right-lr">
                        <div class="top-right-left">
                            <a href="#">Yardım</a>
                            <a href="#">Destek</a>
                            <a href="#">İletişim</a>
                        </div>
                        <div class="top-right-right">
                            <i class="fa-brands fa-instagram"></i>
                            <i class="fa-brands fa-linkedin"></i>
                            <i class="fa-brands fa-facebook"></i>
                            <i class="fa-brands fa-youtube"></i>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="header-lower">
            <div class="header-icon">
                <a href="car.aspx" class="header-icon"></a>
            </div>
            <div class="header-link">
               <a href="../MainPage.aspx">Anasayfa</a>
               <a href="../About.aspx">Hakkımızda</a>
             <a href="../SearchLoad.aspx">Yük Arıyorum</a>
             <a href="../Contact.aspx">İletişim</a>  
            </div>
            <div class="header-login">
                <asp:Button ID="btnLogin" runat="server" CssClass="login" Text="Giriş Yap" OnClick="btnLogin_Click" Visible="false"/>
                <asp:Button ID="btnRegister" runat="server" CssClass="login" Text="Kayıt Ol" OnClick="btnRegister_Click" Visible="false"/>
                 <div class="profile-container">
               <asp:Button ID="btnProfile" runat="server" CssClass="profile" Text="Profilim" OnClick="btnProfile_Click"/><i class="fa-solid fa-angle-down"></i>
                <div class="menu">
                    <a href="tools.html">Araçlarım</a>
                    <a href="logout.html">Çıkış Yap</a>
                </div>
            </div>
            </div>
        </div>
        <hr class="header-line">
    </header>

        <div class="containerr">
    <!-- Sol Yan Menü -->
    <aside class="sidebar-a">
        <div class="profile-a">
            <div id="avatar" runat="server" class="avatar"></div>
                <asp:Label ID="kullaniciad" CssClass="kullanici" runat="server" Font-Bold="true"></asp:Label>
        </div>
        <nav class="menu-a">
            <ul>
                <li><a href="../Profiles/Profil.aspx">Anasayfa</a></li>
                <li><a href="../Profiles/Cars.aspx">Araçlarım</a></li>
                <li><a href="../Profiles/Offers.aspx">Yük İlanlarım</a></li>
                <li><a href="../Profiles/Transport.aspx">Tekliflerim</a></li>
                <li><a href="../Profiles/notifications.aspx">Bildirimler</a></li>
                <li><a href="../Profiles/notifications.aspx">Mesajlar</a></li>
            </ul>
        </nav>
        <nav class="settings">
            <ul>
                <li><a href="../Profiles/account.aspx">Hesabım</a></li>
                <li><asp:Button ID="btnLogout" runat="server" Text="Çıkış Yap" CssClass="logout-btn" OnClick="btnLogout_Click" /></li>
            </ul>
        </nav>
    </aside>

    <!-- Sağ İçerik Alanı -->
    <main class="content-a">
        <div class="header-aa">
            <a href="car.html" class="header-logoo">🚗 Hesabım</a>
        </div>
        <div class="header-ic">
           <div class="profile-containerr">

            <asp:Label ID="lblMessage" runat="server" CssClass="message" />

            <div class="form-group">
                <asp:Label ID="Label1" runat="server" Text="Ad:" CssClass="label" />
                <asp:TextBox ID="txtAd" runat="server" CssClass="textbox" />
            </div>

            <div class="form-group">
                <asp:Label ID="Label2" runat="server" Text="Soyad:" CssClass="label" />
                <asp:TextBox ID="txtSoyad" runat="server" CssClass="textbox" />
            </div>

            <div class="form-group">
                <asp:Label ID="Label3" runat="server" Text="Telefon:" CssClass="label" />
                <asp:TextBox ID="txttel" runat="server" CssClass="textbox" />
            </div>

            <div class="form-group">
                <asp:Label ID="Label5" runat="server" Text="E-Posta:" CssClass="label" />
                <asp:TextBox ID="txtmail" runat="server" CssClass="textbox" />
            </div>

            <div class="form-group">
                <asp:Label ID="Label4" runat="server" Text="Adres:" CssClass="label" />
                <asp:TextBox ID="txtAdres" runat="server" CssClass="textbox" />
            </div>

            <asp:Button ID="btnSubmit" runat="server" Text="Güncelle" CssClass="button" OnClick="btnSubmit_Click" />
        </div>
        </div>
    </main>

</main>

</div>
</form>
</body>
</html>

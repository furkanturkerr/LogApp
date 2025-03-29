<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="LogApp.Pages.MainPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../Styles/MainPage.css">
    <link rel="stylesheet" href="../../Styles/color.css">
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
                    <a href="MainPage.aspx">Anasayfa</a>
                    <a href="About.aspx">Hakkımızda</a>
                    <a href="SearchLoad.aspx">Yük Arıyorum</a>
                    <a href="Contact.aspx">İletişim</a>
                </div>
                <div class="header-login">
                    <asp:Button ID="btnLogin" runat="server" CssClass="login" Text="Giriş Yap" OnClick="btnLogin_Click" />
                    <asp:Button ID="btnRegister" runat="server" CssClass="login" Text="Kayıt Ol" OnClick="btnRegister_Click" />
                     <div class="profile-container">
                   <asp:Button ID="btnProfile" runat="server" CssClass="profile" Text="Profilim" OnClick="btnProfile_Click" Visible="false" /><i class="fa-solid fa-angle-down"></i>
                    <div class="menu">
                        <a href="tools.html">Araçlarım</a>
                        <a href="logout.html">Çıkış Yap</a>
                    </div>
                </div>
                </div>
            </div>
            <hr class="header-line">
        </header>
    </form>
</body>
</html>

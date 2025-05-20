<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profil.aspx.cs" Inherits="LogApp.Pages.Profil" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../../Styles/MainPage.css">
    <link rel="stylesheet" href="../../Styles/color.css">
    <link rel="stylesheet" href="Css/Profile.css">
</head>
   <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/swiper@9/swiper-bundle.min.css"/>
    <style>
        .swiper {
            width: 100%;
            height: 500px;
            margin-top: -50px;
        }

        .swiper-slide img {
            width: 100%;
            height: 100%;
            object-fit: cover;
        }

       .panel-title {
           position: absolute;
       }
    </style>
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
                <h2 class="panel-title">Anasayfa</h2>
                <div class="header-ic">
                                    </div>
            </div>
                    <a href="car.html" class="header-ic"></a>
                        <div class="swiper">
            <div class="swiper-wrapper">
<asp:Repeater ID="rptSlider" runat="server">
    <ItemTemplate>
        <div class="swiper-slide">
            <img src='<%# ResolveUrl(Eval("ImageUrl").ToString()) %>' alt="Tır Görseli" />
        </div>
    </ItemTemplate>
</asp:Repeater>
            </div>
            <!-- Alt nokta geçişleri -->
            <div class="swiper-pagination"></div>
        </div>

        <script src="https://cdn.jsdelivr.net/npm/swiper@9/swiper-bundle.min.js"></script>
        <script>
            var swiper = new Swiper('.swiper', {
                loop: true,
                autoplay: {
                    delay: 3000,
                    disableOnInteraction: false,
                },
                pagination: {
                    el: '.swiper-pagination',
                    clickable: true,
                }
            });
        </script>

        </main>
    </div>
    </form>
</body>
</html>

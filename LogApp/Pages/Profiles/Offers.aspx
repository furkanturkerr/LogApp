<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Offers.aspx.cs" Inherits="LogApp.Pages.Profiles.Offers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css" rel="stylesheet" />
    <title></title>
        <link rel="stylesheet" href="../../Styles/MainPage.css">
    <link rel="stylesheet" href="../../Styles/color.css">
    <link rel="stylesheet" href="Css/Profile.css">
    <link rel="stylesheet" href="Css/offers.css">
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
                <a href="About.aspx">Hakkımızda</a>
                <a href="SearchLoad.aspx">Yük Arıyorum</a>
                <a href="Contact.aspx">İletişim</a>
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
            <div class="avatar">FT</div>
            <h2>Furkan TÜRKER</h2>
            <p>★★★★★</p>
        </div>
        <nav class="menu-a">
            <ul>
                <li><a href="../Profiles/Profil.aspx">Anasayfa</a></li>
                <li><a href="../Profiles/Cars.aspx">Araçlarım</a></li>
                <li><a href="../Profiles/Offers.aspx">Teklifler</a></li>
                <li><a href="../Profiles/Transport.aspx">Taşımalarım</a></li>
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
            <div class="header-ic">
                <a href="car.html" class="header-ic"></a>
               <asp:Repeater ID="rptNoktalar" runat="server">
                <ItemTemplate>
                    <div class="card-row">
                        <!-- Yükleme Kartı -->
                        <div class="card-box load">
                            <h4>🚛 Yükleme Noktası</h4>
                            <p><strong>İsim:</strong> <%# Eval("Yukleme.Isim") %></p>
                            <p><strong>Telefon:</strong> <%# Eval("Yukleme.Telefon") %></p>
                            <p><strong>Şehir:</strong> <%# Eval("Yukleme.Sehir") %></p>
                            <p><strong>Adres:</strong> <%# Eval("Yukleme.Adres") %></p>
                        </div>

                        <!-- Teslimat Kartı -->
                        <div class="card-box deliver">
                            <h4>📦 Teslimat Noktası</h4>
                            <p><strong>İsim:</strong> <%# Eval("Teslimat.Isim") %></p>
                            <p><strong>Telefon:</strong> <%# Eval("Teslimat.Telefon") %></p>
                            <p><strong>Şehir:</strong> <%# Eval("Teslimat.Sehir") %></p>
                            <p><strong>Adres:</strong> <%# Eval("Teslimat.Adres") %></p>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater> 
</div>

            </div>
        </div>
    </main>
</div>
</form>
</body>
</html>

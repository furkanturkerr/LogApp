    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cars.aspx.cs" Inherits="LogApp.Pages.Profiles.Cars" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link rel="stylesheet" href="../../Styles/MainPage.css">
    <link rel="stylesheet" href="../../Styles/color.css">
    <link rel="stylesheet" href="Css/Profile.css">
     <link rel="stylesheet" href="Css/Cars.css">
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
        <asp:Button ID="Button2" runat="server" Text="Araç Ekle" CssClass="car" OnClick="btncar_Click" />
        <div class="header-ic">
            <a href="car.html" class="header-ic"></a>
        </div>
    </div>

    <div class="car-list">
        <asp:Repeater ID="CarRepeater" runat="server" OnItemCommand="rptAraclar_ItemCommand">
            <ItemTemplate>
                <div class="car-item">
                    <h3><%# Eval("arac_ad") %></h3>
                    <p>Marka: <%# Eval("arac_marka") %></p>
                    <p>Seri: <%# Eval("arac_seri") %></p>
                    <p>Plaka: <%# Eval("arac_plaka") %></p>
                    
                    <div class="sil">
                            <asp:LinkButton 
                            ID="btnSil" 
                            runat="server" 
                            CommandName="Sil" 
                            CommandArgument='<%# Eval("arac_plaka") %>' 
                            OnClientClick="return confirm('Bu aracı silmek istediğinizden emin misiniz?');"
                            CssClass="sil-buton">
                            Sil
                        </asp:LinkButton>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</main>
    </div>
    </form>
</body>
</html>

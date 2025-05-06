<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transport.aspx.cs" Inherits="LogApp.Pages.Profiles.Transport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link rel="stylesheet" href="../../Styles/MainPage.css">
    <link rel="stylesheet" href="../../Styles/color.css">
    <link rel="stylesheet" href="Css/Profile.css">
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
            <div class="header-ic">
                <a href="car.html" class="header-ic"></a>
                <div class="container py-5">
    <h2>Tekliflerim</h2>
    <asp:Label ID="lblMesaj" runat="server" CssClass="alert alert-info" Visible="false"></asp:Label>
    <asp:GridView ID="gvTekliflerim" runat="server" CssClass="table table-striped" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="YukAdi" HeaderText="Yük Adı" />
            <asp:BoundField DataField="AlinacakSehir" HeaderText="Alınacak Şehir" />
            <asp:BoundField DataField="TeslimEdilecekSehir" HeaderText="Teslim Şehri" />
            <asp:BoundField DataField="Tarih" HeaderText="Yük Tarihi" DataFormatString="{0:dd.MM.yyyy}" />
            <asp:BoundField DataField="TeklifTutari" HeaderText="Teklif Tutarı (₺)" DataFormatString="{0:N2}" />
            <asp:BoundField DataField="TeklifTarihi" HeaderText="Teklif Tarihi" DataFormatString="{0:dd.MM.yyyy HH:mm}" />
            <asp:BoundField DataField="Durum" HeaderText="Durum" />
        </Columns>
                        <EmptyDataTemplate>
                    <div class="alert alert-warning">Henüz hiç teklif yapmamışsınız.</div>
                </EmptyDataTemplate>
    </asp:GridView>
</div>
            </div>
        </div>
    </main>
</div>
</form>
</body>
</html>

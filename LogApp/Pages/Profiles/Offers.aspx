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
        <asp:Button ID="Button2" runat="server" Text="Yük Ekle" CssClass="cars" OnClick="btnyuk_Click" />
        
<div class="header-ic">
                <a href="offers.html" class="header-ic"></a>
           <!-- Yük Listesi -->
  <h3>Teklifler</h3>

<asp:GridView ID="gvTeklifler" runat="server" AutoGenerateColumns="False" 
              OnRowCommand="gvTeklifler_RowCommand" 
              OnRowDataBound="gvTeklifler_RowDataBound" 
              CssClass="table table-striped">
    <Columns>
        <asp:BoundField DataField="YukAdi" HeaderText="Yük Adı" SortExpression="YukAdi" />
        <asp:BoundField DataField="AlinacakSehir" HeaderText="Alınacak Şehir" SortExpression="AlinacakSehir" />
        <asp:BoundField DataField="TeslimEdilecekSehir" HeaderText="Teslim Edilecek Şehir" SortExpression="TeslimEdilecekSehir" />
        <asp:BoundField DataField="Tarih" HeaderText="Tarih" SortExpression="Tarih" />
        <asp:BoundField DataField="Ucret" HeaderText="Ücret" SortExpression="Ucret" />
        <asp:BoundField DataField="TeklifTutari" HeaderText="Teklif Tutarı (₺)" DataFormatString="{0:N2}" />
        <asp:BoundField DataField="AracPlaka" HeaderText="Nakliyeci'nin Plakası" />
        <asp:TemplateField>
            <ItemTemplate>
                <asp:Button ID="btnOnayla" runat="server" CommandName="Onayla" CommandArgument='<%# Eval("TeklifID") %>' Text="Onayla" Visible="false" />
                <asp:Button ID="btnReddet" runat="server" CommandName="Reddet" CommandArgument='<%# Eval("TeklifID") %>' Text="Reddet" Visible="false" />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>

               <!-- Teklif Paneli (Sayfanın uygun bir yerine ekleyin) -->
<asp:Panel ID="pnlTeklif" runat="server" Visible="false" CssClass="modal-content" style="padding:20px; margin-top:20px; border:1px solid #ddd;">
    <h4>Teklif Ver</h4>
    <asp:Label ID="lblYukAdi" runat="server" Font-Bold="true"></asp:Label><br />
    <asp:Label ID="lblYukDetay" runat="server"></asp:Label>
    
    <div class="form-group">
        <label>Teklif Tutarı (₺)</label>
        <asp:TextBox ID="txtTeklifTutar" runat="server" CssClass="form-control" TextMode="Number" step="0.01"></asp:TextBox>
    </div>
    
<%--    <div class="form-group">
        <asp:Button ID="btnTeklifGonder" runat="server" Text="Teklifi Gönder" 
            CssClass="btn btn-primary" OnClick="btnTeklifGonder_Click" />
        <asp:Button ID="btnVazgec" runat="server" Text="Vazgeç" 
            CssClass="btn btn-secondary" OnClick="btnVazgec_Click" CausesValidation="false" />
    </div>--%>
</asp:Panel>
</div>
    </div>
</main>

</div>
</form>
</body>
</html>

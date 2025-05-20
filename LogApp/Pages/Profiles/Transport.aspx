<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Transport.aspx.cs" Inherits="LogApp.Pages.Profiles.Transport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link rel="stylesheet" href="../../Styles/MainPage.css">
    <link rel="stylesheet" href="../../Styles/color.css">
    <link rel="stylesheet" href="Css/Profile.css">
</head>
    <style>
.cards-wrapper {
    display: flex;
    flex-direction: column;
    gap: 20px;
}

.header-ic {
    width: 100%;
    height: 100px;
    background-image: url(../../images/loga.png);
    background-repeat: no-repeat;
    background-position: center;
    background-size: cover;
    display: flex;
    flex-direction: column;
    align-items: center;
    cursor: pointer;
    
}

.header-aa{
    padding: 30px;
}

.offers-section {
    max-width: 800px;
    margin: 40px auto;
    padding: 0 20px;
    font-family: 'Segoe UI', sans-serif;
}

.title {
    text-align: center;
    margin-bottom: 30px;
    font-size: 28px;
    color: #333;
}

.offer-card {
    background: #fff;
    border-left: 5px solid #4CAF50;
    border-radius: 10px;
    padding: 20px;
    margin-bottom: 25px;
    box-shadow: 0 2px 12px rgba(0, 0, 0, 0.08);
    transition: transform 0.2s;
}

    .offer-card:hover {
        transform: translateY(-3px);
    }

.offer-header {
    display: flex;
    justify-content: space-between;
    font-weight: bold;
    margin-bottom: 15px;
    color: #2d2d2d;
}

.offer-body p {
    margin: 5px 0;
    color: #555;
}

.empty-info {
    text-align: center;
    font-size: 18px;
    color: #888;
}

.cars {
    position: absolute;
    width: 40%;
    padding: 14px;
    font-size: 16px;
    font-weight: 600;
    border-radius: 10px;
    border: none;
    background-color: var(--theme2);
    color: white;
    cursor: pointer;
    transition: transform 0.2s ease, box-shadow 0.3s ease;
}


/* Modern Table */
.right-panel {
    width: 100%;
    height: 100%;
}

.modern-table {
    border-radius: 12px;
    overflow: hidden;
    box-shadow: 0 4px 10px rgba(0, 0, 0, 0.1);
    background-color: #fff;
    font-family: 'Arial', sans-serif;
    border-collapse: collapse;
    padding: 10px;
}

    .modern-table th, .modern-table td {
        padding: 7px 10px;
        text-align: center;
        font-size: 14px;
        vertical-align: middle;
        border-bottom: 1px solid #f0f0f0;
    }

    .modern-table th {
        background-color: #007bff;
        color: #fff;
        font-weight: 600;
    }

    .modern-table tbody tr:nth-child(odd) {
        background-color: #f9f9f9;
    }

    .modern-table tbody tr:hover {
        background-color: #e2f3ff;
        transform: scale(1.02);
        transition: 0.3s ease-in-out;
    }

    .modern-table td, .modern-table th {
        border: none !important;
    }

    /* Buton Stil */
    .modern-table .btn {
        border: none;
        padding: 8px 16px;
        border-radius: 25px;
        font-weight: 500;
        font-size: 0.9rem;
        cursor: pointer;
        transition: 0.3s;
    }

        .modern-table .btn:hover {
            transform: scale(1.05);
            opacity: 0.8;
        }

    .modern-table .btn-success {
        background-color: #28a745;
        color: white;
    }

    .modern-table .btn-danger {
        background-color: #dc3545;
        color: white;
    }

.panel-title{
    text-align: center;
    padding: 15px 0px 15px 0px;
    font-size: 2rem;
}

/* Responsive (Mobil Uyumlu) */
@media (max-width: 768px) {
    .modern-table th, .modern-table td {
        font-size: 0.8rem;
        padding: 10px;
    }
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
        <h2 class="panel-title">Tekliflerim</h2>
    </div>
        <div class="header-ic">
            <a href="car.html" class="header-ic"></a>
        

            <div class="offers-section">
                

                <asp:Label ID="lblMesaj" runat="server" CssClass="alert alert-info" Visible="false"></asp:Label>

                <div class="right-panel">
                    <asp:GridView 
                        ID="gvTekliflerim" 
                        runat="server" 
                        CssClass="modern-table table table-striped" 
                        AutoGenerateColumns="False" 
                        EmptyDataText="Henüz hiç teklif yapmamışsınız.">

                        <Columns>
                            <asp:BoundField DataField="YukAdi" HeaderText="Yük Adı" />
                            <asp:BoundField DataField="AlinacakSehir" HeaderText="Alınacak Şehir" />
                            <asp:BoundField DataField="TeslimEdilecekSehir" HeaderText="Teslim Şehri" />
                            <asp:BoundField DataField="Tarih" HeaderText="Yük Tarihi" DataFormatString="{0:dd.MM.yyyy}" />
                            <asp:BoundField DataField="TeklifTutari" HeaderText="Teklif Tutarı (₺)" DataFormatString="{0:N2}" />
                            <asp:BoundField DataField="TeklifTarihi" HeaderText="Teklif Tarihi" DataFormatString="{0:dd.MM.yyyy HH:mm}" />
                            <asp:BoundField DataField="arac_plaka" HeaderText="Araç Plaka" />
                            <asp:BoundField DataField="tel" HeaderText="İletişim" />
                            <asp:BoundField DataField="Durum" HeaderText="Durum" />
                        </Columns>

                        <EmptyDataTemplate>
                            <div class="alert alert-warning empty-info">Henüz hiç teklif yapmamışsınız.</div>
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

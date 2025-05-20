<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="LogApp.Pages.About" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <link rel="stylesheet" href="../Styles/MainPage.css">
    <link rel="stylesheet" href="../../Styles/color.css">
    <title></title>
</head>
    <style>
                body {
            margin: 0;
            padding: 0;
            font-family: 'Segoe UI', sans-serif;
            background-color: #f4f6f9;
        }
        .container {
            max-width: 960px;
            margin: 50px auto;
            padding: 30px 40px;
            background-color: #ffffff;
            border-radius: 10px;
            box-shadow: 0 4px 12px rgba(0,0,0,0.1);
        }

        h2 {
            color: #2c3e50;
            margin-bottom: 10px;
        }

        p, ul {
            font-size: 1.05rem;
            line-height: 1.7;
            color: #444;
        }

        ul {
            padding-left: 20px;
        }

        .section {
            margin-bottom: 40px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
            <!------------------------------------------------------------------>
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
                        <a href="Profiles/Cars.aspx">Araçlarım</a>
                        <a href="logout.html">Çıkış Yap</a>
                    </div>
                </div>
                </div>
            </div>
            <hr class="header-line">
        </header>
    

               <div class="container">

            <div class="section">
                <h2>Logapp Nedir?</h2>
                <p>
                    Logapp, tır şoförleri ile yük sahiplerini tek bir dijital platformda buluşturan, kullanıcı dostu bir yük bulma uygulamasıdır.
                    Türkiye genelindeki taşımacılık ağını dijitalleştirerek sektöre hız ve güven kazandırır.
                </p>
            </div>

            <div class="section">
                <h2>Amacımız</h2>
                <p>
                    Boşta geçen sefer sürelerini en aza indirerek tır şoförlerinin kazancını artırmak ve yük sahiplerinin güvenilir nakliyecilere kolayca ulaşmasını sağlamak.
                </p>
            </div>

            <div class="section">
                <h2>Logapp ile Neler Yapabilirsiniz?</h2>
                <ul>
                    <li>Bulunduğun konuma en yakın yükleri anlık görebilirsin</li>
                    <li>Yük detaylarını ve teslimat noktalarını kolayca inceleyebilirsin</li>
                    <li>Güvenli mesajlaşma sistemi ile yük sahipleriyle iletişim kurabilirsin</li>
                    <li>Yorum ve puan sistemi sayesinde kaliteli taşımacılık güvence altına alınır</li>
                </ul>
            </div>

            <div class="section">
                <h2>Neden Logapp?</h2>
                <ul>
                    <li>Karmaşık sistemler yerine kolay kullanım</li>
                    <li>Mobil uyumlu ve her cihazdan erişilebilir arayüz</li>
                    <li>Gerçek zamanlı bildirimler ile anında yük bilgisi</li>
                    <li>Sektöre özel geliştirilmiş hızlı çözümler</li>
                </ul>
            </div>

            <div class="section">
                <h2>İletişim</h2>
                <p>
                    Destek ekibimizle her zaman iletişime geçebilirsin: <br />
                    <strong>destek@logapp.com</strong>
                </p>
            </div>

        </div>
    </form>
</body>
</html>

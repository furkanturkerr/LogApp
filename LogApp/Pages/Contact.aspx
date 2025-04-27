<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="LogApp.Pages.Contact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <link rel="stylesheet" href="../Styles/MainPage.css">
    <link rel="stylesheet" href="../../Styles/color.css">
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
 <!------------------------------------------------------------------>
            <style>

        .contact-container {
            max-width: 900px;
            margin: 50px auto;
            padding: 30px;
            background: #fff;
            border-radius: 10px;
            box-shadow: 0 8px 20px rgba(0,0,0,0.1);
        }
        .contact-container h1 {
            text-align: center;
            color: #0a66c2;
            margin-bottom: 30px;
        }
        label {
            font-weight: 600;
            margin-top: 15px;
        }
        .form-control {
            width: 100%;
            padding: 12px;
            margin-bottom: 20px;
            border: 1px solid #ccc;
            border-radius: 8px;
            font-size: 16px;
        }
        .btn-submit {
            background-color: #0a66c2;
            color: white;
            padding: 14px;
            font-size: 18px;
            border: none;
            border-radius: 8px;
            width: 100%;
            cursor: pointer;
            transition: background-color 0.3s;
            margin-top: 10px;
        }
        .btn-submit:hover {
            background-color: #084a9d;
        }
        .message {
            margin-top: 20px;
            text-align: center;
            color: green;
        }
        .map-container {
            margin-top: 40px;
            text-align: center;
        }
        iframe {
            border: 0;
            width: 100%;
            height: 300px;
            border-radius: 10px;
        }
        .company-info {
            text-align: center;
            margin-top: 30px;
            color: #555;
        }
    </style>
</head>

    <form id="form2" >
        <div class="contact-container">
            <h1>İletişim</h1>

            <asp:Label runat="server" Text="Ad Soyad:" AssociatedControlID="txtAdSoyad"></asp:Label>
            <asp:TextBox ID="txtAdSoyad" runat="server" CssClass="form-control" required="required"></asp:TextBox>

            <asp:Label runat="server" Text="E-posta Adresi:" AssociatedControlID="txtEmail"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" required="required"></asp:TextBox>

            <asp:Label runat="server" Text="Telefon Numaranız:" AssociatedControlID="txtTelefon"></asp:Label>
            <asp:TextBox ID="txtTelefon" runat="server" CssClass="form-control" TextMode="Phone"></asp:TextBox>

            <asp:Label runat="server" Text="Konu:" AssociatedControlID="ddlKonu"></asp:Label>
            <asp:DropDownList ID="ddlKonu" runat="server" CssClass="form-control">
                <asp:ListItem Text="Bilgi" Value="Bilgi"></asp:ListItem>
                <asp:ListItem Text="Destek" Value="Destek"></asp:ListItem>
                <asp:ListItem Text="Şikayet" Value="Şikayet"></asp:ListItem>
                <asp:ListItem Text="Diğer" Value="Diger"></asp:ListItem>
            </asp:DropDownList>

            <asp:Label runat="server" Text="Mesajınız:" AssociatedControlID="txtMesaj"></asp:Label>
            <asp:TextBox ID="txtMesaj" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="6" required="required"></asp:TextBox>

            <asp:Button ID="btnGonder" runat="server" Text="Mesajı Gönder" CssClass="btn-submit" OnClick="btnGonder_Click" />

            <asp:Label ID="lblSonuc" runat="server" CssClass="message"></asp:Label>

            <div class="company-info">
                <p><strong>Adres:</strong> İstanbul, Türkiye</p>
                <p><strong>Telefon:</strong> +90 555 555 55 55</p>
                <p><strong>E-posta:</strong> destek@logapp.com</p>
            </div>

            <div class="map-container">
                <iframe src="https://www.google.com/maps/embed?pb=!1m18...seninkonumlinkin..." allowfullscreen="" loading="lazy"></iframe>
            </div>
        </div>
    </form>

    </form>
</body>
</html>

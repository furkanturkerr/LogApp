<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LogApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml"/>
<head runat="server">
    <title>Giriş Yap</title>
    <link rel="stylesheet" href="../Styles/login.css">
</head>
<body>
<div class="header-ic">
    <a href="MainPage.aspx" class="header-ic"></a>
</div>

<!-- Login -->
<div class="container">
    <h2>Hesabınıza Giriş Yapın</h2>
    <form id="loginForm" runat="server">
        <div class="input-group">
            <label for="txtTC">TC Kimlik Numarası</label>
            <asp:TextBox ID="txtTC" runat="server" CssClass="input-field" Placeholder="TC Kimlik Numarası" Required="true"></asp:TextBox>
        </div>
        <div class="input-group">
            <label for="txtPassword">Şifre</label>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="input-field" TextMode="Password" Placeholder="Şifre" Required="true"></asp:TextBox>
        </div>
        <div class="forgot-password">
            <a href="#">Şifremi Unuttum?</a>
        </div>
        <asp:Button ID="btnLogin" runat="server" CssClass="login-btn" Text="Giriş Yap" OnClick="btnLogin_Click" />
    </form>
    <p>Hesabınız yok mu? <a href="Register.aspx">Üye Ol</a></p>

    <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label>
</div>

</body>
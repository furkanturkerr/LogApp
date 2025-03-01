<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="Logapp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Giriş Yap</title>
    <link rel="stylesheet" href="login.css">
</head>
<body>
    <div class="login-container">
        <h2>Giriş Yap</h2>
        <form id="form1" runat="server">
            <label for="tc">TC Kimlik Numarası:</label>
            <asp:TextBox ID="tc_tb" runat="server" placeholder="TC Kimlik Numarası" required></asp:TextBox>
            
            <label for="password">Şifre:</label>
            <asp:TextBox ID="sifre_tb" runat="server" TextMode="Password" placeholder="Şifre" required></asp:TextBox>
            
            <asp:Button ID="login_btn" runat="server" Text="Giriş Yap" OnClick="login_btn_Click" CssClass="btn" />
            <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
        </form>
    </div>
</body>
</html>

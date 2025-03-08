<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Register.aspx.vb" Inherits="Logapp.Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kayıt Ol</title>
    <link rel="stylesheet" type="text/css" href="register.css" />
</head>
<body>
<div class="header-ic">
    <a href="MainPage.aspx" class="header-ic"></a>
</div>

    <div class="container">
        <h2>Kayıt Ol</h2>
        <form id="registrationForm" method="post" runat="server">
            <div class="center">
                <div class="input-group">
                    <div class="radio-group">
                        <input type="radio" name="user-type" id="Radio1" value="yuk-veren" runat="server" />
                        <label for="Radio1">Yük Veren</label>

                        <input type="radio" name="user-type" id="Radio2" value="yuk-arayan" runat="server" />
                        <label for="Radio2">Yük Arayan</label>
                    </div>
                </div>
                <div class="input-group">
                    <asp:TextBox ID="tcInput" runat="server" placeholder="TC Kimlik Numarası" required></asp:TextBox>
                </div>
                <div class="input-group">
                    <asp:TextBox ID="firstNameInput" runat="server" placeholder="Adınızı Girin" required></asp:TextBox>
                </div>
                <div class="input-group">
                    <asp:TextBox ID="lastNameInput" runat="server" placeholder="Soyadınızı Girin" required></asp:TextBox>
                </div>
                <div class="input-group">
                    <asp:TextBox ID="plakaInput" runat="server" placeholder="Plakanızı Girin" required></asp:TextBox>
                </div>
                <div class="input-group">
                    <asp:TextBox ID="passwordInput" runat="server" TextMode="Password" placeholder="Şifre Belirleyin" required></asp:TextBox>
                </div>
                <div class="input-group">
                    <asp:TextBox ID="addressInput" runat="server" placeholder="Adresinizi Girin" required></asp:TextBox>
                </div>
            </div>
            <asp:Button ID="btnRegister" runat="server" CssClass="register-btn" Text="Kayıt Ol" OnClick="btnRegister_Click" />
            <p>Hesabınız var mı? <a href="login.aspx">Giriş Yap</a></p>
        </form>

        <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="False"></asp:Label>
    </div>
</body>
</html>

<%@ Page Language="vb" AutoEventWireup="true" CodeBehind="Register.aspx.vb" Inherits="Logapp.Register" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Kayıt Ol</title>
    <link rel="stylesheet" type="text/css" href="style.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>LogApp'e Kayıt Olun</h2>

            <label for="tc_tb">TC:</label>
            <asp:TextBox ID="tc_tb" runat="server" CssClass="textbox"></asp:TextBox>

            <p class="info-text">Yük Veren Seçerseniz Plaka Girmenize Gerek Yoktur</p>
            
            <asp:RadioButtonList ID="RadioButtonList1" runat="server">
                <asp:ListItem Value="yuk_veren">Yük Veren</asp:ListItem>
                <asp:ListItem Value="yuk_arayan">Yük Arayan</asp:ListItem>
            </asp:RadioButtonList>

            <label for="ad_tb">Ad:</label>
            <asp:TextBox ID="ad_tb" runat="server" CssClass="textbox"></asp:TextBox>

            <label for="soyad_tb">Soyad:</label>
            <asp:TextBox ID="soyad_tb" runat="server" CssClass="textbox"></asp:TextBox>

            <label for="sifre_tb">Şifre:</label>
            <asp:TextBox ID="sifre_tb" runat="server" TextMode="Password" CssClass="textbox"></asp:TextBox>

            <label for="plaka_tb">Plaka:</label>
            <asp:TextBox ID="plaka_tb" runat="server" CssClass="textbox"></asp:TextBox>

            <label for="adres_tb">Adres:</label>
            <asp:TextBox ID="adres_tb" runat="server" CssClass="textbox"></asp:TextBox>

            <asp:Button ID="kayıt_btn" runat="server" Text="Kayıt Ol" CssClass="btn" OnClick="kayıt_btn_Click" />
            <asp:Button ID="anamenu_btn" runat="server" Text="Ana Menü" CssClass="btn" />


        </div>
    </form>
</body>
</html>

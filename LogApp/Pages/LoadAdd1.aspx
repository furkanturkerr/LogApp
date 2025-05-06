<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoadAdd1.aspx.cs" Inherits="LogApp.Pages.LoadAdd1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Yük Ekle</title>
    <link rel="stylesheet" href="../Styles/LoadAdd1.css" />
    <link rel="stylesheet" href="../../Styles/color.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-wrapper">
    <asp:Button ID="Button2" runat="server" CssClass="profil-button" Text="Teklifler"  OnClick="Profil_Click"/>
    <h2>Yuk Ekleme Formu</h2>
    
        <div class="form-group">
            <label for="tcTextBox">TC</label>
            <asp:TextBox ID="tcTextBox" runat="server" CssClass="form-control" MaxLength="11" />
    </div>

    <div class="form-group">
        <label for="AlınacakSehirTextBox">Alınacak Şehir</label>
        <asp:TextBox ID="AlınacakSehirTextBox" runat="server" CssClass="form-control" MaxLength="11" />
    </div>

    <div class="form-group">
        <label for="TeslimEdilecekSehirTextBox">TeslimEdilecekSehir</label>
        <asp:TextBox ID="TeslimEdilecekSehirTextBox" runat="server" CssClass="form-control" MaxLength="50" />
    </div>

    <div class="form-group">
        <label for="TarihTextBox">Tarih</label>
        <asp:TextBox ID="TarihTextBox" runat="server" CssClass="form-control" MaxLength="50" />
    </div>

    <div class="form-group">
        <label for="AraçTipiTextBox">Araç Tipi</label>
        <asp:TextBox ID="AracTipiTextBox" runat="server" CssClass="form-control" MaxLength="50" />
    </div>

    <div class="form-group">
        <label for="YukAdiTextBox">İlan Başlığı</label>
        <asp:TextBox ID="YukAdiTextBox" runat="server" CssClass="form-control" MaxLength="50" />
    </div>

    <div class="form-group">
        <label for="FiyatTextBox">Fiyat</label>
        <asp:TextBox ID="FiyatTextBox" runat="server" CssClass="form-control" MaxLength="50" />
    </div>

    <asp:Button ID="addloadButton" runat="server" CssClass="submit-button" Text="Yük Ekle" OnClick="AddYukButton_Click" />
    
    <asp:Label ID="Label1" runat="server" Text="Label" CssClass="uyari" Visible="False"></asp:Label>
    
</div>
    </form>
</body>
</html>

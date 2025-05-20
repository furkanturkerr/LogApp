<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoadAdd1.aspx.cs" Inherits="LogApp.Pages.LoadAdd1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>Yük Ekle</title>
    <link rel="stylesheet" href="../Styles/LoadAdd1.css" />
    <link rel="stylesheet" href="../../Styles/color.css"/>
    <link rel="stylesheet" href="../../styles/mainpage.css"/>
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
    <div class="col-md-2">
        <label for="txtTarih">Tarih</label>
        <asp:TextBox ID="txtTarih" runat="server" CssClass="form-control" placeholder="gg.aa.yyyy" TextMode="Date"></asp:TextBox>
    </div>

    <div class="col-md-2">
        <label for="ddlAracTipi">Araç Tipi</label>
        <asp:DropDownList ID="ddlAracTipi" runat="server" CssClass="form-control" AppendDataBoundItems="true" AutoPostBack="True">
            <asp:ListItem Text="Araç Tipi" Value="" />
            <asp:ListItem Text="Tır" Value="Tır" />
            <asp:ListItem Text="KırkAyak" Value="KırkAyak" />
            <asp:ListItem Text="OnTeker" Value="OnTeker" />
            <asp:ListItem Text="Hafif Ticari" Value="HafifTicari" />
        </asp:DropDownList>
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

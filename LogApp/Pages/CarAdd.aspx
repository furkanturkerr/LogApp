﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CarAdd.aspx.cs" Inherits="LogApp.Pages.CarAdd" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Araç Ekle</title>
    <link rel="stylesheet" href="../Styles/caradd.css" />
    <link rel="stylesheet" href="../../Styles/color.css"/>
    <link rel="stylesheet" href="../../styles/mainpage.css"/>
</head>
<body>
 <form id="form1" runat="server">
        <div class="form-wrapper">
            <asp:Button ID="Button2" runat="server" CssClass="profil-button" Text="Araçlarım"  OnClick="Profil_Click"/>
            <h2>Araç Ekleme Formu</h2>

            <div class="form-group">
                <label for="aracAdTextBox">Araç Adı</label>
                <asp:TextBox ID="aracAdTextBox" runat="server" CssClass="form-control" MaxLength="50" />
            </div>

            <div class="form-group">
                <label for="aracMarkaTextBox">Araç Marka</label>
                <asp:TextBox ID="aracMarkaTextBox" runat="server" CssClass="form-control" MaxLength="50" />
            </div>

            <div class="form-group">
                <label for="aracSeriTextBox">Araç Seri</label>
                <asp:TextBox ID="aracSeriTextBox" runat="server" CssClass="form-control" MaxLength="50" />
            </div>

            <div class="form-group">
                <label for="aracModelTextBox">Araç Model</label>
                <asp:TextBox ID="aracModelTextBox" runat="server" CssClass="form-control" MaxLength="50" />
            </div>

            <div class="form-group">
                <label for="aracYilTextBox">Araç Yılı</label>
                <asp:TextBox ID="aracYilTextBox" runat="server" CssClass="form-control" MaxLength="4" />
            </div>

           <div class="form-group">
                <label for="ddlAracTipi">Araç Tipi</label>
<asp:DropDownList ID="ddlAracTipi" runat="server" CssClass="form-control" AppendDataBoundItems="true" AutoPostBack="True">
    <asp:ListItem Text="Araç Tipi" Value="" />
    <asp:ListItem Text="Tır" Value="Tır" />
    <asp:ListItem Text="KırkAyak" Value="KırkAyak" />
    <asp:ListItem Text="OnTeker" Value="OnTeker" />
    <asp:ListItem Text="Hafif Ticari" Value="Hafif Ticari" />
</asp:DropDownList>

            </div>

            <div class="form-group">
                <label for="aracPlakaTextBox">Araç Plaka</label>
                <asp:TextBox ID="aracPlakaTextBox" runat="server" CssClass="form-control" MaxLength="20" />
            </div>

            <asp:Button ID="addCarButton" runat="server" CssClass="submit-button" Text="Araç Ekle" OnClick="AddCarButton_Click" />
            
            <asp:Label ID="Label1" runat="server" Text="Label" CssClass="uyari" Visible="False"></asp:Label>
            
        </div>
    </form>
</body>
</html>

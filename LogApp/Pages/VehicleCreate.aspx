﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VehicleCreate.aspx.cs" Inherits="LogApp.VehicleCreate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Araç Adı<asp:TextBox ID="arac_ad_tb" runat="server"></asp:TextBox>
            <br />
            Araç Marka<asp:DropDownList ID="marka_list" runat="server" AutoPostBack="True" OnSelectedIndexChanged="marka_list_SelectedIndexChanged2">
                <asp:ListItem>Marka Seçiniz</asp:ListItem>
            </asp:DropDownList>
            <br />
            Araç Seri<asp:DropDownList ID="seri_list" runat="server" AutoPostBack="True">
                <asp:ListItem>Seri Seçiniz</asp:ListItem>
            </asp:DropDownList>
            <br />
            Araç Model<asp:DropDownList ID="model_list" runat="server" AutoPostBack="True" style="height: 25px">
                <asp:ListItem>Model Seçiniz</asp:ListItem>
            </asp:DropDownList>
            <br />
            Araç Yıl<asp:DropDownList ID="yıl_list" runat="server" AutoPostBack="True">
                <asp:ListItem>Model Yılı Seçiniz</asp:ListItem>
            </asp:DropDownList>
            <br />
            Araç Plaka<asp:TextBox ID="arac_plaka_tb" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="LabelMessage" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:Button ID="arac_kayıt_btn" runat="server" Text="Aracı Kaydet" OnClick="arac_kayıt_btn_Click" style="height: 26px" />
        </div>
    </form>
</body>
</html>

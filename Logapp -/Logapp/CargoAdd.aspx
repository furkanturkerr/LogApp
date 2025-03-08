<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CargoAdd.aspx.vb" Inherits="Logapp.CargoAdd" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Başlık<asp:TextBox ID="baslık_tb" runat="server"></asp:TextBox>
            <br />
            Fiyat<asp:TextBox ID="fiyat_tb" runat="server"></asp:TextBox>
            <br />
            Komisyon<asp:TextBox ID="komisyon_tb" runat="server"></asp:TextBox>
            <br />
            Yükleme Adresi<asp:TextBox ID="yukleme_adres_tb" runat="server"></asp:TextBox>
            <br />
            Boşaltma Adresi<asp:TextBox ID="bosaltma_adres_tb" runat="server"></asp:TextBox>
            <br />
            Tür<asp:DropDownList ID="tür_list" runat="server" AutoPostBack="True">
                <asp:ListItem>Tür Seçiniz</asp:ListItem>
                <asp:ListItem Value="parsiyel">Parsiyel Yük</asp:ListItem>
                <asp:ListItem Value="hafif">Hafif Ticari</asp:ListItem>
                <asp:ListItem Value="onteker">On Teker</asp:ListItem>
                <asp:ListItem Value="kırkayak">Kırkayak</asp:ListItem>
                <asp:ListItem Value="tır">Tır</asp:ListItem>
            </asp:DropDownList>
            <br />
            <asp:Button ID="yuk_ekle" runat="server" Text="Yük Ekle" />
        </div>
    </form>
</body>
</html>

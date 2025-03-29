<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cargo.aspx.cs" Inherits="LogApp.Cargo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="yuk_ekle_btn" runat="server" Text="Yük Ekle" OnClick="yuk_ekle_btn_Click" />
            <asp:GridView ID="GridView2" runat="server">
            </asp:GridView>
        </div>
        <p>
            <asp:GridView ID="GridView1" runat="server" DataSourceID="SqlDataSource1">
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:logConnectionString2 %>" SelectCommand="SELECT [baslık], [fiyat], [komisyon], [yükleme_adres], [bosaltma_adres], [tür] FROM [yukler]"></asp:SqlDataSource>
        </p>
    </form>
</body>
</html>

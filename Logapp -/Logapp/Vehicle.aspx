<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Vehicle.aspx.vb" Inherits="Logapp.Vehicle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server">
            </asp:GridView>
            <br />
            <asp:Button ID="arac_ekle_btn" runat="server" Text="Araç Ekle" />
        </div>
    </form>
</body>
</html>

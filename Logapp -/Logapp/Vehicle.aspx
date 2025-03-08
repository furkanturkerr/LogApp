<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Vehicle.aspx.vb" Inherits="Logapp.Vehicle" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="arac_plaka" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:BoundField DataField="tc" HeaderText="tc" SortExpression="tc" />
                    <asp:BoundField DataField="arac_ad" HeaderText="arac_ad" SortExpression="arac_ad" />
                    <asp:BoundField DataField="arac_marka" HeaderText="arac_marka" SortExpression="arac_marka" />
                    <asp:BoundField DataField="arac_seri" HeaderText="arac_seri" SortExpression="arac_seri" />
                    <asp:BoundField DataField="arac_model" HeaderText="arac_model" SortExpression="arac_model" />
                    <asp:BoundField DataField="arac_yıl" HeaderText="arac_yıl" SortExpression="arac_yıl" />
                    <asp:BoundField DataField="arac_plaka" HeaderText="arac_plaka" ReadOnly="True" SortExpression="arac_plaka" />
                    <asp:CommandField />
                    <asp:CommandField ShowEditButton="True" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:logConnectionString2 %>" SelectCommand="SELECT * FROM [araclar]"></asp:SqlDataSource>
            <br />
            <asp:Button ID="arac_ekle_btn" runat="server" Text="Araç Ekle" />
        </div>
    </form>
</body>
</html>

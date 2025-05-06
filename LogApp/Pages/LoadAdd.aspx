<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoadAdd.aspx.cs" Inherits="LogApp.Pages.LoadAdd" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Yeni İlan Oluştur</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css" />
    <style>
        .header { background-color: var(--theme); text-align:center; color: white; padding: 15px; border-radius: 10px 10px 0 0; }
        .card-custom { border: 1px solid #ccc; border-radius: 10px; padding: 20px; margin-top: 10px; }
        .map-container { height: 300px; width: 100%; margin-bottom: 20px; }
    </style>
    <link rel="stylesheet" href="../Styles/loadadd.css">
    <link rel="stylesheet" href="../../Styles/color.css">
</head>
<body>
  <form id="form1" runat="server">
        <h2>Yük Listesi</h2>
        <asp:GridView ID="gvYukler" runat="server" AutoGenerateColumns="False" OnRowCommand="gvYukler_RowCommand">
            <Columns>
                <asp:BoundField DataField="YukID" HeaderText="ID" />
                <asp:BoundField DataField="YukAdi" HeaderText="Yük Adı" />
                <asp:BoundField DataField="AlinacakSehir" HeaderText="Alınacak Şehir" />
                <asp:BoundField DataField="TeslimEdilecekSehir" HeaderText="Teslim Şehir" />
                <asp:BoundField DataField="Tarih" HeaderText="Tarih" DataFormatString="{0:dd.MM.yyyy}" />
                <asp:BoundField DataField="AracTipi" HeaderText="Araç Tipi" />
                <asp:BoundField DataField="Ucret" HeaderText="Ücret" />
                <asp:TemplateField HeaderText="İşlem">
                    <ItemTemplate>
                        <asp:Button ID="btnTeklifVer" runat="server" 
                                    Text="Teklif Ver" 
                                    CommandName="TeklifVer" 
                                    CommandArgument='<%# Eval("YukID") %>' 
                                    Visible='<%# Eval("TeklifTutar") == DBNull.Value ? true : false %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>

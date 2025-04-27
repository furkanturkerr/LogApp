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
        <div class="container mt-4">
            <div class="header">
                <h3>Yeni İlan Oluştur</h3>
            </div>
            <div class="card-custom">
                <div class="form-group row">
                    <div class="col-md-6">
                        <label>Alım Tarihi</label>
                        <asp:TextBox ID="txtAlimTarihi" runat="server" CssClass="form-control" placeholder="gg.aa.yyyy"></asp:TextBox>
                    </div>
                    <div class="col-md-6">
                        <label>Teslim Tarihi</label>
                        <asp:TextBox ID="txtTeslimTarihi" runat="server" CssClass="form-control" placeholder="gg.aa.yyyy"></asp:TextBox>
                    </div>
                </div>

                <hr />

                <asp:Button ID="btnYuklemeEkle" runat="server" CssClass="btn btn-outline-primary mb-2" Text="+ Yükleme Noktası Ekle" OnClick="btnYuklemeEkle_Click" />
                <asp:Button ID="btnTeslimatEkle" runat="server" CssClass="btn btn-outline-success mb-2" Text="+ Teslimat Noktası Ekle" OnClick="btnTeslimatEkle_Click" />

                <asp:PlaceHolder ID="phYuklemeNoktalari" runat="server" />
                <asp:PlaceHolder ID="phTeslimatNoktalari" runat="server" />

                <asp:Button ID="btnDevamEt" runat="server" CssClass="btn btn-primary float-right" Text="Devam Et" OnClick="btnDevamEt_Click" />
            </div>
        </div>
    </form>
</body>
</html>

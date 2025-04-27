<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchLoad.aspx.cs" Inherits="LogApp.Pages.CargoMain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
            <link rel="stylesheet" href="../Styles/MainPage.css">
    <link rel="stylesheet" href="../../Styles/color.css">
</head>
<body>
<form id="form1" runat="server">
    <!------------------------------------------------------------------>
        <header class="header">
    <div class="header-top">
        <div class="header-top-lr">
            <div class="header-top-left">
                <a href="#"><i class="fa-solid fa-envelope"></i> logapp@gmail.com</a>
                <a href="#"><i class="fa-solid fa-location-dot"></i> İstanbul, Türkiye</a>
            </div>
            <div class="header-top-right">
                <div class="top-right-lr">
                    <div class="top-right-left">
                        <a href="#">Yardım</a>
                        <a href="#">Destek</a>
                        <a href="#">İletişim</a>
                    </div>
                    <div class="top-right-right">
                        <i class="fa-brands fa-instagram"></i>
                        <i class="fa-brands fa-linkedin"></i>
                        <i class="fa-brands fa-facebook"></i>
                        <i class="fa-brands fa-youtube"></i>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="header-lower">
        <div class="header-icon">
            <a href="car.aspx" class="header-icon"></a>
        </div>
        <div class="header-link">
            <a href="MainPage.aspx">Anasayfa</a>
            <a href="About.aspx">Hakkımızda</a>
            <a href="SearchLoad.aspx">Yük Arıyorum</a>
            <a href="Contact.aspx">İletişim</a>
        </div>
        <div class="header-login">
            <asp:Button ID="btnLogin" runat="server" CssClass="login" Text="Giriş Yap" OnClick="btnLogin_Click" />
            <asp:Button ID="btnRegister" runat="server" CssClass="login" Text="Kayıt Ol" OnClick="btnRegister_Click" />
             <div class="profile-container">
           <asp:Button ID="btnProfile" runat="server" CssClass="profile" Text="Profilim" OnClick="btnProfile_Click" Visible="false" /><i class="fa-solid fa-angle-down"></i>
            <div class="menu">
                <a href="Profiles/Cars.aspx">Araçlarım</a>
                <a href="logout.html">Çıkış Yap</a>
            </div>
        </div>
        </div>
    </div>
    <hr class="header-line">
</header>
<!------------------------------------------------------------------>
        <div class="container py-5">

            <!-- Filtre Alanı -->
            <div class="row mb-4 g-3">
                <div class="col-md-2">
                    <asp:DropDownList ID="ddlAlinacakSehir" runat="server" CssClass="form-select" AppendDataBoundItems="true">
                        <asp:ListItem Text="Alınacak Şehir" Value="" />
                    </asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="ddlTeslimSehir" runat="server" CssClass="form-select" AppendDataBoundItems="true">
                        <asp:ListItem Text="Teslim Edilecek Şehir" Value="" />
                    </asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="txtTarih" runat="server" CssClass="form-control" placeholder="gg.aa.yyyy" TextMode="Date"></asp:TextBox>
                </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="ddlAracTipi" runat="server" CssClass="form-select" AppendDataBoundItems="true">
                        <asp:ListItem Text="Araç Tipi" Value="" />
                    </asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <asp:TextBox ID="txtIlanAra" runat="server" CssClass="form-control" placeholder="İlanda Ara..."></asp:TextBox>
                </div>
                <div class="col-md-2 d-flex gap-2">
                    <asp:Button ID="btnAra" runat="server" Text="Ara" CssClass="btn btn-primary w-50" OnClick="btnAra_Click" />
                    <asp:Button ID="btnTemizle" runat="server" Text="Temizle" CssClass="btn btn-secondary w-50" OnClick="btnTemizle_Click" />
                </div>
            </div>

            <!-- İlanlar Listesi -->
            <asp:GridView ID="gvYukler" runat="server" CssClass="table table-striped" AutoGenerateColumns="False" OnRowCommand="gvYukler_RowCommand">
                <Columns>
                    <asp:BoundField DataField="YukAdi" HeaderText="Yük Adı" />
                    <asp:BoundField DataField="AlinacakSehir" HeaderText="Alınacak Şehir" />
                    <asp:BoundField DataField="TeslimEdilecekSehir" HeaderText="Teslim Şehri" />
                    <asp:BoundField DataField="Tarih" HeaderText="Tarih" DataFormatString="{0:dd.MM.yyyy}" />
                    <asp:BoundField DataField="AracTipi" HeaderText="Araç Tipi" />
                    <asp:BoundField DataField="Ucret" HeaderText="Ücret (₺)" DataFormatString="{0:C}" />

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:Button ID="btnTeklifVer" runat="server" Text="Teklif Ver" CommandName="TeklifVer" CommandArgument='<%# Eval("YukID") %>' CssClass="btn btn-success btn-sm" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>

        <!-- Modal (Teklif Ver Popup) -->
        <div class="modal fade" id="teklifModal" tabindex="-1" aria-labelledby="teklifModalLabel" aria-hidden="true">
          <div class="modal-dialog">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title" id="teklifModalLabel">Teklif Ver</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Kapat"></button>
              </div>
              <div class="modal-body">
                  <asp:HiddenField ID="hfYukID" runat="server" />
                  <div class="mb-3">
                      <label for="txtTeklifTutar" class="form-label">Teklif Tutarı (₺)</label>
                      <asp:TextBox ID="txtTeklifTutar" runat="server" CssClass="form-control" TextMode="Number" />
                  </div>
              </div>
              <div class="modal-footer">
                <asp:Button ID="btnTeklifGonder" runat="server" Text="Gönder" CssClass="btn btn-primary" OnClick="btnTeklifGonder_Click" />
              </div>
            </div>
          </div>
        </div>

    </form>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>
</html>

Imports System.Data.SqlClient
Imports System.Runtime.Remoting.Contexts
Imports System.Security.Cryptography

Public Class Register
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub kayıt_btn_Click(sender As Object, e As EventArgs) Handles kayıt_btn.Click

        Dim baglantı As New SqlConnection("Data Source=.;Initial Catalog=log;Integrated Security=True")


        Dim tc, ad, soyad, plaka, adres, sifre, durum As String

        'Dim sql As String = "insert into uyeler tc,ad,soyad,adres,sifre,durum,plaka values
        '('" & tc & "' '" & ad & "' '" & soyad & "' '" & adres & "' '" & sifre & "' '" & durum & "' '" & plaka & "')"


        If (tc_tb.Text <> "" And ad_tb.Text <> "" And soyad_tb.Text <> "" And adres_tb.Text <> "" And
            (RadioButtonList1.SelectedValue = "yuk_veren" Or RadioButtonList1.SelectedValue = "yuk_arayan")) Then

            tc = tc_tb.Text
            ad = ad_tb.Text
            soyad = soyad_tb.Text
            sifre = sifre_tb.Text
            plaka = plaka_tb.Text
            adres = adres_tb.Text

            Dim sql As String = "INSERT INTO uyeler (tc, ad, soyad, adres, sifre, durum, plaka) VALUES (@tc, @ad, @soyad, @adres, @sifre, @durum, @plaka)"
            Dim sql2 As String = "select tc from uyeler where tc = '" & tc & "'"

            If (RadioButtonList1.SelectedValue = "yuk_veren") Then
                durum = "yuk_veren"
            ElseIf (RadioButtonList1.SelectedValue = "yuk_arayan") Then
                durum = "yuk_arayan"
            End If

            Dim enc As Encoding = Encoding.GetEncoding("iso-8859-9")
            Dim kaynakbyte() As Byte = enc.GetBytes(sifre)
            Dim md5 As New MD5CryptoServiceProvider
            Dim ByteHach() As Byte
            ByteHach = md5.ComputeHash(kaynakbyte)
            Dim sifremd5 As New StringBuilder
            Dim sonucbyte As Byte
            For Each sonucbyte In ByteHach
                sifremd5.Append(sonucbyte.ToString("x2").ToUpper)
            Next
            Dim guvenliSifre As String
            guvenliSifre = sifremd5.ToString

            Dim komut_kontrol As New SqlCommand(sql2, baglantı)
            Dim veriokuyucu As SqlDataReader
            baglantı.Open()
            veriokuyucu = komut_kontrol.ExecuteReader
            If veriokuyucu.HasRows Then
                MsgBox("Kullanıcı zaten kayıtlı", MsgBoxStyle.Critical, "uyarı")
                baglantı.Close()
            Else
                baglantı.Close()
                baglantı.Open()
                Dim komut As New SqlCommand(sql, baglantı)
                komut.ExecuteNonQuery()
                baglantı.Close()
                MsgBox("kayıt tamamlandı", MsgBoxStyle.OkOnly, "kayıt")
            End If
        Else
                MsgBox("noo!!!")
        End If


    End Sub
End Class
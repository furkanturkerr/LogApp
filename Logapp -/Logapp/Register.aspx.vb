Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class Register
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Protected Sub kayıt_btn_Click(sender As Object, e As EventArgs) Handles kayıt_btn.Click

        If tc_tb.Text <> "" And ad_tb.Text <> "" And soyad_tb.Text <> "" And adres_tb.Text <> "" And
            (RadioButtonList1.SelectedValue = "yuk_veren" Or RadioButtonList1.SelectedValue = "yuk_arayan") Then

            Dim tc As String = tc_tb.Text
            Dim ad As String = ad_tb.Text
            Dim soyad As String = soyad_tb.Text
            Dim sifre As String = sifre_tb.Text
            Dim adres As String = adres_tb.Text

            Dim durum As String = ""

            If RadioButtonList1.SelectedValue = "yuk_veren" Then
                durum = "yuk_veren"
            ElseIf RadioButtonList1.SelectedValue = "yuk_arayan" Then
                durum = "yuk_arayan"
            End If

            If String.IsNullOrEmpty(durum) Then
                MsgBox("Lütfen yük veren veya yük arayan seçeneğini seçin!", MsgBoxStyle.Critical, "Hata")
                Exit Sub
            End If

            Dim enc As Encoding = Encoding.GetEncoding("iso-8859-9")
            Dim kaynakbyte() As Byte = enc.GetBytes(sifre)
            Dim md5 As New MD5CryptoServiceProvider
            Dim ByteHach() As Byte = md5.ComputeHash(kaynakbyte)
            Dim sifremd5 As New StringBuilder
            For Each sonucbyte As Byte In ByteHach
                sifremd5.Append(sonucbyte.ToString("x2").ToUpper)
            Next
            Dim guvenliSifre As String = sifremd5.ToString()

            Dim sql As String = "INSERT INTO uyeler (tc, ad, soyad, adres, sifre, durum) VALUES (@tc, @ad, @soyad, @adres, @sifre, @durum)"
            Dim sql2 As String = "SELECT tc FROM uyeler WHERE tc = @tc"

            Using baglantı As New SqlConnection("Data Source=.;Initial Catalog=log;Integrated Security=True")
                baglantı.Open()

                Using komut_kontrol As New SqlCommand(sql2, baglantı)
                    komut_kontrol.Parameters.AddWithValue("@tc", tc)
                    Using veriokuyucu As SqlDataReader = komut_kontrol.ExecuteReader()
                        If veriokuyucu.HasRows Then
                            MsgBox("Kullanıcı zaten kayıtlı", MsgBoxStyle.Critical, "Uyarı")
                            Exit Sub
                        End If
                    End Using
                End Using

                Using komut As New SqlCommand(sql, baglantı)
                    komut.Parameters.AddWithValue("@tc", tc)
                    komut.Parameters.AddWithValue("@ad", ad)
                    komut.Parameters.AddWithValue("@soyad", soyad)
                    komut.Parameters.AddWithValue("@adres", adres)
                    komut.Parameters.AddWithValue("@sifre", guvenliSifre)
                    komut.Parameters.AddWithValue("@durum", durum)

                    komut.ExecuteNonQuery()
                    MsgBox("Kayıt tamamlandı", MsgBoxStyle.OkOnly, "Kayıt")
                End Using
            End Using
        Else
            MsgBox("Lütfen tüm alanları eksiksiz doldurun!", MsgBoxStyle.Critical, "Hata")
        End If

    End Sub

    Protected Sub Button1_Click(sender As Object, e As EventArgs) Handles anamenu_btn.Click
        Response.Redirect("MainPage.aspx")
    End Sub
End Class

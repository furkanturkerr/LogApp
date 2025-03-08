Imports System.Data.SqlClient
Imports System.Security.Cryptography
Imports System.Text

Public Class Register
    Inherits System.Web.UI.Page

    Protected Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        If tcInput.Text <> "" And firstNameInput.Text <> "" And lastNameInput.Text <> "" And addressInput.Text <> "" And
    (Radio1.Checked AndAlso Radio1.Value = "yuk-veren" Or Radio2.Checked AndAlso Radio2.Value = "yuk-alan") Then

            Dim tc As String = tcInput.Text
            Dim ad As String = firstNameInput.Text
            Dim soyad As String = lastNameInput.Text
            Dim sifre As String = passwordInput.Text
            Dim plaka As String = plakaInput.Text
            Dim adres As String = addressInput.Text

            Dim durum As String = ""

            If Radio1.Value = "yuk-veren" Then
                durum = "yuk_veren"
            ElseIf Radio2.Value = "yuk-alan" Then
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

            Dim sql As String = "INSERT INTO uyeler (tc, ad, soyad, plaka, adres, sifre, durum) VALUES (@tc, @ad, @soyad, @plaka, @adres, @sifre, @durum)"
            Dim sql2 As String = "SELECT tc FROM uyeler WHERE tc = @tc"

            Using baglantı As New SqlConnection("Data Source=.;Initial Catalog=LogApp;Integrated Security=True")
                baglantı.Open()

                Using komut_kontrol As New SqlCommand(sql2, baglantı)
                    komut_kontrol.Parameters.AddWithValue("@tc", tc)
                    Using veriokuyucu As SqlDataReader = komut_kontrol.ExecuteReader()
                        If veriokuyucu.HasRows Then
                            lblError.Text = "Kullanıcı zaten kayıtlı"
                            lblError.Visible = True
                            Exit Sub
                        End If
                    End Using
                End Using

                Using komut As New SqlCommand(sql, baglantı)
                    komut.Parameters.AddWithValue("@tc", tc)
                    komut.Parameters.AddWithValue("@ad", ad)
                    komut.Parameters.AddWithValue("@soyad", soyad)
                    komut.Parameters.AddWithValue("@plaka", plaka)
                    komut.Parameters.AddWithValue("@adres", adres)
                    komut.Parameters.AddWithValue("@sifre", guvenliSifre)
                    komut.Parameters.AddWithValue("@durum", durum)

                    komut.ExecuteNonQuery()
                    Response.Redirect("Login.aspx")
                End Using
            End Using
        Else
            lblError.Text = "Geçersiz TC veya şifre! Lütfen tekrar deneyin."
            lblError.Visible = True
        End If
    End Sub
End Class

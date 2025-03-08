Imports System.Data.SqlClient
Imports System.Reflection
Imports System.Windows

Public Class CargoAdd
    Inherits System.Web.UI.Page



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim tc As String = Session("tc")

        If String.IsNullOrEmpty(tc) Then
            MsgBox("TC bilgisi eksik!", MsgBoxStyle.Critical, "Hata")
            Exit Sub
        End If

    End Sub

    Protected Sub yuk_ekle_Click(sender As Object, e As EventArgs) Handles yuk_ekle.Click

        Dim tc, baslık, fiyat, komisyon, yukleme_adres, bosaltma_adres, tür As String
        tc = Session("tc")
        baslık = baslık_tb.Text
        fiyat = fiyat_tb.Text
        komisyon = komisyon_tb.Text
        yukleme_adres = yukleme_adres_tb.Text
        bosaltma_adres = bosaltma_adres_tb.Text
        tür = tür_list.SelectedValue


        Using baglantı As New SqlConnection("Data Source=.;Initial Catalog=log;Integrated Security=True")
            baglantı.Open()

            'Dim sql2 As String = "SELECT durum FROM uyeler WHERE tc = @tc"
            'Using komut_kontrol As New SqlCommand(sql2, baglantı)
            '    komut_kontrol.Parameters.AddWithValue("@tc", tc)
            '    Using veriokuyucu As SqlDataReader = komut_kontrol.ExecuteReader()
            '        If veriokuyucu.HasRows Then
            '            MsgBox("Araç zaten kayıtlı", MsgBoxStyle.Critical, "Uyarı")
            '            Exit Sub
            '        End If
            '    End Using
            'End Using

            Dim sql As String = "INSERT INTO araclar (tc, baslık, fiyat, komisyon, yukleme_adres, bosaltma_adres, tür) VALUES (@tc, @baslık, @fiyat, @komisyon, @yukleme_adres, @bosaltma_adres, @tür)"
            Using komut As New SqlCommand(sql, baglantı)
                komut.Parameters.AddWithValue("@tc", tc)
                komut.Parameters.AddWithValue("@baslık", baslık)
                komut.Parameters.AddWithValue("@fiyat", fiyat)
                komut.Parameters.AddWithValue("@komisyon", komisyon)
                komut.Parameters.AddWithValue("@yukleme_adres", yukleme_adres)
                komut.Parameters.AddWithValue("@bosaltma_adres", bosaltma_adres)
                komut.Parameters.AddWithValue("@tür", tür)

                komut.ExecuteNonQuery()
                MsgBox("Yük Kayıdı tamamlandı", MsgBoxStyle.OkOnly, "Kayıt")
            End Using
        End Using
    End Sub
End Class
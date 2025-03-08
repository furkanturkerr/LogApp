Imports System.Data.SqlClient

Public Class Cargo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tc As String = Session("tc")
        Using baglantı As New SqlConnection("Data Source=.;Initial Catalog=log;Integrated Security=True")
            baglantı.Open()
            Dim sql2 As String = "SELECT durum FROM uyeler WHERE tc = @tc"
            Using komut_kontrol As New SqlCommand(sql2, baglantı)
                komut_kontrol.Parameters.AddWithValue("@tc", tc)
                Using veriokuyucu As New SqlDataAdapter(komut_kontrol)
                    Dim durum As New DataSet
                    veriokuyucu.Fill(durum)
                    GridView2.DataSource = durum.Tables(0)
                    GridView2.DataBind()
                    'If durum = "yuk_arayan" Then
                    '    yuk_ekle_btn.Visible = False
                    'End If
                End Using
            End Using
        End Using

    End Sub

    Protected Sub yuk_ekle_btn_Click(sender As Object, e As EventArgs) Handles yuk_ekle_btn.Click
        Response.Redirect("CargoAdd.aspx")
    End Sub
End Class
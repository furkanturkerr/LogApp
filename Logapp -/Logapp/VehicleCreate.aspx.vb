Imports System.Data.SqlClient

Public Class VehicleCreate
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Dim sql As String = "select marka from arac_katalog"
            Dim baglantı As New SqlConnection("Data Source=.;Initial Catalog=log;Integrated Security=True")
            Dim verial As New SqlDataAdapter(sql, baglantı)
            Dim ds As New DataSet
            verial.Fill(ds)

            marka_list.DataSource = ds.Tables(0)
            marka_list.DataTextField = "marka"
            marka_list.DataValueField = "marka"
            marka_list.DataBind()
            marka_list.Items.Insert(0, "Marka Seçiniz")
        End If
        Dim tc As String = Session("tc")
        If String.IsNullOrEmpty(tc) Then
            MsgBox("TC bilgisi eksik!", MsgBoxStyle.Critical, "Hata")
            Exit Sub
        End If


    End Sub

    Protected Sub marka_list_SelectedIndexChanged(sender As Object, e As EventArgs) Handles marka_list.SelectedIndexChanged
        Dim sql As String = "select seri from arac_katalog where marka='" & marka_list.SelectedItem.Text & "'"
        Dim baglantı As New SqlConnection("Data Source=.;Initial Catalog=log;Integrated Security=True")
        Dim verial As New SqlDataAdapter(sql, baglantı)
        Dim ds As New DataSet
        verial.Fill(ds)

        seri_list.DataSource = ds.Tables(0)
        seri_list.DataTextField = "seri"
        seri_list.DataValueField = "seri"
        seri_list.DataBind()
        seri_list.Items.Insert(0, "Seri Seçiniz")
    End Sub

    Protected Sub seri_list_SelectedIndexChanged(sender As Object, e As EventArgs) Handles seri_list.SelectedIndexChanged
        Dim sql As String = "select model from arac_katalog where seri='" & seri_list.SelectedItem.Text & "'"
        Dim baglantı As New SqlConnection("Data Source=.;Initial Catalog=log;Integrated Security=True")
        Dim verial As New SqlDataAdapter(sql, baglantı)
        Dim ds As New DataSet
        verial.Fill(ds)

        model_list.DataSource = ds.Tables(0)
        model_list.DataTextField = "model"
        model_list.DataValueField = "model"
        model_list.DataBind()
        model_list.Items.Insert(0, "Model Seçiniz")
    End Sub

    Protected Sub model_list_SelectedIndexChanged(sender As Object, e As EventArgs) Handles model_list.SelectedIndexChanged
        Dim sql As String = "select yıl from arac_katalog where model='" & model_list.SelectedItem.Text & "'"
        Dim baglantı As New SqlConnection("Data Source=.;Initial Catalog=log;Integrated Security=True")
        Dim verial As New SqlDataAdapter(sql, baglantı)
        Dim ds As New DataSet
        verial.Fill(ds)

        yıl_list.DataSource = ds.Tables(0)
        yıl_list.DataTextField = "yıl"
        yıl_list.DataValueField = "yıl"
        yıl_list.DataBind()
        yıl_list.Items.Insert(0, "Model Yılı Seçiniz")
    End Sub

    Protected Sub arac_kayıt_btn_Click(sender As Object, e As EventArgs) Handles arac_kayıt_btn.Click
        Dim ad, marka, seri, model, yıl, plaka, tc As String
        ad = arac_ad_tb.Text
        marka = marka_list.SelectedItem.Text
        seri = seri_list.SelectedItem.Text
        model = model_list.SelectedItem.Text
        yıl = yıl_list.SelectedItem.Text
        plaka = arac_plaka_tb.Text
        tc = Session("tc")

        Using baglantı As New SqlConnection("Data Source=.;Initial Catalog=log;Integrated Security=True")
            baglantı.Open()

            Dim sql2 As String = "SELECT * FROM araclar WHERE arac_plaka = @plaka"
            Using komut_kontrol As New SqlCommand(sql2, baglantı)
                komut_kontrol.Parameters.AddWithValue("@plaka", arac_plaka_tb.Text)
                Using veriokuyucu As SqlDataReader = komut_kontrol.ExecuteReader()
                    If veriokuyucu.HasRows Then
                        MsgBox("Araç zaten kayıtlı", MsgBoxStyle.Critical, "Uyarı")
                        Exit Sub
                    End If
                End Using
            End Using

            Dim sql As String = "INSERT INTO araclar (tc, arac_ad, arac_marka, arac_seri, arac_model, arac_yıl, arac_plaka) VALUES (@tc, @ad, @marka, @seri, @model, @yil, @plaka)"
            Using komut As New SqlCommand(sql, baglantı)
                komut.Parameters.AddWithValue("@tc", tc)
                komut.Parameters.AddWithValue("@ad", ad)
                komut.Parameters.AddWithValue("@marka", marka)
                komut.Parameters.AddWithValue("@seri", seri)
                komut.Parameters.AddWithValue("@model", model)
                komut.Parameters.AddWithValue("@yil", yıl)
                komut.Parameters.AddWithValue("@plaka", plaka)

                komut.ExecuteNonQuery()
                MsgBox("Kayıt tamamlandı", MsgBoxStyle.OkOnly, "Kayıt")
            End Using
        End Using

    End Sub
End Class

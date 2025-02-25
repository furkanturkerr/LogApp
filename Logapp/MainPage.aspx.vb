Public Class WebForm1
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub uye_btn_Click(sender As Object, e As EventArgs) Handles uye_btn.Click
        Response.Redirect("Register.aspx")
    End Sub

    Protected Sub giris_btn_Click(sender As Object, e As EventArgs) Handles giris_btn.Click
        Response.Redirect("WebForm2.aspx")
    End Sub
End Class
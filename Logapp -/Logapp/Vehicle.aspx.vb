Public Class Vehicle
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub arac_ekle_btn_Click(sender As Object, e As EventArgs) Handles arac_ekle_btn.Click
        Response.Redirect("VehicleCreate.aspx")
    End Sub
End Class
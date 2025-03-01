Public Class WebForm3
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnMainPage_Click(sender As Object, e As EventArgs) Handles giris_btn.Click
        Response.Redirect("MainPage.aspx")
    End Sub

    Protected Sub btnVehicle_Click(sender As Object, e As EventArgs) Handles arac_btn.Click
        Response.Redirect("Vehicle.aspx")
    End Sub
End Class
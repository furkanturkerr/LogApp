Public Class WebForm3
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim tc As String = Session("tc")
        If String.IsNullOrEmpty(tc) Then
            MsgBox("TC bilgisi eksik!", MsgBoxStyle.Critical, "Hata")
            Exit Sub
        End If
    End Sub

    Protected Sub btnMainPage_Click(sender As Object, e As EventArgs) Handles giris_btn.Click
        Response.Redirect("MainPage.aspx")
    End Sub

    Protected Sub btnVehicle_Click(sender As Object, e As EventArgs) Handles arac_btn.Click
        Response.Redirect("Vehicle.aspx")
    End Sub

    Protected Sub btnCargo_Click(sender As Object, e As EventArgs) Handles yuk_btn.Click
        Response.Redirect("Cargo.aspx")
    End Sub
End Class
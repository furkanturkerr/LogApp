Imports System.Data.SqlClient
Imports System.Security.Cryptography

Partial Class Login
    Inherits System.Web.UI.Page

    Protected Sub login_btn_Click(sender As Object, e As EventArgs)

        Dim tc As String = tc_tb.Text
        Dim sifre As String = sifre_tb.Text


        Dim enc As Encoding = Encoding.GetEncoding("iso-8859-9")
        Dim kaynakbyte() As Byte = enc.GetBytes(sifre)
        Dim md5 As New MD5CryptoServiceProvider
        Dim byteHosh() As Byte
        byteHosh = md5.ComputeHash(kaynakbyte)
        Dim sifremd5 As New StringBuilder
        Dim sonucbyte As Byte
        For Each sonucbyte In byteHosh
            sifremd5.Append(sonucbyte.ToString("x2").ToUpper)
        Next
        Dim guvenlisifre As String
        guvenlisifre = sifremd5.ToString


        Dim connectionString As String = "Data Source=.;Initial Catalog=log;Integrated Security=True"
        Dim connection As New SqlConnection(connectionString)
        Dim query As String = "SELECT * FROM uyeler WHERE TC=@tc AND Sifre=@sifre"
        Dim command As New SqlCommand(query, connection)


        command.Parameters.AddWithValue("@tc", tc)
        command.Parameters.AddWithValue("@sifre", guvenlisifre)

        connection.Open()
        Dim reader As SqlDataReader = command.ExecuteReader()

        If reader.HasRows Then
            Label1.Text = "Giriş başarılı!"
            Response.Redirect("WebForm3.aspx")
        Else
            Label1.Text = "TC Kimlik Numarası veya Şifre hatalı!"
        End If

        Session("tc") = tc_tb.Text
        Response.Redirect("VehicleCreate.aspx")

        connection.Close()
    End Sub
End Class

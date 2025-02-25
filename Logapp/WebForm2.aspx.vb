Imports System.Data.SqlClient

Partial Class WebForm2
    Inherits System.Web.UI.Page

    Protected Sub login_btn_Click(sender As Object, e As EventArgs)
        ' TC ve Şifreyi al
        Dim tc As String = tc_tb.Text
        Dim sifre As String = sifre_tb.Text

        ' Veritabanı bağlantısı
        Dim connectionString As String = "Data Source=DESKTOP-570E5NS;Initial Catalog=veri;Integrated Security=True"
        Dim connection As New SqlConnection(connectionString)
        Dim query As String = "SELECT * FROM Users WHERE TC=@tc AND Sifre=@sifre"
        Dim command As New SqlCommand(query, connection)

        ' Parametreleri ekle
        command.Parameters.AddWithValue("@tc", tc)
        command.Parameters.AddWithValue("@sifre", sifre)

        connection.Open()
        Dim reader As SqlDataReader = command.ExecuteReader()

        If reader.HasRows Then
            ' Kullanıcı girişi başarılı
            Label1.Text = "Giriş başarılı!"
            ' Diğer işlemler burada yapılabilir (Yönlendirme vs.)
        Else
            ' Kullanıcı girişi başarısız
            Label1.Text = "TC Kimlik Numarası veya Şifre hatalı!"
        End If

        connection.Close()
    End Sub
End Class

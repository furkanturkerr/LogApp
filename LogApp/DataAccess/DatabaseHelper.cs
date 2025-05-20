using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Security.Cryptography;
using System.Text;
using System.Configuration;
using System.Data;

public class DatabaseHelper
{
    private readonly string connectionString = "Data Source=.;Initial Catalog=LogApp;Integrated Security=True";
    public bool KullaniciVarMi(string tc)
    {
        string sqlCheck = "SELECT COUNT(*) FROM uyeler WHERE TC=@tc";

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(sqlCheck, conn))
            {
                cmd.Parameters.AddWithValue("@tc", tc);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
        }
    }

    // Kullanıcı giriş yapma metodu
    public bool KullaniciGirisYap(string tc, string sifre)
    {
        string guvenliSifre = ComputeMD5Hash(sifre);
        string query = "SELECT * FROM uyeler WHERE TC=@tc AND Sifre=@sifre";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@tc", tc);
                command.Parameters.AddWithValue("@sifre", guvenliSifre);

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    return reader.HasRows;
                }
            }
        }
    }

    // Kullanıcı ekleme metodu
    public bool KullaniciEkle(string tc, string durum, string ad, string soyad, string telefon, string adres, string sifre)
    {
        string sqlInsert = "INSERT INTO uyeler (TC, Durum, Ad, Soyad, tel, Sifre, Adres) VALUES (@tc, @durum, @ad, @soyad, @tel, @sifre, @adres)";
        string guvenliSifre = ComputeMD5Hash(sifre);

        using (SqlConnection conn = new SqlConnection(connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand(sqlInsert, conn))
            {
                cmd.Parameters.AddWithValue("@tc", tc);
                cmd.Parameters.AddWithValue("@durum", durum);
                cmd.Parameters.AddWithValue("@ad", ad);
                cmd.Parameters.AddWithValue("@soyad", soyad);
                cmd.Parameters.AddWithValue("@tel", telefon);
                cmd.Parameters.AddWithValue("@sifre", guvenliSifre);
                cmd.Parameters.AddWithValue("@adres", adres);
                
                
                

                int result = cmd.ExecuteNonQuery();
                return result > 0;  // Eğer işlem başarılıysa true döner
            }
        }
    }
        // Kullanıcı bilgilerini getirme metodu
        public SqlDataReader KullaniciBilgileriniGetir(string tc)
    {
        string query = "SELECT * FROM uyeler WHERE TC=@tc";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@tc", tc);

        connection.Open();
        return command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
    }

    // Şifre güncelleme metodu
    public bool SifreGuncelle(string tc, string yeniSifre)
    {
        string guvenliSifre = ComputeMD5Hash(yeniSifre);
        string query = "UPDATE uyeler SET Sifre=@sifre WHERE TC=@tc";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@tc", tc);
                command.Parameters.AddWithValue("@sifre", guvenliSifre);

                connection.Open();
                return command.ExecuteNonQuery() > 0;
            }
        }
    }

    // Kullanıcı BİLGİLERİNİ GÜNCELLEME
    public bool KullaniciBilgileriniGuncelle(string tc, string ad, string soyad, string tel, string mail, string adres)
    {
        string query = "UPDATE uyeler SET Ad=@ad, Soyad=@soyad, tel=@tel, mail=@mail, Adres=@adres WHERE TC=@tc";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@tc", tc);
                command.Parameters.AddWithValue("@ad", ad);
                command.Parameters.AddWithValue("@soyad", soyad);
                command.Parameters.AddWithValue("@tel", tel);
                command.Parameters.AddWithValue("@mail",mail);
                command.Parameters.AddWithValue("@adres", adres);

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }
    }

        private string ComputeMD5Hash(string input)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2")); // Hexadecimal format
            }
            return sb.ToString();
        }
    }
}

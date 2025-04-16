using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogApp.Pages
{
    public partial class CarAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddCarButton_Click(object sender, EventArgs e)
        {
            string tc = tcTextBox.Text.Trim();
            string aracAd = aracAdTextBox.Text.Trim();
            string aracMarka = aracMarkaTextBox.Text.Trim();
            string aracSeri = aracSeriTextBox.Text.Trim();
            string aracModel = aracModelTextBox.Text.Trim();
            string aracYil = aracYilTextBox.Text.Trim();
            string aracPlaka = aracPlakaTextBox.Text.Trim();

            // Veritabanı bağlantısı
            string connectionString = "your_connection_string_here";  // Veritabanı bağlantı dizesini buraya girin
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO araclar (tc, arac_ad, arac_marka, arac_seri, arac_model, arac_yil, arac_plaka) " +
                               "VALUES (@tc, @arac_ad, @arac_marka, @arac_seri, @arac_model, @arac_yil, @arac_plaka)";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@tc", tc);
                command.Parameters.AddWithValue("@arac_ad", aracAd);
                command.Parameters.AddWithValue("@arac_marka", aracMarka);
                command.Parameters.AddWithValue("@arac_seri", aracSeri);
                command.Parameters.AddWithValue("@arac_model", aracModel);
                command.Parameters.AddWithValue("@arac_yil", aracYil);
                command.Parameters.AddWithValue("@arac_plaka", aracPlaka);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        // Başarıyla eklendiğinde yapılacak işlemler
                        Response.Write("<script>alert('Araç başarıyla eklendi.');</script>");
                    }
                    else
                    {
                        // Hata durumunda yapılacak işlemler
                        Response.Write("<script>alert('Bir hata oluştu.');</script>");
                    }
                }
                catch (Exception ex)
                {
                    // Hata mesajını gösterme
                    Response.Write("<script>alert('Hata: " + ex.Message + "');</script>");
                }
            }
        }

    }
}
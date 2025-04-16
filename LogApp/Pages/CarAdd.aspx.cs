using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
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

        protected void Profil_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profiles/Profil.aspx");
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

            // TC kontrolü
            if (Session["user"] != null && Session["user"].ToString() == tc)
            {
                // Seri numarası ve plaka kontrolü
                string connectionString = "Data Source=.;Initial Catalog=LogApp;Integrated Security=True";  // Veritabanı bağlantı dizesi
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Veri kontrolü için SQL sorgusu
                    string checkQuery = "SELECT COUNT(*) FROM araclar WHERE arac_seri = @arac_seri AND arac_plaka = @arac_plaka";
                    SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@arac_seri", aracSeri);
                    checkCommand.Parameters.AddWithValue("@arac_plaka", aracPlaka);

                    try
                    {
                        connection.Open();
                        int count = (int)checkCommand.ExecuteScalar();

                        if (count > 0)
                        {
                            // Seri numarası ve plaka zaten var
                            Label1.Text = "Bu seri numarası veya plaka zaten mevcut!";
                            Label1.ForeColor = System.Drawing.Color.Red;
                            Label1.Visible = true;
                        }
                        else
                        {
                            // Araç ekleme işlemi
                            string insertQuery = "INSERT INTO araclar (tc, arac_ad, arac_marka, arac_seri, arac_model, arac_yil, arac_plaka) " +
                                                 "VALUES (@tc, @arac_ad, @arac_marka, @arac_seri, @arac_model, @arac_yil, @arac_plaka)";

                            SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                            insertCommand.Parameters.AddWithValue("@tc", tc);
                            insertCommand.Parameters.AddWithValue("@arac_ad", aracAd);
                            insertCommand.Parameters.AddWithValue("@arac_marka", aracMarka);
                            insertCommand.Parameters.AddWithValue("@arac_seri", aracSeri);
                            insertCommand.Parameters.AddWithValue("@arac_model", aracModel);
                            insertCommand.Parameters.AddWithValue("@arac_yil", aracYil);
                            insertCommand.Parameters.AddWithValue("@arac_plaka", aracPlaka);

                            int rowsAffected = insertCommand.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                // Başarıyla eklendiğinde yapılacak işlemler
                                Response.Write("<script>alert('Araç başarıyla eklendi.');</script>");
                                Response.Redirect("Profiles/Cars.aspx");
                            }
                            else
                            {
                                // Hata durumunda yapılacak işlemler
                                Response.Write("<script>alert('Bir hata oluştu.');</script>");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Hata mesajını gösterme
                        Response.Write("<script>alert('Hata: " + ex.Message + "');</script>");
                    }
                }
            }
            else
            {
                Label1.Text = "TC uyuşmadı!";
                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Visible = true;
            }
        }


    }
}
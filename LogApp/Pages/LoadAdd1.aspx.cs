    using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogApp.Pages
{
    public partial class LoadAdd1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Profil_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Profiles/Offers.aspx");
        }

        protected void AddYukButton_Click(object sender, EventArgs e)
        {
            string tc = tcTextBox.Text.Trim();
            string A_sehir = AlınacakSehirTextBox.Text.Trim();
            string T_sehir = TeslimEdilecekSehirTextBox.Text.Trim();
             //tarih = TarihTextBox.Text.Trim();
            string aractipi = AracTipiTextBox.Text.Trim();
            string YukAdi = YukAdiTextBox.Text.Trim();
            string fiyat = FiyatTextBox.Text.Trim();

            if (Session["user"] != null && Session["user"].ToString() == tc)
            {

                string connectionString = "Data Source=.;Initial Catalog=LogApp;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {

                    //string checkQuery = "SELECT COUNT(*) FROM araclar WHERE arac_seri = @arac_seri AND arac_plaka = @arac_plaka";
                    //SqlCommand checkCommand = new SqlCommand(checkQuery, connection);
                    //checkCommand.Parameters.AddWithValue("@arac_seri", aracSeri);
                    //checkCommand.Parameters.AddWithValue("@arac_plaka", aracPlaka);

                    try
                    {
                        connection.Open();
                        //int count = (int)checkCommand.ExecuteScalar();
                        int count = 0;
                        if (count > 0)
                        {

                            Label1.Text = "Bu seri numarası veya plaka zaten mevcut!";
                            Label1.ForeColor = System.Drawing.Color.Red;
                            Label1.Visible = true;
                        }
                        else
                        {

                            string insertQuery = "INSERT INTO Yuklar (tc, AlinacakSehir, TeslimEdilecekSehir, Tarih, AracTipi, YukAdi, Ucret) " +
                                                 "VALUES (@tc, @AlinacakSehir, @TeslimEdilecekSehir, @Tarih, @AracTipi, @YukAdi, @Ucret)";

                            SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                            insertCommand.Parameters.AddWithValue("@tc", tc);
                            insertCommand.Parameters.AddWithValue("@AlinacakSehir", A_sehir);
                            insertCommand.Parameters.AddWithValue("@TeslimEdilecekSehir", T_sehir);
                            insertCommand.Parameters.AddWithValue("@Tarih", TarihTextBox.Text);
                            insertCommand.Parameters.AddWithValue("@AracTipi", aractipi);
                            insertCommand.Parameters.AddWithValue("@YukAdi", YukAdi);
                            insertCommand.Parameters.AddWithValue("@Ucret", fiyat);

                            int rowsAffected = insertCommand.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {

                                Response.Write("<script>alert('Yük başarıyla eklendi.');</script>");
                                Response.Redirect("Profiles/Offers.aspx");
                            }
                            else
                            {

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
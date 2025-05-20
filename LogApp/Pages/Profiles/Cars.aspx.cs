using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogApp.Pages.Profiles
{
    public partial class Cars : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["LogAppDb"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("~/Pages/Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                KullaniciBilgileriniYukle();
                Listele();
            }
        }

        private void KullaniciBilgileriniYukle()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT ad, soyad, tc FROM uyeler WHERE tc=@tc";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@tc", Session["User"].ToString());

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string ad = reader["ad"].ToString();
                        string soyad = reader["soyad"].ToString();

                        kullaniciad.Text = $"{ad} {soyad}";
                        Session["tc"] = reader["tc"].ToString();

                        // Baş harfleri al ve avatar'a yaz
                        string basHarf = $"{ad[0]}{soyad[0]}".ToUpper();
                        avatar.InnerText = basHarf;
                    }
                }
            }
        }


        private void Listele()
        {
            string kullaniciTC = Session["tc"]?.ToString();

            if (string.IsNullOrEmpty(kullaniciTC))
            {
                lblMesaj.Text = "Kullanıcı bilgisi bulunamadı.";
                lblMesaj.Visible = true;
                return;
            }

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                string query = "SELECT arac_ad, arac_marka, arac_seri, arac_plaka FROM araclar WHERE tc=@tc";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@tc", kullaniciTC);

                try
                {
                    connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            CarRepeater.DataSource = reader;
                            CarRepeater.DataBind();
                            lblMesaj.Visible = false;
                        }
                        else
                        {
                            lblMesaj.Text = "Kayıtlı aracınız bulunamadı.";
                            lblMesaj.Visible = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblMesaj.Text = $"Hata oluştu: {ex.Message}";
                    lblMesaj.Visible = true;
                }
            }
        }

        protected void rptAraclar_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.ToLower() == "sil")
            {
                string plaka = e.CommandArgument.ToString();

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string query = "DELETE FROM araclar WHERE arac_plaka = @plaka AND tc = @tc";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@plaka", plaka);
                    cmd.Parameters.AddWithValue("@tc", Session["tc"].ToString());

                    conn.Open();
                    int affectedRows = cmd.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        lblMesaj.Text = "Araç başarıyla silindi.";
                        lblMesaj.CssClass = "text-success";
                    }
                    else
                    {
                        lblMesaj.Text = "Araç silinemedi veya bulunamadı.";
                        lblMesaj.CssClass = "text-danger";
                    }
                    lblMesaj.Visible = true;
                }

                Listele(); // Listeyi yenile
            }
        }

        protected void btncar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../CarAdd.aspx");
        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profil.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Pages/Login.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }
    }
}
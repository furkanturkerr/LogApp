using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogApp.Pages.Profiles
{
    public partial class account : System.Web.UI.Page
    {
        private DatabaseHelper dbHelper = new DatabaseHelper();

        string connStr = ConfigurationManager.ConnectionStrings["LogAppDb"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Sayfa ilk kez yükleniyorsa çalıştır
            {
                string tc = Session["User"] as string; // Oturumdan TC al

                if (!string.IsNullOrEmpty(tc))
                {
                    KullaniciBilgileriniDoldur(tc); // Kullanıcı bilgilerini çek
                    KullaniciBilgileriniYukle();
                }
                else
                {
                    Response.Redirect("../Login.aspx"); // Oturum yoksa giriş sayfasına yönlendir
                }
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

        private void KullaniciBilgileriniDoldur(string tc)
        {
            SqlDataReader reader = dbHelper.KullaniciBilgileriniGetir(tc); // DatabaseHelper kullanarak verileri al

            if (reader.HasRows)
            {
                reader.Read();
                txtAd.Text = reader["Ad"].ToString();
                txtSoyad.Text = reader["Soyad"].ToString();
                //txtPlaka.Text = reader["Plaka"].ToString();
                txtAdres.Text = reader["Adres"].ToString();
            }

            reader.Close();
        }


        protected void btnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Profiles/Profil.aspx");
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon(); // Oturumu sonlandır
            Response.Redirect("../Login.aspx"); // Giriş sayfasına yönlendir
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string tc = Session["User"] as string;

            if (!string.IsNullOrEmpty(tc))
            {
                bool isUpdated = dbHelper.KullaniciBilgileriniGuncelle(tc, txtAd.Text, txtSoyad.Text, txttel.Text, txtmail.Text, txtAdres.Text);

                if (isUpdated)
                {
                    lblMessage.Text = "Bilgiler başarıyla güncellendi!";
                    lblMessage.CssClass = "success";
                }
                else
                {
                    lblMessage.Text = "Güncelleme başarısız!";
                    lblMessage.CssClass = "error";
                }
            }
            else
            {
                Response.Redirect("../login.aspx");
            }
        }
    }
}

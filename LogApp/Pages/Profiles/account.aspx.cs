using System;
using System.Collections.Generic;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) // Sayfa ilk kez yükleniyorsa çalıştır
            {
                string tc = Session["UserTC"] as string; // Oturumdan TC al

                if (!string.IsNullOrEmpty(tc))
                {
                    KullaniciBilgileriniDoldur(tc); // Kullanıcı bilgilerini çek
                }
                else
                {
                    Response.Redirect("Login.aspx"); // Oturum yoksa giriş sayfasına yönlendir
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
                txtTc.Text = reader["Tc"].ToString();
                txtPlaka.Text = reader["Plaka"].ToString();
                txtAdres.Text = reader["Adres"].ToString();
            }

            reader.Close();
        }


        protected void btnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profiles/Profil.aspx");
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

        }
    }
}
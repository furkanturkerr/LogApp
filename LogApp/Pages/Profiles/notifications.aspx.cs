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
    public partial class notifications : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connStr = ConfigurationManager.ConnectionStrings["LogAppDb"].ConnectionString;

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
    }
}
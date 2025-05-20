using LogApp.Pages.Profiles;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogApp.Pages
{
    public partial class Profil : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["LogAppDb"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var data = new List<Slide>
                {
                    new Slide { ImageUrl = "~/Styles/Image/1.jpg" },
                    new Slide { ImageUrl = "~/Styles/Image/2.jpg" }
                };

                rptSlider.DataSource = data;
                rptSlider.DataBind();

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    string tc = (string)Session["User"];
                    SqlCommand cmd = new SqlCommand("SELECT ad, soyad FROM uyeler WHERE tc = @tc", conn);
                    cmd.Parameters.AddWithValue("@tc", tc);

                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            string ad = reader["ad"].ToString();
                            string soyad = reader["soyad"].ToString();

                            kullaniciad.Text = $"{ad} {soyad}";

                            // Avatar için baş harf
                            string basHarf = $"{ad[0]}{soyad[0]}".ToUpper();
                            avatar.InnerText = basHarf;
                        }
                    }

                    conn.Close();
                }
            }
        }

        public class Slide
        {
            public string ImageUrl { get; set; }
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
            Session.Abandon();
            Response.Redirect("../Login.aspx");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogApp.Pages.Profiles
{
    public partial class Offers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<NoktaCifti> noktaCiftleri = GetNoktaCiftleri();
                rptNoktalar.DataSource = noktaCiftleri;
                rptNoktalar.DataBind();
            }
        }

        public class Nokta
        {
            public string Tip { get; set; }
            public string Isim { get; set; }
            public string Telefon { get; set; }
            public string Sehir { get; set; }
            public string Mahalle { get; set; }
            public string Sokak { get; set; }
            public string Adres { get; set; }
        }

        public class NoktaCifti
        {
            public Nokta Yukleme { get; set; }
            public Nokta Teslimat { get; set; }
        }

        private List<Nokta> GetNoktalar()
        {
            var list = new List<Nokta>();
            string connectionString = "Data Source=.;Initial Catalog=LogApp;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Noktalar ORDER BY Id"; // sıralama önemli olabilir
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(new Nokta
                    {
                        Tip = reader["Tip"].ToString(),
                        Isim = reader["Isim"].ToString(),
                        Telefon = reader["Telefon"].ToString(),
                        Sehir = reader["Sehir"].ToString(),
                        Mahalle = reader["Mahalle"].ToString(),
                        Sokak = reader["Sokak"].ToString(),
                        Adres = reader["Adres"].ToString()
                    });
                }

                conn.Close();
            }

            return list;
        }

        private List<NoktaCifti> GetNoktaCiftleri()
        {
            List<Nokta> noktalar = GetNoktalar();
            List<NoktaCifti> ciftler = new List<NoktaCifti>();

            for (int i = 0; i < noktalar.Count; i += 2)
            {
                var yukleme = noktalar[i];
                var teslimat = (i + 1 < noktalar.Count) ? noktalar[i + 1] : null;

                ciftler.Add(new NoktaCifti
                {
                    Yukleme = yukleme,
                    Teslimat = teslimat
                });
            }

            return ciftler;
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
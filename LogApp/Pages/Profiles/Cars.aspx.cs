using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogApp.Pages.Profiles
{
    public partial class Cars : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Listele();
            }
        }

        private void Listele()
        {
            string connectionString = "Data Source=.;Initial Catalog=LogApp;Integrated Security=True";
            string query = "SELECT arac_ad, arac_marka, arac_seri, arac_plaka FROM araclar";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Repeater kontrolünü veri ile doldur
                    CarRepeater.DataSource = reader;
                    CarRepeater.DataBind();  // Verileri Repeater'a bağla
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('Hata: " + ex.Message + "');</script>");
                }
            }
        }

        protected void rptAraclar_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Sil")
            {
                string plaka = e.CommandArgument.ToString();

                string query = "DELETE FROM araclar WHERE arac_plaka = @plaka";
                using (SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=LogApp;Integrated Security=True"))
                {
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@plaka", plaka);
                    conn.Open();
                    cmd.ExecuteNonQuery();  // Silme işlemini gerçekleştir

                    // Silme işleminden sonra listeyi yeniden güncelle
                    Listele();
                }
            }
        }



        protected void btncar_Click(object sender, EventArgs e)
        {
            Response.Redirect("../CarAdd.aspx");
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
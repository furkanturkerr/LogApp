using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogApp.Pages.Profiles
{
    public partial class Offers : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["LogAppDb"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                YukleriGetir();
        }

        private void YukleriGetir()
        {
            string kullaniciTc = Session["User"]?.ToString();
            if (string.IsNullOrEmpty(kullaniciTc))
            {
                Response.Redirect("../Login.aspx");
                return;
            }

            // Bütün yükleri getiriyoruz, teklif verilmiş olup olmadığına bakacağız
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = @"
                    SELECT 
                        y.YukID, y.YukAdi, y.AlinacakSehir, y.TeslimEdilecekSehir, y.Tarih, y.AracTipi, y.Ucret,
                        t.TeklifID, t.TeklifTutari, t.TeklifTarihi,t.AracPlaka, t.Durum
                    FROM Yuklar y
                    LEFT JOIN Teklifler t ON y.YukID = t.YukID
                    WHERE y.tc = @tc";  // Bütün yükleri listeliyoruz

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@tc", kullaniciTc);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvTeklifler.DataSource = dt;
                gvTeklifler.DataBind();
            }
        }

        protected void gvTeklifler_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int teklifID = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "Onayla")
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Teklifler SET Durum = 'Onaylandi' WHERE TeklifID = @id", con);
                    cmd.Parameters.AddWithValue("@id", teklifID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            else if (e.CommandName == "Reddet")
            {
                using (SqlConnection con = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Teklifler SET Durum = 'Reddedildi' WHERE TeklifID = @id", con);
                    cmd.Parameters.AddWithValue("@id", teklifID);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            YukleriGetir(); // Sayfayı yenile
        }

        protected void gvTeklifler_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string teklifID = DataBinder.Eval(e.Row.DataItem, "TeklifID")?.ToString();
                Button btnOnayla = (Button)e.Row.FindControl("btnOnayla");
                Button btnReddet = (Button)e.Row.FindControl("btnReddet");

                // Eğer teklif verilmişse butonları göster
                if (!string.IsNullOrEmpty(teklifID))
                {
                    btnOnayla.Visible = true;
                    btnReddet.Visible = true;
                }
                else
                {
                    btnOnayla.Visible = false;
                    btnReddet.Visible = false;
                }
            }
        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Profiles/Profil.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Login.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("../Register.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("../Login.aspx");
        }

        protected void btnyuk_Click(object sender, EventArgs e)
        {
            Response.Redirect("../LoadAdd1.aspx");
        }
    }
}

using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogApp.Pages.Profiles
{
    public partial class Transport : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["LogAppDb"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User"] != null)
                {
                    // Session'dan kullanıcı bilgilerini al
                    int kullaniciID = Convert.ToInt16(Session["tc"]);
                    string tc = Session["User"].ToString();

                    // Kullanıcının tekliflerini getir
                    TeklifleriGetir(kullaniciID, tc);
                }
                else
                {
                    Response.Redirect("~/Pages/Login.aspx");
                }
            }
        }

        private void TeklifleriGetir(int kullaniciID, string tc)
        {
            string query = @"
                SELECT 
                    Y.YukID,
                    Y.YukAdi, 
                    Y.AlinacakSehir, 
                    Y.TeslimEdilecekSehir, 
                    CONVERT(varchar, Y.Tarih, 104) AS Tarih,
                    T.TeklifTutari,
                    CONVERT(varchar, T.TeklifTarihi, 104) AS TeklifTarihi,
                    T.Durum,
                    A.arac_plaka,
                    A.arac_marka + ' ' + A.arac_model AS AracBilgisi
                FROM Teklifler T
                INNER JOIN Yuklar Y ON T.YukID = Y.YukID
                LEFT JOIN araclar A ON T.AracPlaka = A.arac_plaka
                WHERE A.tc = @tc";

            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@tc", tc);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    // GridView'i bağla
                    gvTekliflerim.DataSource = dt;
                    gvTekliflerim.DataBind();

                    // Eğer kayıt yoksa bilgi mesajı göster
                    if (dt.Rows.Count == 0)
                    {
                        lblMesaj.Text = "Henüz hiç teklif yapmamışsınız.";
                        lblMesaj.Visible = true;
                    }
                    else
                    {
                        lblMesaj.Visible = false;
                    }
                }
            }
        }

        protected void gvTekliflerim_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // GridView satırlarını özelleştirme
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Duruma göre renklendirme
                string durum = DataBinder.Eval(e.Row.DataItem, "Durum").ToString();
                switch (durum)
                {
                    case "Kabul Edildi":
                        e.Row.CssClass = "success-row";
                        break;
                    case "Reddedildi":
                        e.Row.CssClass = "danger-row";
                        break;
                    case "Beklemede":
                        e.Row.CssClass = "warning-row";
                        break;
                }
            }
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
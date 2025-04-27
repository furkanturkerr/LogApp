using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogApp.Pages
{
    public partial class CargoMain : System.Web.UI.Page
    {

        string connStr = ConfigurationManager.ConnectionStrings["LogAppDb"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SehirleriDoldur();
                YukleriGetir();
            }

            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    // Kullanıcı giriş yapmışsa
                    btnLogin.Visible = false;
                    btnRegister.Visible = false;
                    btnProfile.Visible = true;
                }
                else
                {
                    // Kullanıcı giriş yapmamışsa
                    btnLogin.Visible = true;
                    btnRegister.Visible = true;
                    btnProfile.Visible = false;
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register.aspx");
        }

        protected void btnProfile_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/Profiles/Profil.aspx");
        }

        private void SehirleriDoldur()
        {
            // Şehir listesi doldur
            ddlAlinacakSehir.Items.Add("İstanbul");
            ddlAlinacakSehir.Items.Add("Ankara");
            ddlAlinacakSehir.Items.Add("İzmir");

            ddlTeslimSehir.Items.Add("İstanbul");
            ddlTeslimSehir.Items.Add("Ankara");
            ddlTeslimSehir.Items.Add("İzmir");

            ddlAracTipi.Items.Add("Tır");
            ddlAracTipi.Items.Add("Kamyon");
        }

        private void YukleriGetir()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Yuklar", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvYukler.DataSource = dt;
                gvYukler.DataBind();
            }
        }

        protected void btnAra_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM Yuklar WHERE 1=1";
                if (!string.IsNullOrEmpty(ddlAlinacakSehir.SelectedValue))
                    query += " AND AlinacakSehir = @AlinacakSehir";
                if (!string.IsNullOrEmpty(ddlTeslimSehir.SelectedValue))
                    query += " AND TeslimEdilecekSehir = @TeslimEdilecekSehir";
                if (!string.IsNullOrEmpty(txtTarih.Text))
                    query += " AND Tarih = @Tarih";
                if (!string.IsNullOrEmpty(ddlAracTipi.SelectedValue))
                    query += " AND AracTipi = @AracTipi";
                if (!string.IsNullOrEmpty(txtIlanAra.Text))
                    query += " AND YukAdi LIKE @YukAdi";

                SqlCommand cmd = new SqlCommand(query, con);

                if (!string.IsNullOrEmpty(ddlAlinacakSehir.SelectedValue))
                    cmd.Parameters.AddWithValue("@AlinacakSehir", ddlAlinacakSehir.SelectedValue);
                if (!string.IsNullOrEmpty(ddlTeslimSehir.SelectedValue))
                    cmd.Parameters.AddWithValue("@TeslimEdilecekSehir", ddlTeslimSehir.SelectedValue);
                if (!string.IsNullOrEmpty(txtTarih.Text))
                    cmd.Parameters.AddWithValue("@Tarih", txtTarih.Text);
                if (!string.IsNullOrEmpty(ddlAracTipi.SelectedValue))
                    cmd.Parameters.AddWithValue("@AracTipi", ddlAracTipi.SelectedValue);
                if (!string.IsNullOrEmpty(txtIlanAra.Text))
                    cmd.Parameters.AddWithValue("@YukAdi", "%" + txtIlanAra.Text + "%");

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvYukler.DataSource = dt;
                gvYukler.DataBind();
            }
        }

        protected void btnTemizle_Click(object sender, EventArgs e)
        {
            ddlAlinacakSehir.ClearSelection();
            ddlTeslimSehir.ClearSelection();
            ddlAracTipi.ClearSelection();
            txtTarih.Text = "";
            txtIlanAra.Text = "";
            YukleriGetir();
        }

        protected void gvYukler_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "TeklifVer")
            {
                string yukID = e.CommandArgument.ToString();
                hfYukID.Value = yukID;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "teklifModal", "$('#teklifModal').modal('show');", true);
            }
        }

        protected void btnTeklifGonder_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO Teklifler (YukID, KullaniciID, TeklifTutar) VALUES (@YukID, @KullaniciID, @TeklifTutar)", con);
                cmd.Parameters.AddWithValue("@YukID", hfYukID.Value);
                cmd.Parameters.AddWithValue("@KullaniciID", 1); // örnek kullanıcı ID, gerçek sistemde login olan kullanıcının ID'si alınır
                cmd.Parameters.AddWithValue("@TeklifTutar", txtTeklifTutar.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }

            YukleriGetir();
        }
    }
}
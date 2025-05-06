using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net.NetworkInformation;
using MongoDB.Driver.Core.Configuration;

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

            // Kullanıcı durumunu kontrol et (IsPostBack dışında da çalışsın)
            if (Session["User"] != null)
            {
                btnLogin.Visible = false;
                btnRegister.Visible = false;
                btnProfile.Visible = true;
            }
            else
            {
                btnLogin.Visible = true;
                btnRegister.Visible = true;
                btnProfile.Visible = false;
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
            string query = "SELECT İL FROM sehirler";

            using (SqlConnection connection = new SqlConnection(connStr))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connStr))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    ddlAlinacakSehir.DataSource = dt;
                    ddlAlinacakSehir.DataTextField = "İL";
                    ddlAlinacakSehir.DataValueField = "İL";
                    ddlAlinacakSehir.DataBind();

                    ddlTeslimSehir.DataSource = dt;
                    ddlTeslimSehir.DataTextField = "İL";
                    ddlTeslimSehir.DataValueField = "İL";
                    ddlTeslimSehir.DataBind();
                }
            }

            ddlAracTipi.Items.Add("Tır");
            ddlAracTipi.Items.Add("KırkAyak");
            ddlAracTipi.Items.Add("OnTeker");
            ddlAracTipi.Items.Add("HafifTicari");
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

        private void KullaniciAraclariniGetir()
        {
            if (Session["User"] == null)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Uyari", "alert('Önce giriş yapmalısınız.');", true);
                return;
            }

            string tc = Session["User"].ToString();
            string connStr = ConfigurationManager.ConnectionStrings["LogAppDb"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connStr))
            {
                string query = "SELECT arac_plaka, arac_marka, arac_model FROM araclar WHERE tc=@tc";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@tc", tc);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                ddlKullaniciAraclari.Items.Clear();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string plaka = reader["arac_plaka"].ToString();
                        string marka = reader["arac_marka"].ToString();
                        string model = reader["arac_model"].ToString();

                        ddlKullaniciAraclari.Items.Add(new ListItem($"{marka} {model} ({plaka})", plaka));
                    }
                    ddlKullaniciAraclari.Items.Insert(0, new ListItem("Aracınızı Seçiniz", ""));
                }
                else
                {
                    ddlKullaniciAraclari.Items.Add(new ListItem("Kayıtlı Aracınız Yok", ""));
                }
            }
        }


        protected void gvYukler_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "TeklifVer")
            {
                if (Session["User"] == null)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Uyari",
                        "alert('Teklif verebilmek için giriş yapmalısınız.');", true);
                    Response.Redirect("Login.aspx?ReturnUrl=" + Server.UrlEncode(Request.Url.PathAndQuery));
                    return;
                }

                int yukID = Convert.ToInt32(e.CommandArgument);
                ViewState["YukID"] = yukID;

                KullaniciAraclariniGetir();

                using (SqlConnection con = new SqlConnection(connStr))
                {
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Yuklar WHERE YukID=@YukID", con);
                    cmd.Parameters.AddWithValue("@YukID", yukID);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        lblYukAdi.Text = dr["YukAdi"].ToString();
                        lblYukDetay.Text = $"{dr["AlinacakSehir"]} > {dr["TeslimEdilecekSehir"]} | {Convert.ToDateTime(dr["Tarih"]).ToString("dd.MM.yyyy")} | {dr["AracTipi"]} | {Convert.ToDecimal(dr["Ucret"]).ToString("N2")} ₺";
                    }
                    con.Close();
                }

                pnlTeklif.Visible = true;
                txtTeklifTutar.Text = "";
                txtTeklifTutar.Focus();
            }
        }

        protected void btnTeklifGonder_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                try
                {
                    // Araç seçilip seçilmediğini kontrol et
                    if (ddlKullaniciAraclari.SelectedIndex <= 0)
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "Uyari",
                            "alert('Teklif verebilmek için bir araç seçmelisiniz.');", true);
                        return;
                    }

                    int yukID = Convert.ToInt32(ViewState["YukID"]);
                    int kullaniciID = Convert.ToInt32(Session["KullaniciID"]);
                    decimal teklifTutari = Convert.ToDecimal(txtTeklifTutar.Text);
                    string aracPlaka = ddlKullaniciAraclari.SelectedValue;

                    using (SqlConnection con = new SqlConnection(connStr))
                    {
                        SqlCommand cmd = new SqlCommand(
                            "INSERT INTO Teklifler (YukID, KullaniciID, TeklifTutari, TeklifTarihi, Durum, AracPlaka) " +
                            "VALUES (@YukID, @KullaniciID, @TeklifTutari, @TeklifTarihi, 'Beklemede', @AracPlaka)", con);

                        cmd.Parameters.AddWithValue("@YukID", yukID);
                        cmd.Parameters.AddWithValue("@KullaniciID", kullaniciID);
                        cmd.Parameters.AddWithValue("@TeklifTutari", teklifTutari);
                        cmd.Parameters.AddWithValue("@TeklifTarihi", DateTime.Now);
                        cmd.Parameters.AddWithValue("@AracPlaka", aracPlaka);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        pnlTeklif.Visible = false;
                        ClientScript.RegisterStartupScript(this.GetType(), "Bilgi",
                            "alert('Teklifiniz başarıyla gönderildi.');", true);
                    }
                }
                catch (Exception ex)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "Hata",
                        $"alert('Hata oluştu: {ex.Message}');", true);
                }
            }
        }

        protected void btnVazgec_Click(object sender, EventArgs e)
        {
            pnlTeklif.Visible = false;
        }

    }
}

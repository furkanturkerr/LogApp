using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace LogApp.Pages
{
    public partial class LoadAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ViewState["YuklemeSayisi"] = 0;
                ViewState["TeslimatSayisi"] = 0;
            }

            CreateYuklemePanels();
            CreateTeslimatPanels();
        }

        protected void btnYuklemeEkle_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(ViewState["YuklemeSayisi"]);
            ViewState["YuklemeSayisi"] = count + 1;
            CreateYuklemePanels();
        }

        protected void btnTeslimatEkle_Click(object sender, EventArgs e)
        {
            int count = Convert.ToInt32(ViewState["TeslimatSayisi"]);
            ViewState["TeslimatSayisi"] = count + 1;
            CreateTeslimatPanels();
        }

        private DropDownList CreateSehirDropdown(string id)
        {
            var ddl = new DropDownList
            {
                ID = id,
                CssClass = "form-control mb-2"
            };
            ddl.Items.Add(new ListItem("Şehir Seçiniz", "1"));
            ddl.Items.Add(new ListItem("İstanbul", "istanbul"));
            ddl.Items.Add(new ListItem("Ankara", "ankara"));
            ddl.Items.Add(new ListItem("İzmir", "izmir")); 

            return ddl;
        }

        private void CreateYuklemePanels()
        {
            phYuklemeNoktalari.Controls.Clear();
            int count = Convert.ToInt32(ViewState["YuklemeSayisi"]);

            for (int i = 0; i < count; i++)
            {
                Panel panel = new Panel { CssClass = "card-custom" };

                panel.Controls.Add(new Literal { Text = $"<h5>Yükleme Noktası #{i + 1}</h5>" });
                panel.Controls.Add(CreateTextbox($"txtYuklemeIsim_{i}", "İsim"));
                panel.Controls.Add(CreateTextbox($"txtYuklemeTelefon_{i}", "Telefon"));
                panel.Controls.Add(CreateSehirDropdown($"ddlYuklemeSehir_{i}"));
                panel.Controls.Add(CreateTextbox($"txtYuklemeMahalle_{i}", "Mahalle"));
                panel.Controls.Add(CreateTextbox($"txtYuklemeSokak_{i}", "Sokak"));
                panel.Controls.Add(CreateTextbox($"txtYuklemeAdres_{i}", "Açık Adres"));

                phYuklemeNoktalari.Controls.Add(panel);
            }
        }

        private void CreateTeslimatPanels()
        {
            phTeslimatNoktalari.Controls.Clear();
            int count = Convert.ToInt32(ViewState["TeslimatSayisi"]);

            for (int i = 0; i < count; i++)
            {
                Panel panel = new Panel { CssClass = "card-custom" };

                panel.Controls.Add(new Literal { Text = $"<h5>Teslimat Noktası #{i + 1}</h5>" });

                panel.Controls.Add(CreateTextbox($"txtTeslimIsim_{i}", "İsim"));
                panel.Controls.Add(CreateTextbox($"txtTeslimTelefon_{i}", "Telefon"));
                panel.Controls.Add(CreateSehirDropdown($"ddlTeslimatSehir_{i}"));
                panel.Controls.Add(CreateTextbox($"txtTeslimMahalle_{i}", "Mahalle"));
                panel.Controls.Add(CreateTextbox($"txtTeslimSokak_{i}", "Sokak"));
                panel.Controls.Add(CreateTextbox($"txtTeslimAdres_{i}", "Açık Adres"));

                phTeslimatNoktalari.Controls.Add(panel);
            }
        }

        private TextBox CreateTextbox(string id, string placeholder)
        {
            var txt = new TextBox
            {
                ID = id,
                CssClass = "form-control mb-2"
            };
            txt.Attributes["placeholder"] = placeholder;
            return txt;
        }

        protected void btnDevamEt_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=.;Initial Catalog=LogApp;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // YÜKLEME NOKTALARI
                int yuklemeSayisi = Convert.ToInt32(ViewState["YuklemeSayisi"]);
                for (int i = 0; i < yuklemeSayisi; i++)
                {
                    string isim = Request.Form[$"txtYuklemeIsim_{i}"];
                    string telefon = Request.Form[$"txtYuklemeTelefon_{i}"];
                    string sehirRaw = Request.Form[$"ddlYuklemeSehir_{i}"];
                    string mahalle = Request.Form[$"txtYuklemeMahalle_{i}"];
                    string sokak = Request.Form[$"txtYuklemeSokak_{i}"];
                    string adres = Request.Form[$"txtYuklemeAdres_{i}"];

                    KaydetNokta(conn, "Yukleme", isim, telefon, sehirRaw, mahalle, sokak, adres);
                }

                // TESLİMAT NOKTALARI
                int teslimatSayisi = Convert.ToInt32(ViewState["TeslimatSayisi"]);
                for (int i = 0; i < teslimatSayisi; i++)
                {
                    string isim = Request.Form[$"txtTeslimIsim_{i}"];
                    string telefon = Request.Form[$"txtTeslimTelefon_{i}"];
                    string sehirRaw = Request.Form[$"ddlTeslimatSehir_{i}"];
                    string mahalle = Request.Form[$"txtTeslimMahalle_{i}"];
                    string sokak = Request.Form[$"txtTeslimSokak_{i}"];
                    string adres = Request.Form[$"txtTeslimAdres_{i}"];

                    KaydetNokta(conn, "Teslimat", isim, telefon, sehirRaw, mahalle, sokak, adres);
                }

                conn.Close();
            }

            void KaydetNokta(SqlConnection conn, string tip, string isim, string telefon, string sehirRaw, string mahalle, string sokak, string adres)
            {
                string query = @"INSERT INTO Noktalar (Tip, Isim, Telefon, Sehir, Mahalle, Sokak, Adres) 
                         VALUES (@Tip, @Isim, @Telefon, @Sehir, @Mahalle, @Sokak, @Adres)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Tip", tip ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Isim", isim ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Telefon", telefon ?? (object)DBNull.Value);

                if (int.TryParse(sehirRaw, out int sehir))
                    cmd.Parameters.Add("@Sehir", System.Data.SqlDbType.Int).Value = sehir;
                else
                    cmd.Parameters.Add("@Sehir", System.Data.SqlDbType.Int).Value = DBNull.Value;

                cmd.Parameters.AddWithValue("@Mahalle", string.IsNullOrWhiteSpace(mahalle) ? (object)DBNull.Value : mahalle);
                cmd.Parameters.AddWithValue("@Sokak", string.IsNullOrWhiteSpace(sokak) ? (object)DBNull.Value : sokak);
                cmd.Parameters.AddWithValue("@Adres", string.IsNullOrWhiteSpace(adres) ? (object)DBNull.Value : adres);

                cmd.ExecuteNonQuery();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {

                    Response.Write("<script>alert('Araç başarıyla eklendi.');</script>");
                    Response.Redirect("Profiles/Cars.aspx");
                }
                else
                {

                    Response.Write("<script>alert('Bir hata oluştu.');</script>");
                }
            }
        }

    }
}

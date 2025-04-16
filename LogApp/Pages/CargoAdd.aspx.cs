using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogApp


{
    public partial class CargoAdd : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string tc = Session["tc"] as string;

            if (string.IsNullOrEmpty(tc))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('TC bilgisi eksik!');", true);
                return;
            }
        }

        protected void yuk_ekle_Click(object sender, EventArgs e)
        {
            string tc = Session["tc"] as string;
            string baslik = baslık_tb.Text;
            string fiyat = fiyat_tb.Text;
            string komisyon = komisyon_tb.Text;
            string yuklemeAdres = yukleme_adres_tb.Text;
            string bosaltmaAdres = bosaltma_adres_tb.Text;
            string tur = tur_list.SelectedValue;

            using (SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=LogApp;Integrated Security=True"))
            {
                baglanti.Open();
                string sql = "INSERT INTO araclar (tc, baslik, fiyat, komisyon, yukleme_adres, bosaltma_adres, tur) VALUES (@tc, @baslik, @fiyat, @komisyon, @yuklemeAdres, @bosaltmaAdres, @tur)";

                using (SqlCommand komut = new SqlCommand(sql, baglanti))
                {
                    komut.Parameters.AddWithValue("@tc", tc);
                    komut.Parameters.AddWithValue("@baslik", baslik);
                    komut.Parameters.AddWithValue("@fiyat", fiyat);
                    komut.Parameters.AddWithValue("@komisyon", komisyon);
                    komut.Parameters.AddWithValue("@yuklemeAdres", yuklemeAdres);
                    komut.Parameters.AddWithValue("@bosaltmaAdres", bosaltmaAdres);
                    komut.Parameters.AddWithValue("@tur", tur);

                    komut.ExecuteNonQuery();
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Yük kaydı tamamlandı');", true);
                }
            }
        }
    }
}

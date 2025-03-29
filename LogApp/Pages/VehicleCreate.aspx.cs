using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogApp
{
    public partial class VehicleCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadMarkalar();
            }

            string tc = Session["tc"] as string;
            if (string.IsNullOrEmpty(tc))
            {
                LabelMessage.Text = "TC bilgisi eksik!";
                LabelMessage.ForeColor = System.Drawing.Color.Red;
                return;
            }
        }

        private void LoadMarkalar()
        {
            string query = "SELECT marka FROM arac_katalog";
            string connectionString = "Data Source=.;Initial Catalog=log;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, connection))
                {
                    System.Data.DataTable dt = new System.Data.DataTable();
                    adapter.Fill(dt);

                    marka_list.DataSource = dt;
                    marka_list.DataTextField = "marka";
                    marka_list.DataValueField = "marka";
                    marka_list.DataBind();
                    marka_list.Items.Insert(0, new ListItem("Marka Seçiniz", ""));
                }
            }
        }

        protected void marka_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSeriler(marka_list.SelectedItem.Text);
        }

        private void LoadSeriler(string marka)
        {
            string query = "SELECT seri FROM arac_katalog WHERE marka = @marka";
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@marka", marka);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        System.Data.DataTable dt = new System.Data.DataTable();
                        adapter.Fill(dt);

                        seri_list.DataSource = dt;
                        seri_list.DataTextField = "seri";
                        seri_list.DataValueField = "seri";
                        seri_list.DataBind();
                        seri_list.Items.Insert(0, new ListItem("Seri Seçiniz", ""));
                    }
                }
            }
        }

        protected void seri_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadModel(seri_list.SelectedItem.Text);
        }

        private void LoadModel(string seri)
        {
            string query = "SELECT model FROM arac_katalog WHERE seri = @seri";
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@seri", seri);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        System.Data.DataTable dt = new System.Data.DataTable();
                        adapter.Fill(dt);

                        model_list.DataSource = dt;
                        model_list.DataTextField = "model";
                        model_list.DataValueField = "model";
                        model_list.DataBind();
                        model_list.Items.Insert(0, new ListItem("Model Seçiniz", ""));
                    }
                }
            }
        }

        protected void model_list_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadYears(model_list.SelectedItem.Text);
        }

        private void LoadYears(string model)
        {
            string query = "SELECT yıl FROM arac_katalog WHERE model = @model";
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@model", model);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        System.Data.DataTable dt = new System.Data.DataTable();
                        adapter.Fill(dt);

                        yıl_list.DataSource = dt;
                        yıl_list.DataTextField = "yıl";
                        yıl_list.DataValueField = "yıl";
                        yıl_list.DataBind();
                        yıl_list.Items.Insert(0, new ListItem("Model Yılı Seçiniz", ""));
                    }
                }
            }
        }

        protected void arac_kayıt_btn_Click(object sender, EventArgs e)
        {
            string ad = arac_ad_tb.Text;
            string marka = marka_list.SelectedItem.Text;
            string seri = seri_list.SelectedItem.Text;
            string model = model_list.SelectedItem.Text;
            string yıl = yıl_list.SelectedItem.Text;
            string plaka = arac_plaka_tb.Text;
            string tc = Session["tc"] as string;
            string connectionString = "Data Source=.;Initial Catalog=log;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string checkPlakaQuery = "SELECT * FROM araclar WHERE arac_plaka = @plaka";
                using (SqlCommand cmdCheck = new SqlCommand(checkPlakaQuery, connection))
                {
                    cmdCheck.Parameters.AddWithValue("@plaka", plaka);
                    using (SqlDataReader reader = cmdCheck.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            LabelMessage.Text = "Araç zaten kayıtlı!";
                            LabelMessage.ForeColor = System.Drawing.Color.Red;
                            return;
                        }
                    }
                }

                string insertQuery = "INSERT INTO araclar (tc, arac_ad, arac_marka, arac_seri, arac_model, arac_yıl, arac_plaka) " +
                                     "VALUES (@tc, @ad, @marka, @seri, @model, @yil, @plaka)";
                using (SqlCommand cmdInsert = new SqlCommand(insertQuery, connection))
                {
                    cmdInsert.Parameters.AddWithValue("@tc", tc);
                    cmdInsert.Parameters.AddWithValue("@ad", ad);
                    cmdInsert.Parameters.AddWithValue("@marka", marka);
                    cmdInsert.Parameters.AddWithValue("@seri", seri);
                    cmdInsert.Parameters.AddWithValue("@model", model);
                    cmdInsert.Parameters.AddWithValue("@yil", yıl);
                    cmdInsert.Parameters.AddWithValue("@plaka", plaka);

                    cmdInsert.ExecuteNonQuery();
                    LabelMessage.Text = "Kayıt tamamlandı!";
                    LabelMessage.ForeColor = System.Drawing.Color.Green;
                }
            }
        }
    }
}
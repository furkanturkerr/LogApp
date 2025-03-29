using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogApp
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private string ComputeMD5Hash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = md5.ComputeHash(bytes);

                StringBuilder builder = new StringBuilder();
                foreach (byte b in hash)
                {
                    builder.Append(b.ToString("x2").ToUpper());
                }

                return builder.ToString();
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string tc = tcInput.Text.Trim();
            string ad = firstNameInput.Text.Trim();
            string soyad = lastNameInput.Text.Trim();
            string adres = addressInput.Text.Trim();
            string sifre = passwordInput.Text.Trim();
            string plaka = plakaInput.Text.Trim();

            string durum = "";

            if (Radio1.Checked)  // Eğer Radio1 seçiliyse
            {
                durum = "yuk_veren";
            }
            else if (Radio2.Checked)  // Eğer Radio2 seçiliyse
            {
                durum = "yuk_arayan";
            }

            if (string.IsNullOrEmpty(tc) || string.IsNullOrEmpty(ad) || string.IsNullOrEmpty(soyad) ||
                string.IsNullOrEmpty(adres) || string.IsNullOrEmpty(sifre) || string.IsNullOrEmpty(durum))
            {
                lblError.Text = "Lütfen tüm alanları doldurun!";
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Visible = true;
                return; // **İşlem burada sonlanmalı**
            }

            DatabaseHelper dbHelper = new DatabaseHelper();

            if (dbHelper.KullaniciVarMi(tc))
            {
                lblError.Text = "Bu TC kimlik numarasıyla kayıtlı bir kullanıcı zaten var!";
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Visible = true;
                return; // **İşlem burada sonlanmalı**
            }


            bool kayitBasarili = dbHelper.KullaniciEkle(tc, durum, ad, soyad, plaka, adres, sifre);

            if (kayitBasarili)
            {
                lblError.Text = "Kayıt başarıyla tamamlandı!";
                lblError.ForeColor = System.Drawing.Color.Green;
                lblError.Visible = true;
                Response.Redirect("MainPage.aspx");
            }
            else
            {
                lblError.Text = "Kayıt sırasında bir hata oluştu!";
                lblError.ForeColor = System.Drawing.Color.Red;
                lblError.Visible = true;
            }   
        }
    }
}
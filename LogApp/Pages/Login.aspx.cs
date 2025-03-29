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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string tc = txtTC.Text;
            string sifre = txtPassword.Text;

            DatabaseHelper dbHelper = new DatabaseHelper();
            bool girisBasarili = dbHelper.KullaniciGirisYap(tc, sifre);

            if (girisBasarili)
            {
                Session["User"] = txtTC.Text;
                Response.Redirect("MainPage.aspx");
            }
            else
            {
                lblError.Text = "TC Kimlik Numarası veya Şifre hatalı!";
                lblError.Visible = true;
            }
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
    }
}
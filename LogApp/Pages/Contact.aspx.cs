using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogApp.Pages
{
    public partial class Contact : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
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

        protected void btnGonder_Click(object sender, EventArgs e)
        {
            try
            {
                MailMessage mesaj = new MailMessage();
                mesaj.From = new MailAddress("furkanturker.dev@gmail.com");
                mesaj.To.Add("destek@logapp.com");
                mesaj.Subject = "İletişim Formu: " + ddlKonu.SelectedValue;
                mesaj.Body =
                    "Ad Soyad: " + txtAdSoyad.Text + "<br/>" +
                    "E-posta: " + txtEmail.Text + "<br/>" +
                    "Telefon: " + txtTelefon.Text + "<br/>" +
                    "Konu: " + ddlKonu.SelectedItem.Text + "<br/><br/>" +
                    "Mesaj: <br/>" + txtMesaj.Text;
                mesaj.IsBodyHtml = true;

                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.mailserver.com";
                smtp.Port = 587;
                smtp.Credentials = new System.Net.NetworkCredential("furkanturker.dev@gmail.com", "sifre");
                smtp.EnableSsl = true;
                smtp.Send(mesaj);

                lblSonuc.Text = "Mesajınız başarıyla gönderildi! Teşekkür ederiz.";
                // Formu temizleyelim
                txtAdSoyad.Text = "";
                txtEmail.Text = "";
                txtTelefon.Text = "";
                txtMesaj.Text = "";
                ddlKonu.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                lblSonuc.Text = "Hata oluştu: " + ex.Message;
            }
        }
    }
}
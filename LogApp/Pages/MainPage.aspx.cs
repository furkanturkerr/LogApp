using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogApp.Pages
{
    public partial class MainPage : System.Web.UI.Page
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
    }
}
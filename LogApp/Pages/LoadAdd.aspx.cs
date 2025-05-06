using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace LogApp.Pages
{
    public partial class LoadAdd : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["LogAppDb"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                YukleriGetir();
            }
        }

        private void YukleriGetir()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Yuklar", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gvYukler.DataSource = dt;
                gvYukler.DataBind();
            }
        }

        protected void gvYukler_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            if (e.CommandName == "TeklifVer")
            {
                int yukId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect("TeklifVer.aspx?yukId=" + yukId);
            }
        }
    }
}

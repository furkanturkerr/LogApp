using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogApp
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMainPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("MainPage.aspx");
        }
        protected void btnVehicle_Click(object sender, EventArgs e)
        {
            Response.Redirect("Vehicle.aspx");
        }

        protected void btnCargo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Cargo.aspx");
        }
    }
}
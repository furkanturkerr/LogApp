﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LogApp
{
    public partial class Cargo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void yuk_ekle_btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("CargoAdd.aspx");
        }
    }
}
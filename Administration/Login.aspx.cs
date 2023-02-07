﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administration
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                PanelForma.Visible = true;
                PanelIspis.Visible = false;
            }

            if (Session["administrator"] != null)
            {
                Response.Redirect("Dashboard.aspx");
            }

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {

                var username = txtUsername.Text;
                var password = txtPassword.Text;

                if (username == "admin" && password == "admin")
                {
                    Session["administrator"] = "administrator";
                    Response.Redirect("Dashboard.aspx");
                }
                else if (username != "admin" && password != "admin")
                {
                    PanelIspis.Visible = true;
                    PanelForma.Visible = true;
                }


            }
        }
    }
}
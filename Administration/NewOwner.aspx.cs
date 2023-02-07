using DatabaseLib.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administration
{
    public partial class NewOwner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["administrator"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string name = apFirstName.Text + " " + apLastName.Text;

            ((IRepo)Application["database"]).CreateNewOwner(name);

            Response.Redirect("Dashboard.aspx");

        }
    }
}
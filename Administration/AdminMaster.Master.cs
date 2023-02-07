using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administration
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void Logout_click(object sender, EventArgs e)
        {

            Session.RemoveAll();
            Session.Abandon();
            Session.Remove("administrator");
            Response.Redirect("Login.aspx");

        }
    }
}
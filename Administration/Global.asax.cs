using DatabaseLib.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Administration
{
    public class Global : System.Web.HttpApplication
    {

        private readonly IRepo _repo;

        public Global()
        {
            _repo = RepoFactory.GetRepo();
        }


        protected void Application_Start(object sender, EventArgs e)
        {
            Application["database"] = _repo;

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}
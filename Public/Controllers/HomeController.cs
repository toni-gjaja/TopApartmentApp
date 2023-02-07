using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseLib.MODELS;
using DatabaseLib.DAL;
using Public.Models.VM;

namespace Public.Controllers
{
    public class HomeController : Controller
    {
        IRepo repo = RepoFactory.GetRepo();

        public ActionResult Index(ApartmentsVM model)
        {
            if(model.Apartments == null)
            {
                model.Apartments = repo.SelectApartments();
            }
            else if(model.Apartments != null)
            {
                model.Apartments.Clear();
            }

            return View(model);
        }


    }
}
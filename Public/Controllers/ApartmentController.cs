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
    public class ApartmentController : Controller
    {

        IRepo repo = RepoFactory.GetRepo();

        public ActionResult Index(object id)
        {
            int apId;
            if (!int.TryParse(id.ToString(), out _))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                apId = int.Parse(id.ToString());
            }
            Session["apId"] = apId;
            ApartmentVM model = new ApartmentVM
            {
                Apartment = repo.SelectApartment(apId),
                ApartmentReviews = repo.GetApartmentReviews(apId),
                AssignedTags = repo.GetTagsForApartment(apId),
                Rating = repo.GetApartmentStars(apId)
            };

            return View(model);
        }

        public ActionResult Review(ApartmentReview review)
        {

            //if(review.UserId == 0)
            //{
            //    //u else if treba provjeriti jesu li svi podaci unutra
            //    AppUser user = (AppUser)Session["user"];

            //    review.UserId = user.Id;

            //    repo.LeaveReview(review);

            //    return View(new ApartmentReview());
            //}
            return View(new ApartmentReview());




        }

        [HttpGet]
        public JsonResult GetApartmentsForAutoComplete(string name)
        {
            List<ApSearch> apSearches = repo.GetApartmentsForAutoComplete(name);

            return Json(apSearches, JsonRequestBehavior.AllowGet);


        }


    }
}
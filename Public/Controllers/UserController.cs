using DatabaseLib.MODELS;
using DatabaseLib.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Public.Models.VM;
using Recaptcha.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace Public.Controllers
{
    public class UserController : Controller
    {

        IRepo repo = RepoFactory.GetRepo();

        // GET: User
        public ActionResult Index(UserVM user)
        {
            AppUser appUser = (AppUser)Session["user"];

            UserVM model = new UserVM
            {
                 AppUser = appUser,
                 Reviews = repo.GetUserReviews(appUser.Id),
                 Reservations = repo.GetUserReservations(appUser.Id)
            };
            
            return View(model);
        }

        public ActionResult Login(AppUser user)
        {
            if (user.Email == null && user.PasswordHash == null)
            {
                user = new AppUser();
                Session["user"] = null;
                return View(new AppUser());
            }
            else
            {

                if (user.PasswordHash != null)
                {
                    user.PasswordHash = Cryptography.HashPassword(user.PasswordHash);
                    
                }

                if (IsAuthenticated(user))
                {
                    AppUser loginUser = repo.GetAppUsers().ToList().First(u => u.Email == user.Email);
                    Session["user"] = loginUser;
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    Session["user"] = null;
                    return View();
                }
            }
        }

        public bool IsAuthenticated(AppUser user)
        {
            return repo.GetAppUsers().Any(u => (u.Email == user.Email) && (u.PasswordHash == user.PasswordHash));
        }

        public ActionResult Logout()
        {
            Session["user"] = null;
            return RedirectToAction("Index", "Home");
        }


        public ActionResult Registration(AppUser user)
        {

            if (user == null)
            {
                return View(new AppUser());
            }
            else
            {
                if (repo.GetAppUsers().Any(u => (u.Email == user.Email)))
                {
                    return Content("<script language='javascript' type='text/javascript'>alert('Korisnik sa tim podacima već postoji!');</script>");
                    
                }
                else if (user.UserName != null && user.PasswordHash != null)
                {
                    user.PasswordHash = Cryptography.HashPassword(user.PasswordHash);
                    var recaptchaHelper = this.GetRecaptchaVerificationHelper();
                    if (String.IsNullOrEmpty(recaptchaHelper.Response))
                    {
                        ModelState.AddModelError(
                            "",
                            "Odgovor ne smije biti prazan."
                            );
                        return View(new AppUser());
                    }
                    var recaptchaResult = recaptchaHelper.VerifyRecaptchaResponse();
                    if (!recaptchaResult.Success)
                    {
                        ModelState.AddModelError(
                            "",
                            "Krivi odgovor."
                            );
                        return View(new AppUser());
                    }
                    int newUserId = repo.CreateAppUser(user);

                    if (ModelState.IsValid)
                    {
                        return RedirectToAction("RegisterInfo", "User");
                    }

                    return RedirectToAction("RegisterInfo", "User");
                }
                return View(new AppUser());
            }

        }

        public ActionResult RegisterInfo()
        {
            return View();
        }


    }
}
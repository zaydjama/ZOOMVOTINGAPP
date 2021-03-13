using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VouterApp.Models;

namespace VouterApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
          [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }



          [AllowAnonymous]
        public ActionResult Login()
        {
           
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserModel model)
        {
            using (MyDbContext context = new MyDbContext())
            {
                bool IsValidUser = context.tblUser.Any(user => user.UserName.ToLower() ==
                     model.UserName.ToLower() && user.Paswd == model.Paswd);
                if (IsValidUser)
                {
                    System.Web.Security.FormsAuthentication.SetAuthCookie(model.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "invalid Username or Password");
                return View();
            }
        }
      
     

    }
}
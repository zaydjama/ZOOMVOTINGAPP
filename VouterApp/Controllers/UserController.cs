using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VouterApp.Models;

namespace VouterApp.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            MyDbContext dc = new MyDbContext();
            var Cndidate = dc.tblUser.ToList();
            return View(Cndidate);
        }
        [HttpPost]
        public ActionResult Save(UserModel Users)
        {

            if (ModelState.IsValid)
            {
                using (MyDbContext dc = new MyDbContext())
                {
                    if (Users.ID > 0)
                    {
                        //Edit 
                        var v = dc.tblUser.Where(a => a.ID == Users.ID).FirstOrDefault();
                        if (v != null)
                        {
                            v.UserName = Users.UserName;
                            v.Paswd = Users.Paswd;
                            v.Roles = Users.Roles;
                            v.Candidate = Users.Candidate;
                           

                        }
                    }
                    else
                    {
                        //Save
                        dc.tblUser.Add(Users);
                    }
                    dc.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult Save(int id)
        {
            MyDbContext dbContext = new MyDbContext();

            IEnumerable<SelectListItem> Candidate = dbContext.tblCandidate.Select(c => new SelectListItem
            {

                Text = c.FirstName,
                Value = c.ID.ToString()
            });
            ViewBag.cndidate = Candidate;


            using (MyDbContext dc = new MyDbContext())
            {
                var v = dc.tblUser.Where(a => a.ID == id).FirstOrDefault();


                return View(v);
            }


        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (MyDbContext dc = new MyDbContext())
            {
                var v = dc.tblUser.Where(a => a.ID == id).FirstOrDefault();
                if (v != null)
                {
                    return View(v);
                }
                else
                {
                    return HttpNotFound();
                }
            }
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteRegion(int id)
        {
            bool status = false;
            using (MyDbContext dc = new MyDbContext())
            {
                var v = dc.tblUser.Where(a => a.ID == id).FirstOrDefault();
                if (v != null)
                {
                    dc.tblUser.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return RedirectToAction("Index");
        }

	}
}
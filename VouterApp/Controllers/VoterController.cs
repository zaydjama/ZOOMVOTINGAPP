using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VouterApp.Models;

namespace VouterApp.Controllers
{
    public class VoterController : Controller
    {
        //
        // GET: /Voter/
        public ActionResult Index()
        {
            MyDbContext dc = new MyDbContext();
            var Vouter = dc.tblVouter.ToList();
            return View(Vouter);
        }
        [HttpPost]
        public ActionResult Save(VouterModel Vouter)
        {

            if (ModelState.IsValid)
            {
                using (MyDbContext dc = new MyDbContext())
                {
                    if (Vouter.ID > 0)
                    {
                        //Edit 
                        var v = dc.tblVouter.Where(a => a.ID == Vouter.ID).FirstOrDefault();
                        if (v != null)
                        {
                            v.FirstName = Vouter.FirstName;
                            v.SecondName = Vouter.SecondName;
                            v.LastName = Vouter.LastName;
                            v.Region = Vouter.Region;
                            v.District = Vouter.District;
                            v.DontatingFamily = Vouter.DontatingFamily;
                            v.userid = Vouter.userid;
                            v.NationalID = Vouter.NationalID;
                            v.VoutingCardNo = Vouter.VoutingCardNo;

                        }
                    }
                    else
                    {
                        //Save
                        dc.tblVouter.Add(Vouter);
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


            IEnumerable<SelectListItem> Regon = dbContext.tblRegion.Select(c => new SelectListItem
            {

                Text = c.RegionName,
                Value = c.RegionName.ToString()
            });
            ViewBag.rg = Regon;

            IEnumerable<SelectListItem> dstr = dbContext.tblDistrict.Select(c => new SelectListItem
            {

                Text = c.DistricName,
                Value = c.DistricName.ToString()
            });
            ViewBag.dt = dstr;

            IEnumerable<SelectListItem> usrlis = dbContext.tblUser.Select(c => new SelectListItem
            {

                Text = c.UserName,
                Value = c.ID.ToString()
            });
            ViewBag.UserList = dstr;
            using (MyDbContext dc = new MyDbContext())
            {
                var v = dc.tblVouter.Where(a => a.ID == id).FirstOrDefault();


                return View(v);
            }


        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (MyDbContext dc = new MyDbContext())
            {
                var v = dc.tblVouter.Where(a => a.ID == id).FirstOrDefault();
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
                var v = dc.tblVouter.Where(a => a.ID == id).FirstOrDefault();
                if (v != null)
                {
                    dc.tblVouter.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return RedirectToAction("Index");
        }
	}
}
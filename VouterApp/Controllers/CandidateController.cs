using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VouterApp.Models;

namespace VouterApp.Controllers
{
    [Authorize]
    public class CandidateController : Controller
    {
        //
        // GET: /Candidate/
        public ActionResult Index()
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
            return View();
        }
        public ActionResult GetData()
        {
            using (MyDbContext db = new MyDbContext())
            {
                List<CandidateModel> Candidate = db.tblCandidate.ToList<CandidateModel>();
                return Json(new { data = Candidate }, JsonRequestBehavior.AllowGet);
            }


        }
        [HttpPost]
        public ActionResult Save(CandidateModel Candidate)
        {

            if (ModelState.IsValid)
            {
                using (MyDbContext dc = new MyDbContext())
                {
                    if (Candidate.ID > 0)
                    {
                        //Edit 
                        var v = dc.tblCandidate.Where(a => a.ID == Candidate.ID).FirstOrDefault();
                        if (v != null)
                        {
                            v.FirstName = Candidate.FirstName;
                            v.SecondName = Candidate.SecondName;
                            v.LastName = Candidate.LastName;
                            v.Region = Candidate.Region;
                            v.District = Candidate.District;
                            v.Party = Candidate.Party;
                            v.Election = Candidate.Election;

                        }
                    }
                    else
                    {
                        //Save
                        dc.tblCandidate.Add(Candidate);
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


            using (MyDbContext dc = new MyDbContext())
            {
                var v = dc.tblCandidate.Where(a => a.ID == id).FirstOrDefault();


                return View(v);
            }


        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (MyDbContext dc = new MyDbContext())
            {
                var v = dc.tblCandidate.Where(a => a.ID == id).FirstOrDefault();
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
                var v = dc.tblCandidate.Where(a => a.ID == id).FirstOrDefault();
                if (v != null)
                {
                    dc.tblCandidate.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return RedirectToAction("Index");
        }

	}
}
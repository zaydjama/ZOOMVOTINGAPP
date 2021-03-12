using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VouterApp.Models;

namespace VouterApp.Controllers
{
    public class DistrictController : Controller
    {
        //
        // GET: /District/
        public ActionResult Index()
        {
            MyDbContext dc = new MyDbContext();
            var Region = dc.tblDistrict.ToList();
            return View(Region);
        }

        MyDbContext db;

        public DistrictController()
        {
            db = new MyDbContext();

        }

        public ActionResult GetData()
        {
            using (db = new MyDbContext())
            {

                List<DistrictModel> emp = db.tblDistrict.ToList<DistrictModel>();
                return Json(new { data = emp }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Save(DistrictModel District)
        {

            if (ModelState.IsValid)
            {
                using (MyDbContext dc = new MyDbContext())
                {
                    if (District.Id > 0)
                    {
                        //Edit 
                        var v = dc.tblDistrict.Where(a => a.Id == District.Id).FirstOrDefault();
                        if (v != null)
                        {
                            v.DistricName = District.DistricName;
                            v.RegionId = District.RegionId;

                        }
                    }
                    else
                    {
                        //Save
                        dc.tblDistrict.Add(District);
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
            MyDbContext dbContext = new MyDbContext(); IEnumerable<SelectListItem> items = dbContext.tblRegion.Select(c => new SelectListItem
            {

                Text = c.RegionName,
                Value = c.Id.ToString()
            });
            ViewBag.Region = items;
            using (MyDbContext dc = new MyDbContext())
            {
                var v = dc.tblDistrict.Where(a => a.Id == id).FirstOrDefault();


                return View(v);
            }



        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            using (MyDbContext dc = new MyDbContext())
            {
                var v = dc.tblDistrict.Where(a => a.Id == id).FirstOrDefault();
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
                var v = dc.tblDistrict.Where(a => a.Id == id).FirstOrDefault();
                if (v != null)
                {
                    dc.tblDistrict.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return RedirectToAction("Index");
        }
	
	}
}
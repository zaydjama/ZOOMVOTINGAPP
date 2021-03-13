using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VouterApp.Models;

namespace VouterApp.Controllers
{
    [Authorize]
    public class RegionController : Controller
    {
        //
        // GET: /Region/
        public ActionResult Index()

        {
           
            return View();
        }
        public ActionResult GetData()
        {
            using (MyDbContext db = new MyDbContext())
            {
                List<RegionModel> RegionList = db.tblRegion.ToList<RegionModel>();
                return Json(new { data = RegionList }, JsonRequestBehavior.AllowGet);
            }


        }
        public ActionResult Save(int id)
        {
            try
            {
                using (MyDbContext dc = new MyDbContext())
                {
                    var v = dc.tblRegion.Where(a => a.Id == id).FirstOrDefault();
                    return View(v);
                }
            }
            catch
            {
                return RedirectToAction("Index");

            }
        }

     
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteRegion(int id)
        {
            bool status = false;
            using (MyDbContext dc = new MyDbContext())
            {
                var v = dc.tblRegion.Where(a => a.Id == id).FirstOrDefault();
                if (v != null)
                {
                    dc.tblRegion.Remove(v);
                    dc.SaveChanges();
                    status = true;
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Save(RegionModel Rgn)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (MyDbContext dc = new MyDbContext())
                    {
                        if (Rgn.Id > 0)
                        {
                            //Edit 
                            var v = dc.tblRegion.Where(a => a.Id == Rgn.Id).FirstOrDefault();
                            if (v != null)
                            {
                                v.RegionName = Rgn.RegionName;


                            }
                        }
                        else
                        {
                            //Save
                            dc.tblRegion.Add(Rgn);
                        }
                        dc.SaveChanges();
                        return View("Index");
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {

                return RedirectToAction("Index");
            }
        }
 
	}
}
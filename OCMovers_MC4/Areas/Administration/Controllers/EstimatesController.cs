using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OCMovers_MC4.DAL;
using OCMovers_MC4.Models;
using PagedList;
using PagedList.Mvc;

namespace OCMovers_MVC4.Areas.Administration.Controllers
{ 
    public class EstimatesController : Controller
    {
        private readonly OCMovers_MVC4Context db = new OCMovers_MVC4Context();

        //
        // GET: /Administration/Estimates/s

        public ViewResult Index(int? page)
        {
			var estimateList = db.EstimateForm.OrderByDescending(x => x.EstimateFormID).ToList();

			var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
			var estPages = estimateList.ToPagedList(pageNumber, 35); // will only contain 25 products max because of the pageSize

			ViewBag.OnePageOfProducts = estPages;

			return View(estimateList);
        }

        //
        // GET: /Administration/Estimates/Details/5
		[HttpGet]
        public ViewResult Details(int id)
        {
            EstimateForm estimateform = db.EstimateForm.Find(id);
            return View(estimateform);
        }

        //
        // GET: /Administration/Estimates/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Administration/Estimates/Create

        [HttpPost]
        public ActionResult Create(EstimateForm estimateform)
        {
            if (ModelState.IsValid)
            {
                db.EstimateForm.Add(estimateform);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(estimateform);
        }
        
        //
        // GET: /Administration/Estimates/Edit/5
 
        public ActionResult Edit(int id)
        {
            EstimateForm estimateform = db.EstimateForm.Find(id);
            return View(estimateform);
        }

        //
        // POST: /Administration/Estimates/Edit/5

        [HttpPost]
        public ActionResult Edit(EstimateForm estimateform)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estimateform).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estimateform);
        }

        //
        // GET: /Administration/Estimates/Delete/5
 
        public ActionResult Delete(int id)
        {
            EstimateForm estimateform = db.EstimateForm.Find(id);
            return View(estimateform);
        }

        //
        // POST: /Administration/Estimates/Delete/5

        [HttpPost, ActionName("DeleteEstimate")]
        public ActionResult DeleteConfirmed(int id)
        {            
            EstimateForm estimateform = db.EstimateForm.Find(id);
            db.EstimateForm.Remove(estimateform);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
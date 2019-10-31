using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OCMovers_MC4.DAL;
using OCMovers_MC4.Models;

namespace OCMovers_MC4.Areas.WeMoveIt.Controllers
{
    [Authorize]
    public class ContentController : Controller
    {
        private readonly OCMovers_MVC4Context db = new OCMovers_MVC4Context();

        public ActionResult Index()
        {
            Content content = db.Content.Find(1);
            return View(content);
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(Content content)
        {
            if (ModelState.IsValid)
            {
                db.Entry(content).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(content);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}

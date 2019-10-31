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

namespace OCMovers_MC4.Areas.WeMoveIt.Controllers
{
    public class RoomsController : Controller
    {
        private OCMovers_MVC4Context db = new OCMovers_MVC4Context();

        //
        // GET: /Administration/Rooms/

        public ViewResult Index()
        {
            return View(db.Room.ToList());
        }

        //
        // GET: /Administration/Rooms/Details/5

        public ViewResult Details(int id)
        {
            Room room = db.Room.Find(id);
            return View(room);
        }

        //
        // GET: /Administration/Rooms/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Administration/Rooms/Create

        [HttpPost]
        public ActionResult Create(Room room)
        {
            if (ModelState.IsValid)
            {
                db.Room.Add(room);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(room);
        }

        //
        // GET: /Administration/Rooms/Edit/5

        public ActionResult Edit(int id)
        {
            Room room = db.Room.Find(id);
            return View(room);
        }

        //
        // POST: /Administration/Rooms/Edit/5

        [HttpPost]
        public ActionResult Edit(Room room)
        {
            if (ModelState.IsValid)
            {
                db.Entry(room).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(room);
        }

        //
        // GET: /Administration/Rooms/Delete/5

        //[HttpPost]
        //public ActionResult Delete(int id)
        //{
        //	Room room = db.Room.Find(id);
        //	return View(room);
        //}

        //
        // POST: /Administration/Rooms/Delete/5

        [HttpGet, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Room room = db.Room.Find(id);
            db.Room.Remove(room);
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

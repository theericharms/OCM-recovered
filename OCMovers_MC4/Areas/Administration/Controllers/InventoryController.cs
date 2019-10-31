using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OCMovers_MC4.DAL;
using OCMovers_MC4.Models;

namespace OCMovers_MVC4.Areas.Administration.Controllers
{ 
    [Authorize]
    public class InventoryController : Controller
    {
        private OCMovers_MVC4Context db = new OCMovers_MVC4Context();

        public ViewResult Index()
        {
            return View(db.InventoryItem.ToList());
        }

        public ViewResult Details(int id)
        {
            InventoryItem inventoryitem = db.InventoryItem.Find(id);
            return View(inventoryitem);
        }

        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Create(string inventoryitem)
        {
            var invItem = new InventoryItem();

            invItem.inventoryItem = inventoryitem;

            if (ModelState.IsValid)
            {
                db.InventoryItem.Add(invItem);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(inventoryitem);
        }
        
 
        public ActionResult Edit(int id)
        {
            InventoryItem inventoryitem = db.InventoryItem.Find(id);
            return View(inventoryitem);
        }

        [HttpPost]
        public ActionResult Edit(InventoryItem inventoryitem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventoryitem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventoryitem);
        }

        [HttpGet, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            InventoryItem inventoryitem = db.InventoryItem.Find(id);
            db.InventoryItem.Remove(inventoryitem);
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
using System.Data;
using System.Web.Mvc;
using OCMovers_MC4.DAL;
using OCMovers_MC4.Models;

namespace OCMovers_MC4.Areas.Administration.Controllers
{ 
    public class ContentController : Controller
    {
        private readonly OCMovers_MVC4Context db = new OCMovers_MVC4Context();

        //
        // GET: /Administration/Content/

		//public ViewResult Index()
		//{
		//	return View(db.Content.ToList());
		//}

		////
		//// GET: /Administration/Content/Details/5

		//public ViewResult Details(int id)
		//{
		//	Content content = db.Content.Find(id);
		//	return View(content);
		//}

		////
		//// GET: /Administration/Content/Create

		//public ActionResult Create()
		//{
		//	return View();
		//} 

        //
        // POST: /Administration/Content/Create

		//[HttpPost]
		//public ActionResult Create(Content content)
		//{
		//	if (ModelState.IsValid)
		//	{
		//		db.Content.Add(content);
		//		db.SaveChanges();
		//		return RedirectToAction("Index");  
		//	}

		//	return View(content);
		//}
        
        //
        // GET: /Administration/Content/Edit/5
 
        public ActionResult Index()
        {
            Content content = db.Content.Find(1);
            return View(content);
        }

        //
        // POST: /Administration/Content/Edit/5

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

        //
        // GET: /Administration/Content/Delete/5
 
		//public ActionResult Delete(int id)
		//{
		//	Content content = db.Content.Find(id);
		//	return View(content);
		//}

		////
		//// POST: /Administration/Content/Delete/5

		//[HttpPost, ActionName("Delete")]
		//public ActionResult DeleteConfirmed(int id)
		//{            
		//	Content content = db.Content.Find(id);
		//	db.Content.Remove(content);
		//	db.SaveChanges();
		//	return RedirectToAction("Index");
		//}

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
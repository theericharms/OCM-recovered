using System.Linq;
using System.Web.Mvc;
using OCMovers_MC4.DAL;

namespace OCMovers_MC4.Controllers
{
    public class AjaxController : Controller
    {
        //
        // GET: /Ajax/

		OCMovers_MVC4Context db = new OCMovers_MVC4Context();

		public ActionResult Index()
		{

			var inventoryList = db.InventoryItem.ToList();

			return View();
		}

        public ActionResult InventoryCheckboxes()
        {

			var inventoryList = db.InventoryItem.ToList();

            return PartialView("_InventoryChexboxes", inventoryList);
        }

    }
}

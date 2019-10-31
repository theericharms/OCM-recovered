using System.Linq;
using System.Web.Mvc;
using OCMovers_MC4.DAL;

namespace OCMovers_MC4.Controllers
{
    public class ListsController : Controller
    {
        //
        // GET: /Lists/

        private OCMovers_MVC4Context db = new OCMovers_MVC4Context();

        public ActionResult InventoryItems()
        {
            var inventoryList = db.InventoryItem.OrderBy(i => i.inventoryItem);

            return View(inventoryList);
        }

    }
}

using System.Linq;
using System.Web.Mvc;
using OCMovers_MC4.DAL;
using OCMovers_MC4.Models;

namespace OCMovers_MC4.Controllers
{
    public class AboutController : Controller
    {
        //
        // GET: /About/

		OCMovers_MVC4Context db = new OCMovers_MVC4Context();

        public ActionResult Index()
        {
            @ViewBag.Title = "Old City Movers | A Philadelphia, PA insured & bonded moving company";

            @ViewBag.Description = "Old City Movers is an insured & bonded Philadelphia-based company for people who need honest, experienced, efficient & affordable moving solutions.";

            @ViewBag.Keywords = "Moving company, movers, residential, home, storage, warehouse, commercial, furniture, Philadelphia movers, New York movers, Delaware movers, New Jersey Movers";

            Content content = db.Content.FirstOrDefault();
			return View(content);
        }

    }
}

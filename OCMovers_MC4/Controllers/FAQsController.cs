using System.Linq;
using System.Web.Mvc;
using OCMovers_MC4.DAL;
using OCMovers_MC4.Models;

namespace OCMovers_MC4.Controllers
{
    public class FAQsController : Controller
    {
        //
        // GET: /FAQs/

		OCMovers_MVC4Context db = new OCMovers_MVC4Context();

        public ActionResult Index()
        {
            @ViewBag.Title = "Old City Movers FAQ | A Philadelphia, PA insured & bonded moving company";

            @ViewBag.Description = "Answers to questions you should know to help plan your move with Old City Movers";

            @ViewBag.Keywords = "Moving company, movers, residential, home, storage, warehouse, commercial, furniture, Philadelphia movers, New York movers, Delaware movers, New Jersey Movers";
            
            Content content = db.Content.FirstOrDefault();
			return View(content);
        }

    }
}

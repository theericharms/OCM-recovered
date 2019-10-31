using System.Web.Mvc;

namespace OCMovers_MC4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            @ViewBag.Title = "Old City Movers Estimate | A Philadelphia, PA insured & bonded moving company";

            @ViewBag.Description = "Old City Movers is an insured and bonded Philadelpha PA based moving company";

            @ViewBag.Keywords = "Moving company, movers, residential, home, storage, warehouse, commercial, furniture, Philadelphia movers, New York movers, Delaware movers, New Jersey Movers";

            return View();
        }
    }
}

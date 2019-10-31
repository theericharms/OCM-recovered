
using System.Web.Mvc;

namespace OCMovers_MC4.Areas.Administration.Controllers
{
    public class AdministrationController : Controller
    {
        //
        // GET: /Administration/Home/

        [Authorize]
        public ActionResult Index()
        {
            //if (Session["adminUsername"] == null)
            //{
            //    return RedirectToAction("Login", "Admin", new { Area = "Administration" });
            //}

            return View();
        }
    }
}

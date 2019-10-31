using System.Linq;
using System.Web.Mvc;
using DotNetOpenAuth.OpenId.Extensions.AttributeExchange;
using System.Diagnostics;
using OCMovers_MVC4.Mailers;
using OCMovers_MC4.DAL;
using OCMovers_MC4.Models;
using OCMovers_MC4.ViewModel;

namespace OCMovers_MC4.Controllers
{
    public class ContactController : Controller
    {
        //
        // GET: /Contact/

		OCMovers_MVC4Context db = new OCMovers_MVC4Context();

        public ActionResult Index()
        {
            @ViewBag.Title = "Contact Old City Movers | A Philadelphia, PA insured & bonded moving company";

            @ViewBag.Description = "Old City Movers is an insured & bonded Philadelphia-based company for people who need honest, experienced, efficient & affordable moving solutions.";

            @ViewBag.Keywords = "Moving company, movers, residential, home, storage, warehouse, commercial, furniture, Philadelphia movers, New York movers, Delaware movers, New Jersey Movers";
            
            Content content = db.Content.FirstOrDefault();
			return View(content);
        }

		private IUserMailer _userMailer = new UserMailer();
		public IUserMailer UserMailer
		{
			get { return _userMailer; }
			set { _userMailer = value; }
		}

		[HttpPost]
		public ActionResult Index(Contact contact)
		{
			Debug.WriteLine(contact.Name);
			
			UserMailer.ContactUs(contact).Send();

			return RedirectToAction("Thanks");
		}

        [HttpPost]
        public ActionResult IndexRedirect()
        {
            return PartialView("Index");
        }

		public ActionResult Thanks()
		{
			return View();
		}
    }
}

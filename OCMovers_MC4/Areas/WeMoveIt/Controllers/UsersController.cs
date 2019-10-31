using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using OCMovers_MC4.Filters;
using OCMovers_MC4.Models;
using OCMovers_MC4.DAL;
using WebMatrix.WebData;

namespace OCMovers_MC4.Areas.WeMoveIt.Controllers
{
    public class UsersController : Controller
    {
        private OCMovers_MVC4Context db = new OCMovers_MVC4Context();

        //
        // GET: /WeMoveIt/Users/

        public ActionResult Index()
        {
            return View(db.UserProfiles.ToList());
        }

        //
        // GET: /WeMoveIt/Users/Details/5

        public ActionResult Details(int id = 0)
        {
            UserProfile userprofile = db.UserProfiles.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        //
        // GET: /WeMoveIt/Users/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /WeMoveIt/Users/Create

        [HttpPost]
        [Authorize]
        [InitializeSimpleMembership]
        public ActionResult Create(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                try
                {
                    string confirmationToken = WebSecurity.CreateUserAndAccount(
                                            model.UserName,
                                            model.Password,
                                            new
                                            {
                                                Active = true,
                                                SoftDelete = false,
                                                EmailAddress = ""
                                            }, false);

                    Roles.AddUserToRole(model.UserName, "General");
                    //WebSecurity.Login(model.UserName, model.Password);

                    return RedirectToRoute("Users");

                }
                catch (MembershipCreateUserException e)
                {
                    return null;
                }
            }

            return View(model);
        }

        //
        // GET: /WeMoveIt/Users/Edit/5

        public ActionResult Edit(int id = 0)
        {
            UserProfile userprofile = db.UserProfiles.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }

            return View(userprofile);
        }

        //
        // POST: /WeMoveIt/Users/Edit/5

        [HttpPost]
        public ActionResult Edit(UserProfile userprofile)
        {

            if (ModelState.IsValid)
            {
                db.Entry(userprofile).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToRoute("Users");
            }
            return View(userprofile);
        }

        //
        // GET: /WeMoveIt/Users/Delete/5

        public ActionResult Delete(int id = 0)
        {
            UserProfile userprofile = db.UserProfiles.Find(id);
            if (userprofile == null)
            {
                return HttpNotFound();
            }
            return View(userprofile);
        }

        //
        // POST: /WeMoveIt/Users/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            UserProfile userprofile = db.UserProfiles.Find(id);
            db.UserProfiles.Remove(userprofile);
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
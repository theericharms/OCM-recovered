using System;
using OCMovers_MC4.DAL;
using OCMovers_MC4.Models;
using OCMovers_MC4.ViewModel;
using Mvc.Mailer;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Configuration;
using EstimateForm = OCMovers_MC4.ViewModel.EstimateForm;

namespace OCMovers_MVC4.Mailers
{ 
    public class UserMailer : MailerBase, IUserMailer 	
	{
		public UserMailer()
		{
			MasterName="_Layout";
		}

		OCMovers_MVC4Context db = new OCMovers_MVC4Context();

        // OCM Copy
		//public virtual MvcMailMessage Welcome(EstimateForm estimateForm, List<EstimateFormInventory> model)
        public virtual MvcMailMessage Welcome(OCMovers_MC4.Models.EstimateForm estimateForm)
		{
			ViewData["estimateForm"] = estimateForm;
			//ViewBag.EstimateFormInventory = model;

		    
		    var isFlex = @estimateForm.IsDateFlexible ? "*" : "";
		    var month = @estimateForm.moveDateEnd.ToString("MMM");
		    var day = @estimateForm.moveDateEnd.ToString("dd");
            var moveDate = string.Concat(month," ", day, isFlex);

			
            return Populate(x =>
            {
                x.Subject = "Old City Movers Estimate Form Received: " + estimateForm.name.ToUpper() + " ( " + moveDate + " )";
                x.ViewName = "CustomerCopyEstimateForm";
                x.To.Add(new MailAddress(estimateForm.email, displayName: estimateForm.name.ToUpper()));
                x.Bcc.Add(new MailAddress(ConfigurationManager.AppSettings["EstimateEmail"]));
                x.Bcc.Add(new MailAddress(ConfigurationManager.AppSettings["EricBCCEmail"]));
                x.From = new MailAddress(estimateForm.email, displayName: estimateForm.name.ToUpper());
                x.Sender = new MailAddress(estimateForm.email, displayName: estimateForm.name.ToUpper());
                x.IsBodyHtml = true;


                //x.Subject = string.Concat(estimateForm.name.ToUpper() + " Old City Movers Estimate ( ", moveDate, " )");
                //x.ViewName = "Welcome";
                //x.To.Add(new MailAddress(ConfigurationManager.AppSettings["EricBCCEmail"]));
                //x.Bcc.Add(new MailAddress(ConfigurationManager.AppSettings["EstimateEmail"]));
                ////x.Bcc.Add(new MailAddress(ConfigurationManager.AppSettings["EricBCCEmail"]));
                //x.From = new MailAddress(estimateForm.email, displayName: estimateForm.name.ToUpper());
                //x.Sender = new MailAddress(estimateForm.email, displayName: estimateForm.name.ToUpper());
                ////x.CC.Add(new MailAddress(estimateForm.email));
                //x.IsBodyHtml = true;
            });
		}

        // Application uses Welcome method above.  This is a duplicate
        // Customer Copy
        //public virtual MvcMailMessage CustomerCopyEstimateForm(EstimateForm estimateForm, List<EstimateFormInventory> model)
        public virtual MvcMailMessage CustomerCopyEstimateForm(EstimateForm estimateForm)
        {

            ViewData["estimateForm"] = estimateForm;
            //ViewBag.EstimateFormInventory = model;

             var isFlex = @estimateForm.IsDateFlexible ? "*" : "";
            var month = @estimateForm.moveDateEnd.ToString("MMM");
            var day = @estimateForm.moveDateEnd.ToString("dd");
            var moveDate = string.Concat(month," ", day, isFlex);

            return Populate(x =>
            {
                x.Subject = "Old City Movers Estimate Form Received: " + estimateForm.name.ToUpper() + " ( " + moveDate + " )";
                x.ViewName = "CustomerCopyEstimateForm";
                x.To.Add(new MailAddress(estimateForm.email, displayName: estimateForm.name.ToUpper()));
                x.Bcc.Add(new MailAddress(ConfigurationManager.AppSettings["EstimateEmail"]));
                x.Bcc.Add(new MailAddress(ConfigurationManager.AppSettings["EricBCCEmail"]));
                x.From = new MailAddress(estimateForm.email, displayName: estimateForm.name.ToUpper());
                x.Sender = new MailAddress(estimateForm.email, displayName: estimateForm.name.ToUpper());
                x.IsBodyHtml = true;
            });
        }

        public virtual MvcMailMessage ContactUs(Contact contact)
		{
			ViewData["contactForm"] = contact;

			Debug.WriteLine(contact);

			return Populate(x =>
			{
				x.Subject = contact.Name.ToUpper() + " : " + contact.Topic.ToUpper() + " : " + contact.Subject;
				x.ViewName = "ContactUs";
                x.To.Add(new MailAddress(contact.Email, displayName: contact.Name.ToUpper()));
                x.Bcc.Add(new MailAddress(ConfigurationManager.AppSettings["EstimateEmail"]));
                x.Bcc.Add(new MailAddress(ConfigurationManager.AppSettings["EricBCCEmail"]));
                x.From = new MailAddress(contact.Email, displayName: contact.Name.ToUpper());
                x.Sender = new MailAddress(contact.Email, displayName: contact.Name.ToUpper());
				x.IsBodyHtml = true;
			});
		}

        public virtual MvcMailMessage SendErrorLog(string estimateForm)
        {
            ViewData["estimateForm"] = estimateForm;

            return Populate(x =>
            {
                x.Subject = "OCM Error Form Submission";
                x.ViewName = "SendErrorLog";
                x.To.Add(new MailAddress(ConfigurationManager.AppSettings["EricBCCEmail"]));
                x.From = new MailAddress(ConfigurationManager.AppSettings["EstimateEmail"]);
                x.Sender = new MailAddress(ConfigurationManager.AppSettings["EstimateEmail"]);
                x.IsBodyHtml = true;
            });
        }

        public virtual MvcMailMessage SendModelStateError(string output)
        {
            ViewData["estimateForm"] = output;

            return Populate(x =>
            {
                x.Subject = "OCM Error Form Submission Model State";
                x.ViewName = "ModelStateError";
                x.To.Add(new MailAddress(ConfigurationManager.AppSettings["EricBCCEmail"]));
                x.From = new MailAddress(ConfigurationManager.AppSettings["EstimateEmail"]);
                x.Sender = new MailAddress(ConfigurationManager.AppSettings["EstimateEmail"]);
                x.IsBodyHtml = true;
            });
        }
 	}
}
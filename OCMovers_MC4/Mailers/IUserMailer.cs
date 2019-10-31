using System;
using OCMovers_MC4.Models;
using OCMovers_MC4.ViewModel;
using Mvc.Mailer;
using System.Collections.Generic;
using EstimateForm = OCMovers_MC4.Models.EstimateForm;


namespace OCMovers_MVC4.Mailers
{ 
    public interface IUserMailer
    {
		MvcMailMessage Welcome(EstimateForm estimateForm);
        //MvcMailMessage Welcome(EstimateForm estimateForm, List<EstimateFormInventory> model);
		//MvcMailMessage CustomerCopyEstimateForm(EstimateForm estimateForm, List<EstimateFormInventory> model);
        MvcMailMessage CustomerCopyEstimateForm(OCMovers_MC4.ViewModel.EstimateForm estimateForm);
        MvcMailMessage SendErrorLog(string estimateForm);
        MvcMailMessage SendModelStateError(string output);
		MvcMailMessage ContactUs(Contact contact);
	}
}
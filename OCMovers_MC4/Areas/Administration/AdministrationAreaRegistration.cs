using System.Web.Mvc;

namespace OCMovers_MC4.Areas.Administration
{
	public class AdministrationAreaRegistration : AreaRegistration
	{
		public override string AreaName
		{
			get
			{
				return "Administration";
			}
		}

		public override void RegisterArea(AreaRegistrationContext context)
		{
            context.MapRoute(
               "Estimates",
               "Administration/{action}/{id}",
               new { area = "Administration", controller = "Estimates", action = "Index", id = UrlParameter.Optional }
               ); 
             
            context.MapRoute(
               "Administration_default",
               "Administration/{action}/{id}",
               new { area="Administration", controller="Administration", action = "Index", id = UrlParameter.Optional }
               ); 
		}
	}
}

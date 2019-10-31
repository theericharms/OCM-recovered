using System.Web.Mvc;

namespace OCMovers_MC4.Areas.WeMoveIt
{
    public class WeMoveItAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "WeMoveIt";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "CreateCustomerEstimate",
                "WeMoveIt/CreateCustomerEstimate/{id}",
                new { controller = "Estimates", action = "CreateCustomerEstimate", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "SaveCustomerEstimate",
                "WeMoveIt/SaveCustomerEstimate/{id}",
                new { controller = "Estimates", action = "SaveCustomerEstimate", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "EditCustomerEstimate",
                "WeMoveIt/EditCustomerEstimate/{id}",
                new { controller = "Estimates", action = "EditCustomerEstimate", id = UrlParameter.Optional }
            );
            
            context.MapRoute(
                "EstimateSubmissions",
                "WeMoveIt/EstimateSubmissions",
                new { area = "", controller = "Estimates", action = "Index", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "EstimateSubmissionDetail",
                "WeMoveIt/EstimateSubmissionDetail/{id}",
                new { area = "", controller = "Estimates", action = "Details", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Users",
                "WeMoveIt/Users",
                new { area = "", controller = "Users", action = "Index", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Inventory",
                "WeMoveIt/Inventory",
                new { area = "", controller = "Inventory", action = "Index", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Rooms",
                "WeMoveIt/Rooms",
                new { area = "", controller = "Rooms", action = "Index", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "Content",
                "WeMoveIt/Content",
                new { area = "", controller = "Content", action = "Index", id = UrlParameter.Optional }
            );

            
            
            
            context.MapRoute(
                "WeMoveIt_default",
                "WeMoveIt/{controller}/{action}/{id}",
                new { area = "WeMoveIt", controller = "Estimates", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

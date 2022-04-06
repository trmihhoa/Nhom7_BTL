using System.Web.Mvc;

namespace Nhom7_BTL.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Admin",
                "Admin/{controller}/{action}/{id}",
                new { action = "Index", controller="Home", id = UrlParameter.Optional }
            );
        }
    }
}
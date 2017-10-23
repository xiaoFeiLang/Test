using System.Web.Mvc;

namespace NB.Web.Areas.Authen
{
    public class AuthenAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Authen";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Authen_default",
                "Authen/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
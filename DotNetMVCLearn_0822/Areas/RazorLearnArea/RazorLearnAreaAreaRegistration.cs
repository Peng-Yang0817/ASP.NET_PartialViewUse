using System.Web.Mvc;

namespace DotNetMVCLearn_0822.Areas.RazorLearnArea
{
    public class RazorLearnAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "RazorLearnArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "RazorLearnArea_default",
                "RazorLearnArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
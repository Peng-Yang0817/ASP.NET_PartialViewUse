using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DotNetMVCLearn_0822
{
    /// <summary>
    /// 進行路由規則的聲明
    /// </summary>
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            // 忽略路由
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            // 路由規則通過Key Value存取
            // name對應Key , url對應Value
            routes.MapRoute(
                name: "homeRegist", // Key
                url: "{controller}/{action}_{year}_{month}_{day}", // Value
                defaults: new { controller = "Home", action = "String", id = UrlParameter.Optional },
                constraints: new
                {
                    year = @"\d{4}",
                    month = @"\d{2}",
                    day = @"\d{2}",
                }
            );

            // 這會使用homeRegist找到對應Action
            // http://localhost:8888/Home/String_2021_06_10 ;
            // 這會使用Default找到對應Action 
            // http://localhost:8888/Home/String?year=2021&month=06&day=10 ;

            // 路由規則通過Key Value存取
            // name對應Key , url對應Value
            routes.MapRoute(
                name: "Default", // Key
                url: "{controller}/{action}/{id}", // Value
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using DotNetMVCLearn_0822.Infrastructures;

namespace DotNetMVCLearn_0822
{
    public class MvcApplication : System.Web.HttpApplication
    {
        /// <summary>
        /// 網站初始化動作;
        /// 
        /// 為了讓網站運行時，把需要的各總組件都先配置好
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas(); // 註冊區;
                                                 // 開發時，功能模塊會很多(登入、權限控制等)，
                                                 // 因此，希望根據模塊劃分，進行模塊化的開發，也就是加入區域(Areas)概念;
            DIContainer.Register();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters); // 註冊全局Filter
            RouteConfig.RegisterRoutes(RouteTable.Routes); // 註冊路由
            BundleConfig.RegisterBundles(BundleTable.Bundles); // 註冊Bundle 引用JS/CSS需要的組件
        }
    }
}

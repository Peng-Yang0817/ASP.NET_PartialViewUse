using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Configuration;
using Microsoft.Practices.Unity.Configuration;
using Unity;
using System.IO;

using DotNetMVCLearn_EF.WaterQuality; // Dd服務操作設置
using DotNetMVCLearn_Service.WaterQuality; // 建立好的DdContext取得位置
using System.Data.Entity;


namespace DotNetMVCLearn_0822.Areas.AuthArea.Controllers
{
    public class UseIOCgetServiceController : Controller
    {
        // GET: AuthArea/UseIOCgetService
        public ActionResult Index()
        {
            // 讀取配置文件
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfigFiles\\Unity.Config"); // 從bin目錄讀取的檔案
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            // 讀取SectionName為unity的節點
            UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection
                (UnityConfigurationSection.SectionName);

            // 實例化Container
            IUnityContainer container = new UnityContainer();
            // 將 [section] 在 [unity] 節點讀取的 [pengYangContainer] container 訊息，
            //  交給我們實例化的 container
            section.Configure(container, "pengYangContainer");


            DbContext dbContext = container.Resolve<DbContext>();
            WaterQualityService waterQualityService = container.Resolve<WaterQualityService>();

            Auth001 data = waterQualityService.Find<Auth001>(3);

            List<Auth001> datas = waterQualityService.Query<Auth001>(x => x.Id <= 10).ToList();

            ViewBag.Msg = "";
            if (TempData["Msg"] != null)
            {
                ViewBag.Msg = TempData["Msg"];
            }

            ViewBag.datas = datas;


            return View();
        }
    }
}
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

using DotNetMVCLearn_0822.Unitys;

namespace DotNetMVCLearn_0822.Areas.AuthArea.Controllers
{
    public class UseIOCgetServiceController : Controller
    {
        private IUnityContainer container = UseIOCgetServiceControllerFactory.GetContainer();

        [HttpGet]
        public ActionResult Index()
        {
            //// ===================================== 調用配置與處理 START
            //// 讀取配置文件
            //ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            //fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + "CfigFiles\\Unity.Config"); // 從bin目錄讀取的檔案
            //Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            //// 讀取SectionName為unity的節點
            //UnityConfigurationSection section = (UnityConfigurationSection)configuration.GetSection
            //    (UnityConfigurationSection.SectionName);

            //// 實例化Container
            //IUnityContainer container = new UnityContainer();
            //// 將 [section] 在 [unity] 節點讀取的 [pengYangContainer] container 訊息，
            ////  交給我們實例化的 container
            //section.Configure(container, "pengYangContainer");
            //// ===================================== END




            // DbContext dbContext = container.Resolve<DbContext>();
            // WaterQualityService建構式需要的DbContext會自動注入
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

        [HttpGet]
        public ActionResult Edit(int Auth001Id)
        {
            WaterQualityService waterQualityService = container.Resolve<WaterQualityService>();

            Auth001 data = waterQualityService.Find<Auth001>(Auth001Id);
            
            if (data == null)
            {
                return RedirectToAction("Index", "UseIOCgetService", new { area = "AuthArea" });
            }

            ViewBag.data = data;

            return View();
        }

        [HttpPost]
        public ActionResult Edit(Auth001 auth001NameAndEmail)
        {
            WaterQualityService waterQualityService = container.Resolve<WaterQualityService>();

            Auth001 data = waterQualityService.Find<Auth001>(auth001NameAndEmail.Id);

            // 使用者不存在
            if (data == null)
            {
                return RedirectToAction("Index", "UseIOCgetService", new { area = "AuthArea" });
            }

            data.UserName = auth001NameAndEmail.UserName;
            data.Email = auth001NameAndEmail.Email;

            TempData["Msg"] = "發生錯誤! 更動失敗。";
            if (waterQualityService.Update(data))
            {
                TempData["Msg"] = "更動成功!";
            }

            return RedirectToAction("Index", "UseIOCgetService", new { area = "AuthArea" });
        }
    }
}
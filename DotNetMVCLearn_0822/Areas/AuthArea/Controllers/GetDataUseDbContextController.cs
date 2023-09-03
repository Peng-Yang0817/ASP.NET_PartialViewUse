using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetMVCLearn_Service.WaterQuality;
using DotNetMVCLearn_EF.WaterQuality;

namespace DotNetMVCLearn_0822.Areas.AuthArea.Controllers
{
    public class GetDataUseDbContextController : Controller
    {
        // GET: AuthArea/GetDataUseDbContext
        public ActionResult Index()
        {
            // 透過EF 來註冊ServiceProject
            WaterQualityService waterQualityService = new WaterQualityService(
                                                        new EF_WaterQualityModel());

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

        /// <summary>
        /// 編輯
        /// </summary>
        /// <param name="Auth001Id ">用戶代碼</param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Edit(int Auth001Id)
        {
            // 透過EF 來註冊ServiceProject
            WaterQualityService waterQualityService = new WaterQualityService(
                                                        new EF_WaterQualityModel());

            Auth001 data = waterQualityService.Find<Auth001>(Auth001Id);

            if (data == null)
            {
                return RedirectToAction("Index", "GetDataUseDbContext", new { area = "AuthArea" });
            }

            ViewBag.data = data;
            return View();
        }

        [HttpPost]
        public ActionResult Edit(Auth001 auth001NameAndEmail)
        {
            // 透過EF 來註冊ServiceProject
            WaterQualityService waterQualityService = new WaterQualityService(
                                                        new EF_WaterQualityModel());

            Auth001 data = waterQualityService.Find<Auth001>(auth001NameAndEmail.Id);

            // 使用者不存在
            if (data == null)
            {
                return RedirectToAction("Index", "GetDataUseDbContext", new { area = "AuthArea" });
            }

            data.UserName = auth001NameAndEmail.UserName;
            data.Email = auth001NameAndEmail.Email;

            TempData["Msg"] = "發生錯誤! 更動失敗。";
            if (waterQualityService.Update(data))
            {
                TempData["Msg"] = "更動成功!";
            }

            return RedirectToAction("Index", "GetDataUseDbContext", new { area = "AuthArea" });
        }
    }
}
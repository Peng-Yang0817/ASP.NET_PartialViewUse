using DotNetMVCLearn_EF.WaterQuality;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNetMVCLearn_0822.Areas.AuthArea.Controllers
{
    public class AutofacDIController : Controller
    {
        private readonly EF_WaterQualityModel _waterQualityDb;
        public AutofacDIController(EF_WaterQualityModel waterQualityDb)
        {
            _waterQualityDb = waterQualityDb;
        }

        // GET: AuthArea/AutofacDI
        public ActionResult Index()
        {
            var aquariumDatas = _waterQualityDb.Aquarium
                .Select(x => new AquariumDetail()
                {
                    auth001Id = x.Auth001Id,
                    userName = x.Auth001.UserName,
                    email = x.Auth001.Email,
                    aquariumUnitNum = x.AquariumUnitNum,
                    bindTag = x.BindTag == "0" ? "使用中" : "已停用"
                })
                .ToList();

            ViewBag.aquariumDatas = aquariumDatas;

            return View();
        }
    }

    public class AquariumDetail 
    {
        public int auth001Id { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string aquariumUnitNum { get; set; }
        public string bindTag { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetMVCLearn_EF.WaterQuality;

namespace DotNetMVCLearn_0822.Areas.AuthArea.Controllers
{
    public class EFProjectUseController : Controller
    {
        // GET: AuthArea/EFProjectUse
        public ActionResult Index()
        {
            List<Auth001> datas = new List<Auth001>();
            using (EF_WaterQualityModel db = new EF_WaterQualityModel())
            {
                datas = db.Auth001.ToList();
            }

            ViewBag.datas = datas == null ? new List<Auth001>() : datas;

            return View();
        }
    }
}
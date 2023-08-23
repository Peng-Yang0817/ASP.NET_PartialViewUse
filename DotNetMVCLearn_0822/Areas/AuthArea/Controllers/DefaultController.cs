using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetMVCLearn_0822.Models.WaterQualityContext;

namespace DotNetMVCLearn_0822.Areas.AuthArea.Controllers
{
    public class DefaultController : Controller
    {

        // 使用本專案擁有的EF連接
        public ActionResult Index()
        {
            List<Auth001> datas = new List<Auth001>();
            using (WaterQualityEntities db = new WaterQualityEntities())
            {
                datas = db.Auth001.ToList();
            }

            ViewBag.datas = datas == null ? new List<Auth001>() : datas;

            return View();
        }


    }
}
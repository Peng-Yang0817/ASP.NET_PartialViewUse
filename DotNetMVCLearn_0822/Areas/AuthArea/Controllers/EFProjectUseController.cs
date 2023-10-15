using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                var datas_detail1 = datas.Select(r => new UserDataDetail
                {
                    Name = r.UserName,
                    Email = r.Email
                });

                var datas_detail2 = datas.Select(r => new
                {
                    r.LineID,
                    r.UserName,
                    r.LineToken
                });

                var datas_detail3 = from c in datas
                                    where c.Id > 3
                                    select new { c.UserName, c.Email };
                var datas_detail4 = datas.Where(x => x.Id > 3)
                                    .Select(x => new { x.UserName, x.Email });

                var datas_detailI4 = db.Aquarium.Where(x => x.BindTag == "0")
                                                .Include(x=>x.Auth001)
                                                .ToList();

                var datas_detailI5 = db.Aquarium.Where(x => x.BindTag == "0")
                                                .ToList();

                var datas_detailI6 = db.Aquarium.Where(x => x.BindTag == "0")
                                                .Include(x => x.Auth001);

                datas_detailI6 = datas_detailI6.Where(x => x.Id == 3);

                if (datas_detailI6.Any()) 
                {
                    var resault = datas_detailI6.ToList();
                }
                
            }

            ViewBag.datas = datas == null ? new List<Auth001>() : datas;

            return View();
        }
    }

    public class UserDataDetail
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DotNetMVCLearn_0822.Areas.RazorLearnArea.Controllers
{
    public class DefaultController : Controller
    {
        // GET: RazorLearnArea/Default
        public ActionResult Index(string name)
        {
            ViewBag.name = name == null ? "沒接收到" : name;
            return View();
        }

        // GET: RazorLearnArea/Default
        //public ActionResult _PartialTest()
        //{
        //    return PartialView();
        //}

        [ChildActionOnly]
        public ViewResult _PartialChildAction(string Name)
        {
            ViewBag.Name = Name;
            return View();
        }
    }
}
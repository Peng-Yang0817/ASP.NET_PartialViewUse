using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web;

// 建立Controller 讓主專案"DotNetMVCLearn_0822"能取得這個索引位置
namespace ControllerUseingDotCSharp
{
    public class Class1Controller : Controller
    {
        public ActionResult Index()
        {
            return View("~/Views/Home/Index.cshtml");
        }

        public ActionResult IndexToMainArea()
        {
            //return View("~/Areas/AuthArea/Views/Default/Index.cshtml");
            return RedirectToAction("Index", "Default", new { area = "AuthArea" });
        }
    }
}

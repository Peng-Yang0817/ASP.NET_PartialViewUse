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
        /// ������l�ưʧ@;
        /// 
        /// ���F�������B��ɡA��ݭn���U�`�ե󳣥��t�m�n
        /// </summary>
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas(); // ���U��;
                                                 // �}�o�ɡA�\��Ҷ��|�ܦh(�n�J�B�v�����)�A
                                                 // �]���A�Ʊ�ھڼҶ������A�i��Ҷ��ƪ��}�o�A�]�N�O�[�J�ϰ�(Areas)����;
            DIContainer.Register();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters); // ���U����Filter
            RouteConfig.RegisterRoutes(RouteTable.Routes); // ���U����
            BundleConfig.RegisterBundles(BundleTable.Bundles); // ���UBundle �ޥ�JS/CSS�ݭn���ե�
        }
    }
}

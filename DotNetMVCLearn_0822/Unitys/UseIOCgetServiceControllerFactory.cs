using Microsoft.Practices.Unity.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using Unity;

namespace DotNetMVCLearn_0822.Unitys
{
    public class UseIOCgetServiceControllerFactory
    {
        static IUnityContainer _Container = new UnityContainer();
        /// <summary>
        /// 靜態構造函數，執行且只執行一次
        /// </summary>
        static UseIOCgetServiceControllerFactory()
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
            section.Configure(_Container, "pengYangContainer");
        }

        public static IUnityContainer GetContainer()
        {
            return _Container;
        }
    }
}
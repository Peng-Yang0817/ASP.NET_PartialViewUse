using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetMVCLearn_IOCService.IServices;
using DotNetMVCLearn_IOCService.Models;

using Unity;

namespace DotNetMVCLearn_IOCService
{
    class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("XDXD");

            // 實例化
            IUnityContainer container = new UnityContainer();

            // 註冊對象
            // : 告知容器創建對象時，對應的對象關係
            container.RegisterType<IServiceA, ServiceA>();
            // 獲取對象實例
            // : 註冊完以後就能直接這樣創建
            IServiceA serviceA = container.Resolve<IServiceA>();
            serviceA.ShowA();
            Console.WriteLine("");

            // ServiceB 建構式中會需要傳入一個實力好的 IServiceA
            // 透過IOC，會自動引用上面註冊好的IServiceA
            container.RegisterType<IServiceB, ServiceB>();
            IServiceB serviceB = container.Resolve<IServiceB>();
            serviceB.ShowB();
            Console.WriteLine("");

            // ServiceC 中，使用屬性注入與方法注入。
            container.RegisterType<IServiceC, ServiceC>();
            IServiceC serviceC = container.Resolve<IServiceC>();
            Console.WriteLine("透過[Dependency]註冊 {0} 成功!", serviceC._serviceA.GetServiceName());
            serviceC._serviceBNew.serviceName = "方法注入產生的B服務";
            Console.WriteLine("透過[InjectionMethod]註冊的 {0} 成功!", serviceC._serviceBNew.serviceName);
            serviceC.ShowC();
        }
    }
}
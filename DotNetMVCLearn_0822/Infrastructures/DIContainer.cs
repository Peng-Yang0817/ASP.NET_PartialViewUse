using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using DotNetMVCLearn_0822.Infrastructures.Module;

namespace DotNetMVCLearn_0822.Infrastructures
{
    public static class DIContainer
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            // Register your MVC controllers. (MvcApplication is the name of
            // the class in Global.asax.)
            // 註冊控制器，以支持屬性注入
            //builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterServices();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        public static void RegisterServices(this ContainerBuilder builder)
        {
            // 註冊 Water Qulity DbContext Service
            builder.RegisterModule<WQDbContextModule>();
        }
    }
}
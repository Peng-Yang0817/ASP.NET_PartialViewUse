using DotNetMVCLearn_EF.WaterQuality;
using Autofac;

namespace DotNetMVCLearn_0822.Infrastructures.Module
{
    public class WQDbContextModule: Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EF_WaterQualityModel>().AsSelf();
        }
    }
}
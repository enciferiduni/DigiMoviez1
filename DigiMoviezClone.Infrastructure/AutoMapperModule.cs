using Autofac;
using AutoMapper;
using System.Reflection;

namespace DigiMoviezClone.API.Configuration
{
    public class AutoMapperModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => new MapperConfiguration(cfg =>
                {
                    
                    cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
                }))
                .AsSelf()
                .SingleInstance();

            builder.Register(ctx =>
                {
                    var config = ctx.Resolve<MapperConfiguration>();
                    return config.CreateMapper();
                })
                .As<IMapper>()
                .InstancePerLifetimeScope();
        }
        
    
    }
}
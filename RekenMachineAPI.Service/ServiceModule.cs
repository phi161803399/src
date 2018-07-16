using Autofac;

namespace RekenMachineAPI.Service
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BaseService>()
                .As<IBaseService>()
                .PropertiesAutowired();

            builder.RegisterAssemblyTypes(typeof(IService<>).Assembly)
                .AsClosedTypesOf(typeof(IService<>))
                .Where(x => x != typeof(GenericService<>))
                .AsImplementedInterfaces()
                .PropertiesAutowired();

            builder.RegisterGeneric(typeof(GenericService<>))
                .As(typeof(IService<>)).PropertiesAutowired();

            base.Load(builder);
        }
    }
}
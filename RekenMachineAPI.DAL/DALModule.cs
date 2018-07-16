using System.Data.Entity;
using Autofac;

namespace RekenMachineAPI.DAL
{
    public class DALModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<Context>()
                .As<DbContext>()
                .InstancePerLifetimeScope();
        }
    }
}
using System;
using System.Data.Entity;
using Autofac;
using Microsoft.Owin.Testing;
using Moq;

namespace RekenMachineAPI.Tests.Component.Helpers
{
    public class SystemUnderTest : IDisposable
    {
        private DbContext _database;

        public IContainer Container { get; set; }
        public TestServer Server { get; set; }

        //Shortcuts
        public DbContext Database => _database ?? (_database = Container.Resolve<DbContext>());
        public Mock<T> ResolveMock<T>() where T : class => Container.Resolve<Mock<T>>();
 
        public void Dispose()
        {
            Container?.Dispose();
            Server?.Dispose();            
            Database?.Dispose();
        }
    }
}
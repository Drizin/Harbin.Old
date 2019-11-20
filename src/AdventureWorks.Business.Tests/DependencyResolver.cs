using AdventureWorks.Business.Entities;
using AdventureWorks.Business.Services;
using Autofac;
using AutofacSerilogIntegration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Business.Tests
{
    public class DependencyResolver
    {
        private IContainer container;
        public IContainer Container { get { return this.container; } }

        public DependencyResolver()
        {
            Log.Verbose("DependencyResolver...");
            var builder = new ContainerBuilder();

            builder.Register(c => new AdventureWorksAppSettings(
                dbConnectionString: System.Configuration.ConfigurationManager.ConnectionStrings["AdventureWorks"].ConnectionString))
                .AsSelf().SingleInstance();

            // https://github.com/nblumhardt/autofac-serilog-integration
            // Another option (without ForContext, but registering ILogger) would be this: https://stackoverflow.com/a/29756122/3606250
            // This will setup context (.ForContext<SomeClass>()) in all classes using ILogger
            builder.RegisterLogger(autowireProperties: true);

            builder.RegisterType<AdventureWorksDB>().As<IAdventureWorksDB>()/*.InstancePerRequest()*/.InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(IAdventureWorksDB).Assembly)
                .AssignableTo<BaseService>()
                //.PropertiesAutowired(); // will auto wire (inject) all public properties
                .InstancePerLifetimeScope();

            container = builder.Build();
        }

        public void Dispose()
        {
            this.container.Dispose();
        }

        public TEntity Resolve<TEntity>()
        {
            return container.Resolve<TEntity>();
        }

    }
}

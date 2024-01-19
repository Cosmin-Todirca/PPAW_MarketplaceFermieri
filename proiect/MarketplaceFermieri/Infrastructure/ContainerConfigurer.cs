using Autofac;
using Autofac.Integration.WebApi;
using BusinessLayer_DBFirst;
using NivelAccessDate_DBFirst;
using NivelAccessDate_DBFirst.Interfaces;
using Repository_DBFirst;
using System.Reflection;
using System.Web.Http;

namespace MarketplaceFermieri.Infrastructure
{
    public class ContainerConfigurer
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Register dependencies in controllers
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // Register individual types 
            builder.RegisterType<marketplace_fermieriEntities>()
                .As<IDBContext>()
                .SingleInstance();

            builder.RegisterType<VanzatorServices>()
                .As<IVanzator>();
            builder.RegisterType<ClientServices>()
                .As<IClient>();
            builder.RegisterType<ComandaServices>()
                .As<IComanda>();
            builder.RegisterType<ObiectComandaServices>()
                .As<IObiectComanda>();
            builder.RegisterType<ProdusServices>()
                .As<IProdus>();
            builder.RegisterType<MemoryCacheService>()
                .As<ICache>();


            //builder.Register(currentContainer =>
            //    new CompaniesService()
            //    {
            //        DbContextProperty = currentContainer.Resolve<ICarDbContext>()
            //    }).As<ICompanies>();

            //builder.Register(component =>
            //    {
            //        var client = new CompaniesService();
            //        var dependency = component.Resolve<ICarDbContext>();
            //        client.SetDependency(dependency);
            //        return client;
            //    }).As<ICompanies>();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
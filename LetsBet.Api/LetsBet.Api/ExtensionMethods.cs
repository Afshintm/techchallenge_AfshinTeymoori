using System.Collections.Generic;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using LetsBet.BusinessServices;
using Microsoft.Extensions.DependencyInjection;

namespace LetsBet.Api
{
    public static class ExtensionMethods
    {
        public static ContainerBuilder GetAppContainerBuilder(this IServiceCollection services)
        {
            // Create the container builder.
            var builder = new ContainerBuilder();

            // Register dependencies, populate the services from
            // the collection, and build the container. If you want
            // to dispose of the container at the end of the app,
            // be sure to keep a reference to it as a property or field.
            //
            // Note that Populate is basically a foreach to add things
            // into Autofac that are in the collection. If you register
            // things in Autofac BEFORE Populate then the stuff in the
            // ServiceCollection can override those things; if you register
            // AFTER Populate those registrations can override things
            // in the ServiceCollection. Mix and match as needed.
            builder.Populate(services);
            return builder.RegisterAppComponents(services);
        }

        public static ContainerBuilder RegisterAppComponents(this ContainerBuilder builder, IEnumerable<ServiceDescriptor> services)
        {
            builder.RegisterType<HttpClientManager>().As<IHttpClientManager>().SingleInstance();
            builder.RegisterGeneric(typeof(BaseBusinessServices<>)).As(typeof(IBaseBusinessService<>)).InstancePerLifetimeScope();
            builder.RegisterType<CustomerBusinessServices>().As<ICustomerBusinessServices>().InstancePerLifetimeScope();
            builder.RegisterType<RaceBusinessServices>().As<IRaceBusinessServices>().InstancePerLifetimeScope();
            builder.RegisterType<BetBusinessServices>().As<IBetBusinessServices>().InstancePerLifetimeScope();

            return builder;
        }
    }
}

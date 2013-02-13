namespace Eossyn.Infrastructure.Injection
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using NServiceBus;
    using NServiceBus.ObjectBuilder;

    public static class ConfigureMvc3
    {
        public static Configure ForMVC(this Configure configure)
        {
            configure.Configurer.RegisterSingleton(typeof(IControllerActivator), new NServiceBusControllerActivator());
            var controllers = Configure.TypesToScan.Where(t => typeof(IController).IsAssignableFrom(t));
            foreach (Type type in controllers)
            {
                configure.Configurer.ConfigureComponent(type, DependencyLifecycle.InstancePerCall);
            }
            DependencyResolver.SetResolver(new NServiceBusResolverAdapter(configure.Builder));
            return configure;
        }
    }
}

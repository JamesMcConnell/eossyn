namespace Eossyn.Infrastructure.Injection
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using NServiceBus.ObjectBuilder;

    public class NServiceBusResolverAdapter : IDependencyResolver
    {
        private IBuilder _builder;

        public NServiceBusResolverAdapter(IBuilder builder)
        {
            _builder = builder;
        }

        public object GetService(Type serviceType)
        {
            return _builder.Build(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _builder.BuildAll(serviceType);
        }
    }
}

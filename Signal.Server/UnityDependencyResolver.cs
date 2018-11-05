using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Unity;

namespace Signal.Server
{
    public class UnityDependencyResolver : DefaultDependencyResolver
    {
        private readonly IUnityContainer _container;

        public UnityDependencyResolver(IUnityContainer container)
        {
            _container = container;
        }

        public override object GetService(Type serviceType)
        {
            return _container.IsRegistered(serviceType)
                       ? _container.Resolve(serviceType)
                       : base.GetService(serviceType);
        }

        public override IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.IsRegistered(serviceType)
                       ? _container.ResolveAll(serviceType)
                       : base.GetServices(serviceType);
        }
    }
}

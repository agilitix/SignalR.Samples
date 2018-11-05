using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using Unity;

[assembly: OwinStartup(typeof(Signal.Server.Startup))]

namespace Signal.Server
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.Map("/signalr",
                    map =>
                    {
                        IDependencyResolver resolver = new UnityDependencyResolver(UnityConfig.Container);
                        HubConfiguration hubConfiguration = new HubConfiguration
                                                            {
                                                                Resolver = resolver,
                                                                EnableJSONP = true,
                                                            };

                        map.UseCors(CorsOptions.AllowAll)
                           .RunSignalR(hubConfiguration);
                    });

            GlobalHost.TraceManager.Switch.Level = SourceLevels.Information;
        }
    }
}

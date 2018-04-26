using System;
using System.Threading.Tasks;
using Owin;
using System.Web.Http;
using Microsoft.Owin;
using WebApiThrottle;

[assembly: OwinStartup(typeof(MedicalInstruments.Server.Startup))]

namespace MedicalInstruments.Server
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            HttpConfiguration config = new HttpConfiguration();
            config.Routes.MapHttpRoute(name: "Default",
                routeTemplate: "api/{Controller}/{Action}/{id}",
                defaults: new
                {
                    id = RouteParameter.Optional
                });

            config.MessageHandlers.Add(new ThrottlingHandler()
            {
                Policy = new ThrottlePolicy(perSecond: 1, perMinute: 10, perHour: 200, perDay: 1500, perWeek: 3000)
                {
                    IpThrottling = true
                },
                Repository = new MemoryCacheRepository()
            });

            app.UseWebApi(config);
        }
    }
}

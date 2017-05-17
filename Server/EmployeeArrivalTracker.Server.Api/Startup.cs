using EmployeeArrivalTracker.Data;
using EmployeeArrivalTracker.Data.Migrations;
using EmployeeArrivalTracker.Server.Api.Config;
using Microsoft.Owin;
using Owin;
using System.Data.Entity;
using System.Web.Http;

[assembly: OwinStartup(typeof(EmployeeArrivalTracker.Server.Api.Startup))]

namespace EmployeeArrivalTracker.Server.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<EmployeeArrivalTrackerDbContext, Configuration>());

            var httpConfiguration = new HttpConfiguration();
            WebApiConfig.Register(httpConfiguration);
            app.UseWebApi(httpConfiguration);
        }
    }
}

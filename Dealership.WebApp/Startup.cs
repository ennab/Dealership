using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dealership.WebApp.Startup))]
namespace Dealership.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

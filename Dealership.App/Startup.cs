using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dealership.App.Startup))]
namespace Dealership.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

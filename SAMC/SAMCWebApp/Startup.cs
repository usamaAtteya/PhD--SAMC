using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SAMCWebApp.Startup))]
namespace SAMCWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
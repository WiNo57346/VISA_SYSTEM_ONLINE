using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VISA_SYSTEM_ONLINE.Startup))]
namespace VISA_SYSTEM_ONLINE
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

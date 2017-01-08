using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Richie.DRD.Startup))]
namespace Richie.DRD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

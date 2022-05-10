using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AIII.Startup))]
namespace AIII
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

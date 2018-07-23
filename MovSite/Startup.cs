using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MovSite.Startup))]
namespace MovSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

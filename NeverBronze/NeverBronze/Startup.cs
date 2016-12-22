using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NeverBronze.Startup))]
namespace NeverBronze
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

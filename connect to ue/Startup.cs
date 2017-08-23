using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(connect_to_ue.Startup))]
namespace connect_to_ue
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(aspfirstapp.Startup))]
namespace aspfirstapp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

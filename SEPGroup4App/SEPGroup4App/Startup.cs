using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SEPGroup4App.Startup))]
namespace SEPGroup4App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

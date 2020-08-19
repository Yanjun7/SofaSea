using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SofaSea.Startup))]
namespace SofaSea
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

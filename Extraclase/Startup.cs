using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Extraclase.Startup))]
namespace Extraclase
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

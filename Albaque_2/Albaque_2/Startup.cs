using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Albaque_2.Startup))]
namespace Albaque_2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BabySitter.Startup))]
namespace BabySitter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HireMe2.Startup))]
namespace HireMe2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

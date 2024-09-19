using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lifestyleEstate.Startup))]
namespace lifestyleEstate
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UnitTestingMVC.Startup))]
namespace UnitTestingMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

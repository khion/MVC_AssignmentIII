using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TPT.Startup))]
namespace TPT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

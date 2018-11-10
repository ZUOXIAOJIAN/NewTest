using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewTest.Web.Startup))]
namespace NewTest.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

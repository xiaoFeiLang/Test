using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NB.Web.Startup))]
namespace NB.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

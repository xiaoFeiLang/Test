using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lcq.Web.Startup))]
namespace Lcq.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

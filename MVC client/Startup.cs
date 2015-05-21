using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_client.Startup))]
namespace MVC_client
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

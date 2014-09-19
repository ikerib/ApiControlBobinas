using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ApiControlBobinas.Startup))]
namespace ApiControlBobinas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

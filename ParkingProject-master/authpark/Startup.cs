using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(authpark.Startup))]
namespace authpark
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

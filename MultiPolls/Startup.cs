using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MultiPolls.Startup))]
namespace MultiPolls
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

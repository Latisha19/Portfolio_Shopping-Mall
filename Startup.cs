using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCCC.Startup))]
namespace MVCCC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

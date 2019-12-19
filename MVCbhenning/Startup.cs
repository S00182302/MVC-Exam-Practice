using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCbhenning.Startup))]
namespace MVCbhenning
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

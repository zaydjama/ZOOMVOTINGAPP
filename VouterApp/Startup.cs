using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VouterApp.Startup))]
namespace VouterApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

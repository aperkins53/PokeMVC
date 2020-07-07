using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PokeMVC.Startup))]
namespace PokeMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

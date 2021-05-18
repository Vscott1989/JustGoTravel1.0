using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JustGoTravel.WebMVC.Startup))]
namespace JustGoTravel.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

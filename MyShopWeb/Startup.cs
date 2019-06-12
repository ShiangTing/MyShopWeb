using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyShopWeb.Startup))]
namespace MyShopWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ASPTestChat.Startup))]
namespace ASPTestChat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HootelRoomMVC.Startup))]
namespace HootelRoomMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

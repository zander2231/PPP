using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VS_Object_Mentor.Startup))]
namespace VS_Object_Mentor
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

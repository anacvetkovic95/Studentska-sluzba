using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(StudentskaSluzba.Startup))]
namespace StudentskaSluzba
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

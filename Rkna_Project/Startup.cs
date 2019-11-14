using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rkna_Project.Startup))]
namespace Rkna_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RepositoryPatternTutorial.Web.Startup))]
namespace RepositoryPatternTutorial.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

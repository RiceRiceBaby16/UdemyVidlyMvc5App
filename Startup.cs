using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CourseByMosh.Startup))]
namespace CourseByMosh
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

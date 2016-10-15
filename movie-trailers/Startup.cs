using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(movie_trailers.Startup))]
namespace movie_trailers
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

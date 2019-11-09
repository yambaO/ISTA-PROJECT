using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RecipeApp.Startup))]
namespace RecipeApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

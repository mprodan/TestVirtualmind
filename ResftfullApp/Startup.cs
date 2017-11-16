using Owin;

namespace ResftfullApp
{
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            app.UseNancy();
        }
    }
}

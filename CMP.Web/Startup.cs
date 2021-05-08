using CMP.Business.Services.AutoMapper;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CMP.Web.Startup))]
namespace CMP.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            AutoMapperConfiguration.ConfigureMappings();
            ConfigureAuth(app);

        }
    }
}

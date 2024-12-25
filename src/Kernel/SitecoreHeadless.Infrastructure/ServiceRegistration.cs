using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using SitecoreHeadless.Data.AppMetaData;
using SitecoreHeadless.Data.Models;

namespace SitecoreHeadless.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServiceRegistration(this IServiceCollection services)
        {
            //Swagger Gn
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(Router.Version, new OpenApiInfo { Title = Router.projectTitle, Version = Router.Version });
                c.EnableAnnotations();
            });
            return services;
        }
    }


}

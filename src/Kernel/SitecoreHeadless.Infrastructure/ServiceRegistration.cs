using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SitecoreHeadless.Data.AppMetaData;
using SitecoreHeadless.Data.Models;
using SolrNet;
using SitecoreHeadless.Helper.Services;

namespace SitecoreHeadless.Infrastructure
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServiceRegistration(this IServiceCollection services)
        {
           services.AddScoped<RecaptchaService>();
            //Swagger Gn
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(Router.Version, new OpenApiInfo { Title = Router.projectTitle, Version = Router.Version });
                c.EnableAnnotations();
            });


            services.AddLogging(configure => configure
                    .AddConsole()).AddSolrNet<MySolrModel>("https://localhost:8989/solr/sc1040_master_index");
                            return services;
        }
    }


}

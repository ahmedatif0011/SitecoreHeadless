using Microsoft.Extensions.DependencyInjection;
using SitecoreHeadless.Infrastructure.Interfaces.Repository;
using SitecoreHeadless.Infrastructure.Persistence.UnitOfWork;
using SitecoreHeadless.Infrastructure.Reposiotries.Configuration;
using SitecoreHeadless.Infrastructure.Interfaces.Dapper;
using SitecoreHeadless.Infrastructure.Persistence.DapperConfiguration;
using Microsoft.AspNetCore.Http;
using SitecoreHeadless.Infrastructure.Interfaces.Context;
using SitecoreHeadless.Infrastructure.Persistence.Context;
using Microsoft.Data.SqlClient;
using SitecoreHeadless.Data.Models;
using Microsoft.Extensions.Configuration;
using SitecoreHeadless.Helper.Services.API;

namespace SitecoreHeadless.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<Func<ApplicationDbContext>>((provider) => () => provider.GetService<ApplicationDbContext>());
            services.AddScoped<Func<SqlConnection>>((provider) => () => provider.GetService<SqlConnection>());
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<SqlConnection>();
            services.AddTransient<IApplicationSqlDbContext>(provider => provider.GetService<ApplicationDbContext>());
            services.AddScoped(typeof(IRepositoryQuery<>), typeof(RepositoryQuery<>));
            services.AddScoped(typeof(IRepositoryCommand<>), typeof(RepositoryCommand<>));
            services.AddScoped<DbFactory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IApplicationWriteDbConnection, ApplicationWriteDbConnection>();
            services.AddScoped<IApplicationReadDbConnection, ApplicationReadDbConnection>();
            services.AddTransient<HttpClient>();
            services.AddScoped<IAPIService, APIService>();
            services.Configure<SitecoreConfig>(configuration.GetSection("Sitecore"));
            services.AddScoped<IMySolrRepository, MySolrRepository>();
            return services;
        }
    }

}

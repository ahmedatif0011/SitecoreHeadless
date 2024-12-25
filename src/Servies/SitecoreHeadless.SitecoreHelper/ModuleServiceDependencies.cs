using Microsoft.Extensions.DependencyInjection;
using SitecoreHeadless.SitecoreHelper.Abstracts;
using SitecoreHeadless.SitecoreHelper.Implementations;

namespace SitecoreHeadless.SitecoreHelper
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddSitecoreHelperServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<ISitecoreItemService, SitecoreItemService>();
            return services;
        }
    }
}

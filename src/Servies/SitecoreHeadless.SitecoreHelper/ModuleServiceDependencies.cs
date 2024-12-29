using Microsoft.Extensions.DependencyInjection;
using SitecoreHeadless.SitecoreHelper.Abstracts;
using SitecoreHeadless.SitecoreHelper.Abstracts.ContactUsForm;
using SitecoreHeadless.SitecoreHelper.Implementations;
using SitecoreHeadless.SitecoreHelper.Implementations.ContactUsForm;

namespace SitecoreHeadless.SitecoreHelper
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddSitecoreHelperServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<ISitecoreItemService, SitecoreItemService>();
            services.AddScoped<IContactUsService, ContactUsService>();
            services.AddScoped< IEmailService ,EmailService>();

            return services;
        }
    }
}

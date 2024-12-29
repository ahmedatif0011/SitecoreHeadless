using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SitecoreHeadless.Core.Bahaviors;
using SitecoreHeadless.Helper.Services;
using System.Reflection;

namespace SitecoreHeadless.Data
{
    public static class ModuleCoreDependencies
    {
        public static IServiceCollection AddCoreDependencies(this IServiceCollection services)
        {

            // AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Mediator Config.
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            //validators 
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            return services;
        }
    }
}

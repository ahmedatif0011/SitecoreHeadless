using MediatR;
using SitecoreHeadless.Api.Settings;

namespace SitecoreHeadless.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            AppDI.Services(builder);
            #region Cors
            var Cors = "_CORS";
            builder.Services.AddCors(opt =>
            {
                opt.AddPolicy(name: Cors,
                    policy =>
                    {
                        policy.AllowAnyHeader();
                        policy.AllowAnyMethod();
                        policy.AllowAnyOrigin();
                    }
                );
            });
            #endregion
            builder.Services.AddDataProtection();
            var app = builder.Build();
            AppBuilder.Builder(app, Cors);
            app.Run();
        }
    }
}

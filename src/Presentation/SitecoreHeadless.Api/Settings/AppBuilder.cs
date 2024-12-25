using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
//using SitecoreHeadless.Core.Middleware;
using SitecoreHeadless.Infrastructure.Persistence.Context;

namespace SitecoreHeadless.Api.Settings
{
    public static class AppBuilder
    {
        public async static void Builder(WebApplication app,string Cors)
        {
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    context.Database.Migrate(); // Apply migrations at startup
                }
                catch (Exception ex)
                {
                    // Log any exceptions here if needed
                    Console.WriteLine($"An error occurred while migrating the database: {ex.Message}");
                }
            }
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI();

            #region Localization Middleware
            var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);
            #endregion

            app.UseHttpsRedirection();
            app.UseCors(Cors);
            //app.UseAuthentication();
            app.UseAuthorization();
            //app.UseMiddleware<ErrorHandlerMiddleware>();

            app.MapControllers();
        }
    }
}

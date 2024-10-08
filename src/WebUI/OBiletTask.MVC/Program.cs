using OBiletTask.Infrastructure;
using OBiletTask.Application;
using Microsoft.Build.Framework;
using Serilog;

namespace OBiletTask.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            
            #region ServiceRegistration
            builder.Services.AddInfrastructureServices();
            builder.Services.AddApplicationRegistration();

            #endregion
            #region Serilog
          
            Log.Logger = new LoggerConfiguration().MinimumLevel.Information()
                .WriteTo.File("Log/logFile.txt", rollingInterval: RollingInterval.Day).CreateLogger();
            builder.Services.AddLogging(loggingBuilder =>
        loggingBuilder.AddSerilog(dispose: true)
    );

            
            builder.Host.UseSerilog();
            #endregion


            builder.Services.AddSession(options =>
                {
                    options.IdleTimeout = TimeSpan.FromMinutes(30);
                    options.Cookie.HttpOnly = true;
                    options.Cookie.IsEssential = true;
                });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            //NotFoundPage configuration was actived
            app.UseStatusCodePagesWithReExecute("/Home/NotFoundPage", "?statuscode={0}");

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

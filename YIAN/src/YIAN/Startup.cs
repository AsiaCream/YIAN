using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Data.Entity;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;
using YIAN.Models;

namespace YIAN
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var appEnv = services.BuildServiceProvider().GetRequiredService<IApplicationEnvironment>();

            services.AddEntityFramework()
                .AddSqlite()
                .AddDbContext<YIANContext>(x => x.UseSqlite("Data source=" + appEnv.ApplicationBasePath + "/Database/yian.db"));

            //services.AddEntityFramework()
            //    .AddSqlServer()
            //    .AddDbContext<YIANContext>(x => x.UseSqlServer("server=localhost;uid=sa;password=123456;database=yian"));

            services.AddIdentity<User, IdentityRole<long>>(x =>
            {
                x.Password.RequireDigit = false;
                x.Password.RequiredLength = 0;
                x.Password.RequireLowercase = false;
                x.Password.RequireNonLetterOrDigit = false;
                x.Password.RequireUppercase = false;
                x.User.AllowedUserNameCharacters = null;
            })
            .AddEntityFrameworkStores<YIANContext, long>()
            .AddDefaultTokenProviders();

            services.AddMvc();
        }

        public async void Configure(IApplicationBuilder app,ILoggerFactory logger)
        {
            app.UseIISPlatformHandler();
            logger.AddConsole();
            logger.MinimumLevel = LogLevel.Warning;
            logger.MinimumLevel = LogLevel.Debug;
            app.UseStaticFiles();
            app.UseIdentity();
            app.UseMvc(x => x.MapRoute("default", "{controller=Home}/{action=Index}/{id?}"));

            await SampleData.InitDB(app.ApplicationServices);
            
        }

        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}

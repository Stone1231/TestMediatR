using System.Reflection;
using BusinessLogic;
using DataAssert;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TestMediatR
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseInMemoryDatabase("TestMediatR");
            });

            services.AddControllers();

            services.AddMvc()
            .AddNewtonsoftJson(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );


            services.AddMediatR(typeof(AddPersonCommand).GetTypeInfo().Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LogBehavior<,>));

            // services.AddTransient(typeof(IRequestPreProcessor<>), typeof(LogPreProcessor<>));
            // services.AddTransient(typeof(IRequestPostProcessor<,>), typeof(LogPostProcessor<,>));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            // app.UseMvc(routes =>
            // {
            //     routes.MapRoute(name: "default",
            //                     template: "{controller=Home}/{action=Index}/{id?}");
            // });
        }
    }
}
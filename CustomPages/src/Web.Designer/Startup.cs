using Autofac;
using Autofac.Extensions.DependencyInjection;
using CustomPage.Extensions.DependencyInjection;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Web.Designer
{
    public class Startup
    {
        private IServiceProvider _serviceProvider;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit http://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddCustomPageCore();

            var builder = new ContainerBuilder();
            builder.Populate(services);
            var container = builder.Build();

            _serviceProvider = container.Resolve<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseDeveloperExceptionPage();
            app.ApplicationServices = _serviceProvider;
            app.UseIISPlatformHandler();
            app.UseMvc(route =>
            {
                route.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Render", action = "Index", id = string.Empty });
            });
        }

        // Entry point for the application.
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
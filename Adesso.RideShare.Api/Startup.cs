using System.Reflection;
using Adesso.RideShare.Api.Application.Travel.Commands.TravelCreate;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Adesso.RideShare.Business.Factories;
using Adesso.RideShare.Business.Factories.Impl;
using Adesso.RideShare.Business.Services.Impl;
using Adesso.RideShare.Business.Services;

namespace Adesso.RideShare.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddMediatR(typeof(TravelCreateCommand).GetTypeInfo().Assembly);

            #region Swagger

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Adess RideShare API",
                    Description = "RideShare ASP.NET Core Web API"
                });
            });

            #endregion

            #region Factories

            services.AddScoped<ITravelServiceFactory, TravelServiceFactory>();

            #endregion

            #region Services

            services.AddScoped<ITravelService, TravelService>();

            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

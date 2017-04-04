using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using xpense.Repository;
using Microsoft.EntityFrameworkCore;
using xpense.Contract.Repository;
using xpense.DataModel.Mapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace xpense.Api
{
    public class Startup
    {
        public const string CORS_POLICY_NAME = "CorsPolicy";

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDependencies(services);

            ConfigureCors(services);

            // Add framework services.
            services.AddMvc(setupAction=> {
                setupAction.ReturnHttpNotAcceptable = true;
                setupAction.OutputFormatters.Add(new XmlDataContractSerializerOutputFormatter());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, XpenseDbContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async c =>
                    {
                        c.Response.StatusCode = 500;
                        await c.Response.WriteAsync("An unexpected fault has occured. Please try again later");
                    });
                });
            }

            app.UseMvcWithDefaultRoute();
        }

        private void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                    Startup.CORS_POLICY_NAME,
                    builder =>
                        builder.AllowAnyOrigin()
                                .SetPreflightMaxAge(TimeSpan.FromSeconds(2520))
                                .WithMethods(new string[] { "OPTIONS", "GET", "POST", "PUT", "DELETE","PATCH", "HEAD" })
                    );
            });
        }

        private void ConfigureDependencies(IServiceCollection services)
        {
            var config = new AutoMapper.MapperConfiguration(c =>
            {
                c.AddProfile(new XpenseProfileConfiguration());
            });
            var mapper = config.CreateMapper();

            services.AddSingleton(mapper);

            services.AddDbContext<XpenseDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("xpenseDatabase"))
            );

            services.AddScoped<IOrganisationRepository, OrganisationRepository>();
        }
    }
}

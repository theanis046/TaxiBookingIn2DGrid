using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.HttpOverrides;
using Swashbuckle.AspNetCore.Swagger;

namespace TaxiBookingSystem_nutonomy
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                 .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            DependencyMapper.SetDependencies(services, Configuration);
            services.AddMvcCore()
                .AddJsonFormatters()
                .AddApiExplorer()
                .AddCors(o => o.AddPolicy("CorsPolicy2", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials()));

            ConfigureSwagger(services);
            ConfigureAppSettings(services);
            var provider = services.BuildServiceProvider();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IOptions<AppSettings> appSettings)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseStaticFiles();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor |
                                  ForwardedHeaders.XForwardedProto
            });


            app.UseCors(option => option.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            app.UseCors("CorsPolicy2");


            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseMvc();
        }

        public void ConfigureSwagger(IServiceCollection services)
        {

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "Nutonomy Server",

                    Description = "Nutonomy Server Apis",
                    TermsOfService = "None",
                    Contact = new Contact { Name = "Anis ur Rehman", Email = "anis.rehman046@gmail.com", Url = "https://www.linkedin.com/in/anis46/" },
                    License = new License { Name = "No License", Url = "https://NoLicense.com/license" }
                });
            });
        }
        public void ConfigureAppSettings(IServiceCollection services)
        {
            services.AddOptions();

            // Add our Config object so it can be injected
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
        }
    }
}

using System;
using System.IO;
using DocumentService.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using RedisIO.Converter;
using RedisIO.ServicesExtensions;
using StackExchange.Redis;


namespace DocumentService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            configuration["FileDirectoryPath"] =
                Path.Combine(Directory.GetParent(Environment.CurrentDirectory).FullName, configuration["FileDirectoryPath"]);
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRedisIO<JsonRedisConverter>(builder =>
                builder
                    .UseJsonConverter()
                    .UseConfiguration(new ConfigurationOptions()
                    {
                        EndPoints = { "localhost:6379" }
                    }));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DocumentService", Version = "v1" });
            });
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ITemplateService, TemplateService>();
            services.AddTransient<IDocumentService, Services.DocumentService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DocumentService v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

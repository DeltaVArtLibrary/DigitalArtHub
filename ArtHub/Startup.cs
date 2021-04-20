using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.Configuration;
using ArtHub.Data;
using Microsoft.EntityFrameworkCore;
using ArtHub.Models.Identity;
using Microsoft.AspNetCore.Identity;
using ArtHub.Services;
using ArtHub.Data.Interfaces;

namespace ArtHub
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ArtHubDbContext>(options =>
           {
               string connectionString = Configuration.GetConnectionString("DefaultConnection");
               options.UseSqlServer(connectionString);
           });

            services.AddControllers();


            // Add in the requires a unique email for signup
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;

            })
            .AddEntityFrameworkStores<ArtHubDbContext>();

            // services.AddTransient go below
            services.AddTransient<IUserService, IdentityUserService>();
            services.AddTransient<IArtRepository, DbArtRepository>();



            services.AddSwaggerGen(options =>
            {
                // Make sure get the "using Statement"
                options.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Digital ArtHub",
                    Version = "v1",
                });
            });

           



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
            public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseSwagger(options => {
                options.RouteTemplate = "/api/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/v1/swagger.json", "Digital ArtHub");
                options.RoutePrefix = "";
            });





            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGet("/", async context =>
                {
                    
                    context.Response.Redirect("/docs");
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}

using Infra.Data.Context;
using Infra.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NameProject.Domain.Interfaces;
using NameProject.Domain.Services;

namespace NameProject.API
{
    public class Startup
    {
        const string CORS_POLICY_NAME = "CorsPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            var connection = Configuration["SqliteConnection:SqliteConnectionString"];
            services.AddDbContext<NameProjectContext>(options =>
                options.UseSqlite(connection)
            );

            services.AddCors(options =>
            {
                options.AddPolicy(CORS_POLICY_NAME, builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<INameConstructorService, NameContructorService>();

            services.AddControllers();
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
            app.UseCors(CORS_POLICY_NAME);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

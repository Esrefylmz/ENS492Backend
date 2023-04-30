using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore.Extensions;
using MySqlConnector;
using Microsoft.Extensions.Hosting;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace MyBackend
{

    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddEntityFrameworkMySQL().AddDbContext<AirQuality.Entities.Ens4912AirqualityContext>(options =>
            {
                options.UseMySQL(connectionString);
            });

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:7264", "http://localhost:5063", "http://localhost:8080")
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                    });
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }

    internal class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseUrls("http://10.51.20.243:5063");
                    webBuilder.UseStartup<Startup>();
                });
    }
}

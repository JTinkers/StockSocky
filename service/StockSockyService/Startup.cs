using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StockSockyService.Data.Contexts;
using StockSockyService.Services;

namespace StockSockyService
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
            services.AddCors(x => x.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin()));
            
            services.AddSingleton<MainContext>();

            services.AddHostedService<FinnhubService>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("AllowOrigin");
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShookREST.Util;
using ShookREST.Util.Authorization;

namespace ShookREST
{
    public class Startup
    {
        APIKeyGenerator _aPIKeyGenerator;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            // Start the APIKeyGenerator.
            _aPIKeyGenerator = new APIKeyGenerator();

            ReadAppsettings();
        }

        // Reads the appsettings.json and saves important strings to StaticStrings class.
        private void ReadAppsettings()
        {
            StaticStrings.DB_CONNECTION_STRING = Configuration.GetConnectionString("MongoDB");
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ShookREST.Utils;
using ShookREST.Utils.Authorization;

namespace ShookREST
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            // Start the APIKeyGenerator.
            new ApiKeyGenerator();

            ReadAppsettings();
        }

        /// <summary>
        /// Reads the appsettings.json and saves important strings to <see cref="StaticStrings"/> class.
        /// </summary>
        private void ReadAppsettings()
        {
            StaticStrings.DbConnectionString = Configuration.GetConnectionString("MongoDB");
        }

        #region Asp.NET stuff

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

        #endregion
    }
}

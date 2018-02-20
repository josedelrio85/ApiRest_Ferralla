using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ApiRest_Ferralla.Models;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest_Ferralla
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
            services.AddCors();
            services.AddMvc();
            
            var connection = @"Server=XONE_DESARROLLO\SQLEXPRESS;Database=Ferralla;User Id=sa;Password=Root1;";
            services.AddDbContext<FerrallaContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //https://dotnetcoretutorials.com/2017/01/03/enabling-cors-asp-net-core/
            app.UseCors(
                options => options.WithOrigins("http://localhost:4200").AllowAnyMethod()
                //options => options.AllowAnyOrigin()
            );

            app.UseMvc();
        }
    }
}

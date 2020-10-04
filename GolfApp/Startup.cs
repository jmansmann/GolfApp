using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using GolfApp.Data;
using Microsoft.EntityFrameworkCore;

namespace GolfApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Environment = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (Environment.IsDevelopment())
            {
                services.AddDbContext<CourseContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("CourseContext")));

                // services.AddDbContext<GolfAppHoleContext>(options =>
                //     options.UseSqlite(Configuration.GetConnectionString("HoleContext")));

                // services.AddDbContext<GolfAppLocationContext>(options =>
                //     options.UseSqlite(Configuration.GetConnectionString("LocationContext")));

                // services.AddDbContext<GolfAppGolferContext>(options =>
                //     options.UseSqlite(Configuration.GetConnectionString("GolferContext")));

            }
            else
            {
                services.AddDbContext<CourseContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("CourseContext")));

                // services.AddDbContext<GolfAppHoleContext>(options =>
                //     options.UseSqlServer(Configuration.GetConnectionString("HoleContext")));

                // services.AddDbContext<GolfAppLocationContext>(options =>
                //     options.UseSqlServer(Configuration.GetConnectionString("LocationContext")));

                // services.AddDbContext<GolfAppGolferContext>(options =>
                //     options.UseSqlServer(Configuration.GetConnectionString("GolferContext")));

            }
            services.AddRazorPages();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}

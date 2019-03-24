using CronJob.Jobs;
using CronQuery.Mvc.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using Serilog.Exceptions;
using Serilog.Sinks.Elasticsearch;
using Microsoft.Extensions.Logging;
using CronJob.Data;
using Microsoft.EntityFrameworkCore;
using CronJob.Common.UnitofWork;

namespace CronJob
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            var elasticUri = Configuration["ElasticConfiguration:Uri"];
            Log.Logger = new LoggerConfiguration()
               .Enrich.FromLogContext()
               .Enrich.WithExceptionDetails()
               .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticUri))
               {
                   AutoRegisterTemplate = true,
               })
               .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            #region ApplicationDbContextSection

            services.AddDbContext<CronJob.Data.CronDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<DbContext, CronJob.Data.CronDbContext>();

            #endregion ApplicationDbContextSection
            services.AddScoped<IUnitofWork, UnitofWork>();
            //#region AutoMapperSection

            ////Auto mapper'ı ekliyoruz
            //services.AddAutoMapper();

            //#endregion AutoMapperSection
            #region CorsSection

            //Cors ayarları
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            #endregion CorsSection
            //services.AddDbContext<CronDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddCronQuery(Configuration.GetSection("CronQuery"));
            services.AddTransient<Thirdjob>();
            services.AddTransient<FirstJob>();
            services.AddTransient<SecondJob>();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,IApplicationLifetime applicationLifetime,ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            #region CorsSection

            app.UseCors("CorsPolicy");

            #endregion CorsSection
            loggerFactory.AddSerilog();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Default}/{action=Index}/{id?}");
            });
            app.UseCronQuery()
                .Enqueue<Thirdjob>()
                .Enqueue<FirstJob>()
                .Enqueue<SecondJob>()
                .StartWith(applicationLifetime);

        }
    }
}

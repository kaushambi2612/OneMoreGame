using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OneMoreGame.Models;
using Steeltoe.CloudFoundry.Connector.PostgreSql;

namespace OneMoreGame
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //adding dbcontext to the project
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));


            //string connectionString = GetConnectionStringFromURI();
            ////services.AddDbContext<ApplicationDbContext>(options => 
            ////                    options.UseNpgsql(Configuration));

            //services.AddDbContext<ApplicationDbContext>(options =>
            //                    options.UseSqlServer(connectionString));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            
        }

        //public string GetConnectionStringFromURI()
        //{
        //    var uriString = Configuration.GetConnectionString("OMGElephantSQL");
        //    var uri = new Uri(uriString);
        //    var db = uri.AbsolutePath.Trim('/');
        //    var user = uri.UserInfo.Split(':')[0];
        //    var passwd = uri.UserInfo.Split(':')[1];
        //    var port = uri.Port > 0 ? uri.Port : 5432;
        //    var connStr = string.Format("Server={0};Database={1};User Id={2};Password={3};",
        //        uri.Host, db, user, passwd);
        //    return connStr;
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            //middleware stated here
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
}

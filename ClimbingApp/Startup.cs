using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ClimbingApp.MiscUtilities;
using Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.AzureADB2C.UI;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using WebApi.Services;

namespace ClimbingApp
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

            services.AddDistributedMemoryCache();

            // Enable authentication
            services.AddAuthentication(AzureADB2CDefaults.AuthenticationScheme)
                .AddAzureADB2C(options =>
                {
                    this.Configuration.Bind("AzureAdB2C", options);

                });

            services.AddSession(options =>
            {
                // Make the session cookie essential.
                options.Cookie.IsEssential = true;


            });

            services.Configure<OpenIdConnectOptions>(AzureADB2CDefaults.OpenIdScheme, options =>
            {

                options.SaveTokens = true;
                options.Events = new OpenIdConnectEvents()
                {

                    OnTokenValidated = async ctx =>
                    {

                        //Get user's immutable object id from claims that came from Azure AD
                        string oid = ctx.Principal.FindFirstValue("http://schemas.microsoft.com/identity/claims/objectidentifier");
                        var userService = ctx.HttpContext.RequestServices.GetRequiredService<IUserService>();
                        userService.Authenticate(oid);
                    },
                    OnRedirectToIdentityProviderForSignOut = async ctx =>
                    {
                        var userService = ctx.HttpContext.RequestServices.GetRequiredService<IUserService>();
                        userService.Logout();
                    }

                };

            });



            services.AddDbContext<ClimbAppContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("ClimbAppContext"));

                // Enable lazy loading.
                options.UseLazyLoadingProxies();
            });

            
            services.AddRazorPages();

            services.AddControllersWithViews();
            services.AddHttpContextAccessor();
            services.AddScoped<IUserService, UserService>();

        }





        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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

            app.UseRouting();

            app.UseSession();

            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}

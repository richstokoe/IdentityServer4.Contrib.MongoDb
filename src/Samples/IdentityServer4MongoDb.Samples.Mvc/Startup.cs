﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using IdentityServer4.Contrib.MongoDb;

namespace IdentityServer4MongoDb.Samples.Mvc
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            IdentityConfig
                .Setup(Configuration, services)     // This returns the IdentityServerBuilder
                .AddTemporarySigningCredential();   // This is an IdentityServer4 builder extension method

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                loggerFactory.AddConsole(Configuration.GetSection("Logging"));
                loggerFactory.AddDebug();

                app.UseDeveloperExceptionPage();
                // app.UseBrowserLink();
            }
            else
            {
                // TODO: Add your production logging here

                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            ConfigureAuth(app);

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void ConfigureAuth(IApplicationBuilder app)
        {
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            
            app.Map("/identity", (identity) =>
            {
                identity.UseIdentityServer();
            });

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationScheme = "cookies",
                AutomaticAuthenticate = true
            });

            var oidcOptions = new OpenIdConnectOptions
            {
                // Don't do this in production!
                RequireHttpsMetadata = false,

                AuthenticationScheme = "oidc",
                SignInScheme = "cookies",

                Authority = "http://localhost:5000/identity",
                ClientId = "mvc",
                ClientSecret = "secret",
                ResponseType = "code id_token",
                SaveTokens = true,
                GetClaimsFromUserInfoEndpoint = true,

                TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = "name",
                    RoleClaimType = "role"
                }
            };

            oidcOptions.Scope.Clear();
            oidcOptions.Scope.Add("openid");
            oidcOptions.Scope.Add("profile");
            oidcOptions.Scope.Add("api1");

            app.UseOpenIdConnectAuthentication(oidcOptions);
        }
    }
}

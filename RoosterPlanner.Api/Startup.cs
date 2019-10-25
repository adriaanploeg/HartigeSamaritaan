﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using RoosterPlanner.Common.Config;
using RoosterPlanner.Service;

namespace RoosterPlanner.Api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwtOptions =>
            {
                jwtOptions.Authority = $"https://login.microsoftonline.com/tfp/{Configuration["AzureAuthentication:TenantId"]}/{Configuration["AzureMicrosoftGraph:SignUpSignInPolicyId"]}/v2.0/";
                jwtOptions.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidAudiences = new List<string> {
                        Configuration["TokenValidation:ClientIdWeb"]
                    }
                };
                jwtOptions.Audience = Configuration["TokenValidation:ClientIdWeb"];
                jwtOptions.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = AuthenticationFailedAsync
                };
            });

            services.AddAuthorization();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(options => {
                options.SerializerSettings.NullValueHandling = NullValueHandling.Include;
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                options.SerializerSettings.DateParseHandling = DateParseHandling.DateTime;
                options.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
            });

            services.Configure<AzureAuthenticationConfig>(Configuration.GetSection(AzureAuthenticationConfig.ConfigSectionName));

            services.AddTransient<IAzureB2CService, AzureB2CService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private Task AuthenticationFailedAsync(AuthenticationFailedContext arg)
        {
            // For debugging purposes only!
            var s = $"AuthenticationFailed: {arg.Exception.Message}";
            arg.Response.ContentLength = s.Length;
            arg.Response.Body.Write(System.Text.Encoding.UTF8.GetBytes(s), 0, s.Length);

            return Task.FromResult(0);
        }
    }
}
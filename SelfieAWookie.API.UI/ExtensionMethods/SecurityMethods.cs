using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SelfieAWookie.Core.Infrastructure.Configurations;

namespace SelfieAWookie.API.UI.ExtensionMethods
{
    public static class SecurityMethods
    {
        public const string DEFAULT_POLICY = "DEFAULT_POLICY";

        public static void AddCustomSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            AddCustomCors(services, configuration);
            AddCustomAuthentication(services, configuration);
        }

        public static void AddCustomAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                SecurityOption security = new SecurityOption();
                configuration.GetSection("Jwt").Bind(security);
                string? myKey = security.Key;


                options.SaveToken = true;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(myKey!)),
                    ValidateActor = false,
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateLifetime = true
                };

            });
        }

        public static void AddCustomCors(this IServiceCollection services, IConfiguration configuration)
        {
            CorsOption corsOption = new CorsOption();
            configuration.GetSection("Cors").Bind(corsOption); //configuration.GetSection("Cors:Origin").Value;
            var originCors = corsOption.Origin;
            services.AddCors(options =>
            {
                options.AddPolicy(DEFAULT_POLICY, builder =>
                {
                    builder.WithOrigins(originCors!)
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });

            });
        }
    }
}


using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

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
                string? myKey = configuration.GetSection("Jwt:Key").Value;
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
            var cors = configuration.GetSection("Cors:Origin").Value;
            services.AddCors(options =>
            {
                options.AddPolicy(DEFAULT_POLICY, builder =>
                {
                    builder.WithOrigins(cors!)
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });

            });
        }
    }
}


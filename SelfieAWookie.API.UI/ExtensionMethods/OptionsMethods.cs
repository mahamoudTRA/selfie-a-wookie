using System;
using SelfieAWookie.Core.Infrastructure.Configurations;

namespace SelfieAWookie.API.UI.ExtensionMethods
{
    public static class OptionsMethods
    {
       public static void AddCustomOptions(this IServiceCollection services, IConfiguration configuration)
       {
            services.Configure<SecurityOption>(configuration.GetSection("Jwt"));
       }
    }
}


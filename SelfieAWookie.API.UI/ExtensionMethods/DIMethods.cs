using System;
using SelfieAWookie.Core.Domain.Repositories;
using SelfieAWookie.Core.Infrastructure.Repositories;

namespace SelfieAWookie.API.UI.ExtensionMethods
{
    public static class DIMethods
    {
        public static void AddInjection(this IServiceCollection services)
        {
            services.AddScoped<ISelfieRepository, SelfieRepository>();
        }
    }
}


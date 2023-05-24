using System;
using SelfieAWookie.Core.Domain.Repositories;
using SelfieAWookie.Core.Infrastructure.Repositories;
using MediatR;

namespace SelfieAWookie.API.UI.ExtensionMethods
{
    public static class DIMethods
    {
        public static IServiceCollection AddInjection(this IServiceCollection services)
        {
            services.AddScoped<ISelfieRepository, SelfieRepository>();
            

            return services;
        }
    }
}


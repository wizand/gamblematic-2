using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GambleMaticCommLib
{
    public static class CommunicationLibrarySetup
    {

        public static IServiceCollection AddGambleMaticCommunicationLibrary(this IServiceCollection services)
        {
            services.TryAddSingleton<JwtHelper>();
            services.TryAddScoped<ApiCommunicatorService>();
            return services;
        }

    }
}

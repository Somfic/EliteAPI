using System;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
namespace EliteAPI.Spansh
{
    public static class SpanshExtensions
    {
        /// <summary>
        /// Adds all Spansh's necessary services to the <seealso cref="IServiceCollection" />
        /// </summary>
        public static IServiceCollection AddSpansh(this IServiceCollection services)
        {
            services.AddTransient<IHttpClientFactory>();
            
            return services;
        }
    }
}
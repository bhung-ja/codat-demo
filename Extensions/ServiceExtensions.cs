using Codat.Public.Client;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CodatDemo.Extensions
{
    public static class ServiceExtensions
    {
        private static IHttpClientFactory _httpClientFactory;
        public static void AddCodatServices(this IServiceCollection services, IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            services.AddSingleton<CodatClient>(c => new CodatClient("SV5XlNbCQODqdmOvd9ycen1uB0zSOR6Y8lQlQBYg", _httpClientFactory.CreateClient()));
        }
    }
}

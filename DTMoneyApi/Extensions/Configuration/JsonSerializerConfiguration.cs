using Microsoft.AspNetCore.Http.Json;
using System.Text.Json.Serialization;

namespace DTMoney.Api.Extensions.Configuration
{
    public static class JsonSerializerConfiguration
    {
        public static IServiceCollection AddJsonSerializerConfiguration(this IServiceCollection services)
        {
            services.Configure<JsonOptions>(options =>
            {
                options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

            return services;
        }
    }
}

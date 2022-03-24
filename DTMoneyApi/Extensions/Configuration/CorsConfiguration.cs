namespace DTMoney.Api.Extensions.Configuration
{
    public static class CorsConfiguration
    {
        private static readonly string commonLocalHostOrigin = "commonLocalHostOrigin";
        public static IServiceCollection AddCorsConfiguration(this IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddPolicy(name: commonLocalHostOrigin,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:3000",
                                                          "http://127.0.0.1:3000");
                                  });
            });

            return services;
        }
        public static WebApplication UseCorsConfiguration(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseCors(commonLocalHostOrigin);
            }

            return app;
        }
    }
}

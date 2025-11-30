namespace leiloFlash_backend.Config
{
    public static class CorsConfiguration
    {
        public const string CorsPolicyName = "AllowAllOrigins";

        public static IServiceCollection AddAppCors(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddCors(options =>
            {
                options.AddPolicy(name: CorsPolicyName, policy =>
                {
                    policy.WithOrigins("http://localhost:4200")
                    .WithMethods("GET", "POST", "DELETE", "PATCH", "PUT", "OPTIONS")
                    .AllowAnyHeader()
                    .AllowCredentials();
                });
            });

            return service;
        }

        public static IApplicationBuilder UseAppCors(this IApplicationBuilder app)
        {
            app.UseCors(CorsPolicyName);
            return app;
        }
    }


}

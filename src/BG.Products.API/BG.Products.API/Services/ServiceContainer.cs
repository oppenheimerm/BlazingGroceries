using BG.Products.API.Data;
using BG.Products.API.Interfaces;
using BG.Products.API.Repositories;
using BG.Shared.DI;

namespace BG.Products.API.Services
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration config)
        {
            //  DB connectivity
            //  Auth scheme
            SharedServiceContainer.AddSharedServices<ProductDataContext>(services, config, config["MySerilog:FileName"]!);

            // DI
            services.AddScoped<IProduct, ProductRepository>();

            return services;
        }

        public static IApplicationBuilder UseInfrastructurePolicy(this IApplicationBuilder app)
        {
            // Registe middleware
            //  Global Exception: hadles errors
            //  Restrict client access to  API Gateway
            SharedServiceContainer.UseSharedPolicies(app);

            return app;
        }
    }
}

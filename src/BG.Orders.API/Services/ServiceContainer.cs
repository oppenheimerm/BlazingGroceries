using BG.Orders.API.Data;
using BG.Orders.API.Interfaces;
using BG.Orders.API.Repositories;
using BG.Shared;
using BG.Shared.APIServiceLogs;
using BG.Shared.DI;
using Microsoft.EntityFrameworkCore;
using Polly;
using Polly.Retry;
using System;

namespace BG.Orders.API.Services
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration config)
        {

            //  Database Connectivity
            var connectionString = config.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            services.AddDbContext<OrderDataContext>(options =>
                options.UseSqlServer(connectionString));


            SharedServiceContainer.AddSharedServices<OrderDataContext>(services, config, config["MySerilog:FileName"]!);

            //  Inject HttpClient
            //  Use IHttpClientFactory to implement resilient HTTP requests
            //  See: https://learn.microsoft.com/en-us/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests
            services.AddHttpClient<IOrderService, OrderService>( options =>
            {
                options.BaseAddress = new Uri(config["APIGateway:BaseAddress"]!);
                options.Timeout = TimeSpan.FromSeconds(1);
            });

            // Retry strategy
            //  https://www.pollydocs.org/index.html
            var retriesStregty = new RetryStrategyOptions()
            {
                ShouldHandle = new PredicateBuilder().Handle<TaskCanceledException>(),
                BackoffType = DelayBackoffType.Constant,
                UseJitter = true,
                MaxRetryAttempts = 3,
                Delay = TimeSpan.FromMilliseconds(500),
                //  We don't wish to log to file; call LogToConsole / LogToDebugger
                OnRetry = args =>
                {
                    //  
                    string msg = $"OnRetry, Attempt: {args.AttemptNumber} Outcome: {args.Outcome}";
                    LogException.LogToConsole(msg);
                    LogException.LogToDebugger(msg);
                    return ValueTask.CompletedTask;
                }
            };

            //  Use retry stragety
            services.AddResiliencePipeline(AppConstants.RESILIENCE_PIPELINE, builder => {
                builder.AddRetry(retriesStregty);
            });

            services.AddScoped<IOrder, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();


            return services;
        }

        public static IApplicationBuilder UseInfrastructurePolicy(this IApplicationBuilder app)
        {
            //  Register midddleware
            //  Global Exceptions => handle external errors
            //  Restrict client access to  API Gateway
            SharedServiceContainer.UseSharedPolicies(app);

            return app;
        }
    }
}

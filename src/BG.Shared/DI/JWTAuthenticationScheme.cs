
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BG.Shared.DI
{
    public static class JWTAuthenticationScheme
    {
        public static IServiceCollection AddJWTAuthenticationScheme(
            this IServiceCollection services,
            IConfiguration configuration
            )
        {
            //  Add Jwt Service
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer("Bearer", options =>
                {
                    var key = Encoding.UTF8.GetBytes(configuration["Authentication:Key"]!);
                    string issuer = configuration["Authentication:Issuer"]!;
                    string audiance = configuration["Authentication:Audiance"]!;

#if DEBUG
                    //  Disbled only id dev environment
                    options.RequireHttpsMetadata = false;
#endif
                    options.RequireHttpsMetadata = true;

                    //  Store bearer token on successful authorization
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = false,/* Change for rfresh tokens */
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = issuer,
                        ValidAudience = audiance,
                        IssuerSigningKey = new SymmetricSecurityKey(key)
                    };

                });

            return services;
        }
    }
}

using System.Text;
using FitnessApp.Domain.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

public static class AuthenticationExtension
{
    public static void AddCustomAuthentication(this IServiceCollection services, JwtOptions jwtOptions)
    {
        services.Configure<JwtOptions>(options =>
        {
            options.SecretKey = jwtOptions.SecretKey;
            options.ExpiresHours = jwtOptions.ExpiresHours;
        });

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.SecretKey))
                };
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        context.Token = context.Request.Cookies["Jwt token(absolutely secret)"];
                        return Task.CompletedTask;
                    }
                };
            });
        services.AddAuthorization(options =>
        {
            options.AddPolicy("UserPolicy", policy =>
            {
                policy.RequireAuthenticatedUser();
            });
            options.AddPolicy("AdminPolicy", policy =>
            {
                policy.RequireClaim("role", "Admin");
            });
        });
    }
}
namespace FitnessApp.Api.Extensions;

public class AuthorizationExtension
{
    public static void AddCustomAuthorization(IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy("AdminPolicy", policy => { policy.RequireClaim("Admin", "true"); });
        });
    }
}
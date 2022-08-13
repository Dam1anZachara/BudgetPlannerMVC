using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BudgetPlannerMVC.Web.StartupConfig
{
    public static class ExternalServices
    {
        public static IServiceCollection AddExternalServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication().AddGoogle(options =>
            {
                IConfiguration googleAuthNSection = configuration.GetSection("Authentication:Google");
                options.ClientId = googleAuthNSection["ClientId"];
                options.ClientSecret = googleAuthNSection["ClientSecret"];
            });
            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = configuration["Authentication:Facebook:AppId"];
                facebookOptions.AppSecret = configuration["Authentication:Facebook:AppSecret"];
            });
            return services;
        }
    }
}

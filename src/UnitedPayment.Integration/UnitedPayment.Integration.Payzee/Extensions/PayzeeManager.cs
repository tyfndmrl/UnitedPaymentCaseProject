using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UnitedPayment.Integration.Payzee.Models.Configurations;
using UnitedPayment.Integration.Payzee.Providers;
using UnitedPayment.Integration.Payzee.Providers.Interfaces;

namespace UnitedPayment.Integration.Payzee.Extensions
{
    public static class PayzeeManager
    {
        public static void PayzeeInit(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPayzeeProvider, PayzeeProvider>();
            services.Configure<PayzeeConfiguration>(configuration.GetSection("PayzeeConfiguration"));
        }
    }
}

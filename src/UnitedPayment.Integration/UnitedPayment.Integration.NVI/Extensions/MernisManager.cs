using MernisServiceReference;
using Microsoft.Extensions.DependencyInjection;
using UnitedPayment.Integration.NVI.Services.Interfaces;
using UnitedPayment.Integration.NVI.Services;

namespace UnitedPayment.Integration.NVI.Extensions
{
    public static class MernisManager
    {
        public static void MernisInit(this IServiceCollection services)
        {
            services.AddScoped<KPSPublicSoap, KPSPublicSoapClient>();
            services.AddScoped<IMernisService, MernisService>();
        }
    }
}

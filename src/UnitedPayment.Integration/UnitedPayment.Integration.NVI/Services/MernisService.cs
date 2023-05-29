using MernisServiceReference;
using UnitedPayment.Integration.NVI.Services.Interfaces;

namespace UnitedPayment.Integration.NVI.Services
{
    public class MernisService : IMernisService
    {
        private readonly KPSPublicSoap _client;
        public MernisService(KPSPublicSoap client)
        {
            _client = client;
        }

        public async Task<bool> ValidateTCIdentityAsync(long TCKimlikNo, string ad, string soyad, int dogumYili)
        {
            var request = new TCKimlikNoDogrulaRequestBody
            {
                TCKimlikNo = TCKimlikNo,
                Ad = ad,
                Soyad = soyad,
                DogumYili = dogumYili
            };
            var response = await _client.TCKimlikNoDogrulaAsync(new TCKimlikNoDogrulaRequest(request));
            return response.Body.TCKimlikNoDogrulaResult;
        }
    }
}

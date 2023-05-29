namespace UnitedPayment.Integration.NVI.Services.Interfaces
{
    public interface IMernisService
    {
        Task<bool> ValidateTCIdentityAsync(long TCKimlikNo, string ad, string soyad, int dogumYili);
    }
}

namespace UnitedPayment.Integration.Payzee.Models.RequestModels
{
    public class NoneSecurePaymentRequestModel
    {
        public int MemberId { get; set; }
        public int MerchantId { get; set; }
        public string CustomerId { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryDateMonth { get; set; }
        public string ExpiryDateYear { get; set; }
        public string Cvv { get; set; }
        public int SecureDataId { get; set; }
        public string CardAlias { get; set; }
        public string UserCode { get; set; }
        public string TxnType { get; set; }
        public string InstallmentCount { get; set; }
        public string currency { get; set; }
        public string OrderId { get; set; }
        public string TotalAmount { get; set; }
        public string PointAmount { get; set; }
        public string Rnd { get; set; }
        public string Hash { get; set; }
        public string Description { get; set; }
        public string CardHolderName { get; set; }
        public string RequestIp { get; set; }
        public AddressInfo BillingInfo { get; set; }
        public AddressInfo DeliveryInfo { get; set; }
        public List<Orderproductlist> OrderProductList { get; set; }

        public class AddressInfo
        {
            public string TaxNo { get; set; }
            public string TaxOffice { get; set; }
            public string FirmName { get; set; }
            public string IdentityNumber { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string Phone { get; set; }
            public string Address { get; set; }
            public string City { get; set; }
            public string Town { get; set; }
            public string ZipCode { get; set; }
        }

        public class Orderproductlist
        {
            public int MerchantId { get; set; }
            public string ProductId { get; set; }
            public string Amount { get; set; }
            public string ProductName { get; set; }
            public string CommissionRate { get; set; }
        }

    }
}

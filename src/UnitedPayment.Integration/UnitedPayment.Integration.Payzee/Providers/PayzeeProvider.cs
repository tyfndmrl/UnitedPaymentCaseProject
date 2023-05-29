using Microsoft.Extensions.Options;
using RestSharp;
using System.Net;
using UnitedPayment.Integration.Payzee.Models.Configurations;
using UnitedPayment.Integration.Payzee.Models.RequestModels;
using UnitedPayment.Integration.Payzee.Models.ResponseModels;
using UnitedPayment.Integration.Payzee.Providers.Interfaces;

namespace UnitedPayment.Integration.Payzee.Providers
{
    public class PayzeeProvider : IPayzeeProvider
    {
        private readonly PayzeeConfiguration _payzeeConfiguration;
        private RestClient _client;
        private readonly Dictionary<string, string> _headers;

        public PayzeeProvider(IOptions<PayzeeConfiguration> payzeeConfiguration)
        {
            _payzeeConfiguration = payzeeConfiguration.Value;
            _headers = new Dictionary<string, string>
            {
                { "Content-type", "application/json" }
            };
        }

        public async Task<LoginResponseModel> Authentication()
        {
            var loginRequestModel = new LoginRequestModel
            {
                Email = _payzeeConfiguration.Email,
                Lang = _payzeeConfiguration.Lang,
                ApiKey = _payzeeConfiguration.ApiKey
            };
            var restRequest = PrepareRestRequest(_payzeeConfiguration.AuthenticationBaseUrl, _payzeeConfiguration.AuthenticationUrl, Method.Post, loginRequestModel);

            var result = await _client.ExecuteAsync<LoginResponseModel>(restRequest);
            if (result.StatusCode == System.Net.HttpStatusCode.OK
                && result?.Data?.StatusCode == System.Net.HttpStatusCode.OK)
            {
                _headers.TryAdd("Authorization", $"bearer {result.Data.Result.Token}");
            }

            return result.Data;
        }

        public async Task<NoneSecurePaymentResponseModel> NoneSecurePayment(NoneSecurePaymentRequestModel model)
        {
            if (_headers["Authorization"] == null)
                await Authentication();

            var restRequest = PrepareRestRequest(_payzeeConfiguration.NoneSecurePaymentBaseUrl, _payzeeConfiguration.NoneSecurePaymentUrl, Method.Post, model);
            var result = await _client.ExecuteAsync<NoneSecurePaymentResponseModel>(restRequest);

            return result.Data;
        }

        private RestRequest PrepareRestRequest<TRequest>(string baseUrl, string resource, Method method, TRequest? requestModel)
        {
            _client = new RestClient(baseUrl);
            var restRequest = new RestRequest(resource, method);
            restRequest.AddHeaders(_headers);
            if (requestModel != null)
                restRequest.AddBody(requestModel);

            return restRequest;
        }
    }
}

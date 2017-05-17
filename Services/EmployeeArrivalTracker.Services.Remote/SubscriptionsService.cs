namespace EmployeeArrivalTracker.Services.Remote
{
    using Models;
    using Newtonsoft.Json;
    using RestSharp;
    using System;
    using System.Net;
    using System.Threading.Tasks;

    public class SubscriptionsService
    {
        public async Task<TokenDTO> Subscribe(DateTime date, string callbackUrl)
        {
            var client = new RestClient("http://localhost:51396/api");
            IRestRequest request = new RestRequest("clients/subscribe", Method.GET);
            request.Parameters.Add(new Parameter { Name = "Accept-Client", Value = "Fourth-Monitor", Type = ParameterType.HttpHeader });
            request.Parameters.Add(new Parameter { Name = "date", Value = date.ToString("yyyy-MM-dd"), Type = ParameterType.QueryString });
            request.Parameters.Add(new Parameter { Name = "callback", Value = callbackUrl, Type = ParameterType.QueryString });

            var response = await client.ExecuteTaskAsync(request).ConfigureAwait(false);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var token = JsonConvert.DeserializeObject<TokenDTO>(response.Content);
                return token;
            }

            return null;
        }
    }
}

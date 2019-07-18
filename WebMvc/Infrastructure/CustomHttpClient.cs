using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebMvc.Infrastructure
{
    public class CustomHttpClient : IHttpClient
    {
        // create a private variable of HttpClient
        private HttpClient _client;

        // constructor for CustomHttpClient to create instance of httpclient
        public CustomHttpClient()
        {
            _client = new HttpClient();
        }
        public Task<HttpResponseMessage> DeleteAsync(string uri, string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetStringAsync(string uri, string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            var requestMsg = new HttpRequestMessage(HttpMethod.Get, uri);

            // check if authorizationToken has been passed in
            if(authorizationToken !=null)
            {
                requestMsg.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue(authorizationMethod, authorizationToken);
            }
            
            var response = await _client.SendAsync(requestMsg);
            // read json returned as string
            return await response.Content.ReadAsStringAsync();            
        }

        public Task<HttpResponseMessage> PostAsync<Type>(string uri, Type item, string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponseMessage> PutAsync<Type>(string uri, Type item, string authorizationToken = null, string authorizationMethod = "Bearer")
        {
            throw new NotImplementedException();
        }
    }
}

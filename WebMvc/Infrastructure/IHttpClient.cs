using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebMvc.Infrastructure
{
    public interface IHttpClient
    {
        // get call will return json format which contain strings
        Task<string> GetStringAsync(string uri, string authorizationToken = null, string authorizationMethod = "Bearer");

        // method to create items
        Task<HttpResponseMessage> PostAsync<Type>(string uri, Type item, string authorizationToken = null, string authorizationMethod = "Bearer");

        // method to edit items
        Task<HttpResponseMessage> PutAsync<Type>(string uri, Type item, string authorizationToken = null, string authorizationMethod = "Bearer");

        Task<HttpResponseMessage> DeleteAsync(string uri, string authorizationToken = null, string authorizationMethod = "Bearer");
    }
}

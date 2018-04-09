using Pyle.Core.Models;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pyle.Core.Extensions
{
    /// <summary>
    /// Extensions to integrate RequestBuilder with HTTP requests.
    /// </summary>
    public static class HttpClientExtensions
    {
        /// <summary>
        /// Perform a GET request.
        /// </summary>
        /// <param name="client">The HttpClient to use for the request.</param>
        /// <param name="requestBuilder">The RequestBuilder from which to generate the request.</param>
        /// <returns>The request.</returns>
        public static Task<HttpResponseMessage> GetAsync(this HttpClient client, RequestBuilder requestBuilder)
        {
            var paramString = string.Join("&", requestBuilder.GetParameters().Select(param => $"{param.Key}={param.Value}"));
            var url = string.Join("?", requestBuilder.Url, paramString);
            return client.GetAsync(url);
        }

        /// <summary>
        /// Perform a POST request.
        /// </summary>
        /// <param name="client">The HttpClient to use for the request.</param>
        /// <param name="requestBuilder">The RequestBuilder from which to generate the request.</param>
        /// <returns>The request.</returns>
        public static Task<HttpResponseMessage> PostAsync(this HttpClient client, RequestBuilder requestBuilder)
        {
            return client.PostAsync(requestBuilder.Url, new FormUrlEncodedContent(requestBuilder.GetParameters()));
        }
    }
}

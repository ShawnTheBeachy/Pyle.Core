using Pyle.Core.Enums;
using Pyle.Core.Enums.Maps;
using Pyle.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Pyle.Core.Models
{
    /// <summary>
    /// Fluent builder for API requests.
    /// </summary>
    public sealed class RequestBuilder
    {
        private IKeyProvider KeyProvider { get; set; }
        private bool _noSite = false;
        private Dictionary<string, string> Parameters { get; } = new Dictionary<string, string>();
        private ISiteProvider SiteProvider { get; set; }
        private ITokenProvider TokenProvider { get; set; }
        public string Url { get; set; }

        public RequestBuilder(IKeyProvider keyProvider, ISiteProvider siteProvider, ITokenProvider tokenProvider)
        {
            KeyProvider = keyProvider ?? throw new ArgumentNullException(nameof(keyProvider));
            SiteProvider = siteProvider ?? throw new ArgumentNullException(nameof(siteProvider));
            TokenProvider = tokenProvider ?? throw new ArgumentNullException(nameof(tokenProvider));
        }

        /// <summary>
        /// Adds a Parameter object to the list of parameters.
        /// </summary>
        /// <param name="parameter">The parameter to be added to the list.</param>
        /// <returns>The RequestBuilder.</returns>
        public RequestBuilder AddParameter(string key, object value)
        {
            if (value == null)
                return this;

            var mappedValue = MapEnum(value);
            Parameters.Add(key, mappedValue);
            return this;
        }

        /// <summary>
        /// Replaces a segment of the URL with the provided parameter.
        /// </summary>
        /// <param name="parameter">The parameter to be added to the URL.</param>
        /// <returns>The RequestBuilder.</returns>
        public RequestBuilder AddTemplateParameter(string key, object value)
        {
            var mappedValue = MapEnum(value);
            Url = Url.Replace(key, mappedValue);
            return this;
        }

        public IEnumerable<KeyValuePair<string, string>> GetParameters()
        {
            var parameters = new Dictionary<string, string>
            {
                ["key"] = KeyProvider.GetKey(),
                ["access_token"] = TokenProvider.GetToken()
            };

            if (!_noSite)
            {
                var site = SiteProvider.GetSite()?.ApiSiteParameter;

                if (!string.IsNullOrWhiteSpace(site))
                    parameters["site"] = site;
            }

            foreach (var param in Parameters)
                parameters.Add(param.Key, param.Value);

            return parameters;
        }

        private string MapEnum(object value)
        {
            if (value is Order order)
                return OrderMap.Match(order);
            if (value is Sort sort)
                return SortMap.Match(sort);

            return value?.ToString();
        }

        public RequestBuilder NoSite()
        {
            _noSite = true;
            return this;
        }

        /// <summary>
        /// Sets the endpoint to which to send the request.
        /// </summary>
        /// <param name="endpoint"></param>
        /// <returns></returns>
        public RequestBuilder SetEndpoint(Endpoint endpoint)
        {
            Url = EndpointMap.Match(endpoint);
            return this;
        }
    }
}

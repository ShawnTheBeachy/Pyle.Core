using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pyle.Core.JsonConverters;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pyle.Core
{
    public class Client : BaseNotify
    {
        public enum Orders
        {
            asc,
            desc
        }

        public enum Sorts
        {
            activity,
            creation,
            votes
        }

        #region QuotaRemaining

        private int _quotaRemaining;
        public int QuotaRemaining { get => _quotaRemaining; set { Set(ref _quotaRemaining, value);/* if (value < 50) QuotaLow?.Invoke(new QuotaEventArgs { QuotaRemaining = value });*/ } }

        #endregion QuotaRemaining

        public string AccessToken, Site;
        private string _key;
        private const string _baseAddress = "https://api.stackexchange.com/2.2";
        private int _quotaMax = 0;

        public Client(string clientKey, string accessToken, string site)
        {
            _key = clientKey;
            AccessToken = accessToken;
            Site = site;
        }

        private async Task<ClientResponse<T>> GetRequestAsync<T>(string url, ClientRequestConfig config)
        {
            var clientResponse = new ClientResponse<T>();

            try
            {
                using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip }))
                {
                    client.BaseAddress = new Uri(_baseAddress);
                    var response = await client.GetAsync(url);
                    var content = await response.Content.ReadAsStringAsync();
                    var responseObject = JObject.Parse(content);

                    if (response.IsSuccessStatusCode)
                    {
                        var itemsToken = responseObject.SelectToken("items");
                        clientResponse.Response = itemsToken.ToObject<T>();
                        clientResponse.HasMore = (bool)responseObject.SelectToken("has_more");

                        UpdateQuota(responseObject);
                    }

                    else
                        clientResponse.Error = responseObject.ToObject<Error>();
                }
            }

            catch (Exception e)
            {
                clientResponse.Error = new Error(0, "Pyle exception", e.Message);
            }

            return clientResponse;
        }

        private async Task<ClientResponse<T>> PostRequestAsync<T>(string url, IDictionary<string, string> data, ClientRequestConfig config)
        {
            var clientResponse = new ClientResponse<T>();
            var postContent = new FormUrlEncodedContent(data);

            try
            {
                using (var client = new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.GZip }))
                {
                    client.BaseAddress = new Uri(_baseAddress);
                    var response = await client.PostAsync(url, postContent);
                    var content = await response.Content.ReadAsStringAsync();
                    var responseObject = JObject.Parse(content);

                    if (response.IsSuccessStatusCode)
                    {
                        var itemsToken = responseObject.SelectToken("items");
                        clientResponse.Response = itemsToken.ToObject<T>();
                        clientResponse.HasMore = (bool)responseObject.SelectToken("has_more");

                        UpdateQuota(responseObject);
                    }

                    else
                        clientResponse.Error = responseObject.ToObject<Error>();
                }
            }

            catch (Exception e)
            {
                clientResponse.Error = new Error(0, "Pyle exception", e.Message);
            }

            return clientResponse;
        }

        private void UpdateQuota(JObject jObj)
        {
            _quotaMax = (int)jObj.SelectToken("quota_max");
            QuotaRemaining = (int)jObj.SelectToken("quota_remaining");
        }

        #region Answers

        #region CRUD

        public async Task<ClientResponse<IEnumerable<Answer>>> GetAnswersByQuestionIdsAsync(ClientRequestConfig config, IEnumerable<int> questionIds, int page = 1, int pageSize = 50, DateTime? fromDate = null, DateTime? toDate = null, Orders order = Orders.desc, Sorts sort = Sorts.activity)
        {
            var fromDateString = fromDate.HasValue ? $"&fromdate={fromDate.Value.ToUniversalTime()}" : string.Empty;
            var toDateString = toDate.HasValue ? $"&todate={toDate.Value.ToUniversalTime()}" : string.Empty;
            var url = $"/questions/{string.Join(";", questionIds)}/answers?page={page}&pagesize={pageSize}&order={order}&sort={sort}&site={Site}{fromDateString}{toDateString}&key={_key}&filter={config.Filter}&access_token={AccessToken}";

            var response = await GetRequestAsync<IEnumerable<Answer>>(url, config);
            return response;
        }

        #endregion CRUd

        #region Voting

        #region Downvoting

        public async Task<ClientResponse<IEnumerable<Answer>>> UndoDownvoteAnswerAsync(ClientRequestConfig config, int answerId)
        {
            var url = $"/answers/{answerId}/downvote/undo";
            var data = new Dictionary<string, string>
            {
                ["site"] = Site,
                ["filter"] = config.Filter,
                ["access_token"] = AccessToken,
                ["key"] = _key
            };

            var response = await PostRequestAsync<IEnumerable<Answer>>(url, data, config);
            return response;
        }

        public async Task<ClientResponse<IEnumerable<Answer>>> DownvoteAnswerAsync(ClientRequestConfig config, int answerId)
        {
            var url = $"/answers/{answerId}/downvote";
            var data = new Dictionary<string, string>
            {
                ["site"] = Site,
                ["filter"] = config.Filter,
                ["access_token"] = AccessToken,
                ["key"] = _key
            };

            var response = await PostRequestAsync<IEnumerable<Answer>>(url, data, config);
            return response;
        }

        #endregion Downvoting

        #region Upvoting

        public async Task<ClientResponse<IEnumerable<Answer>>> UndoUpvoteAnswerAsync(ClientRequestConfig config, int answerId)
        {
            var url = $"/answers/{answerId}/upvote/undo";
            var data = new Dictionary<string, string>
            {
                ["site"] = Site,
                ["filter"] = config.Filter,
                ["access_token"] = AccessToken,
                ["key"] = _key
            };

            var response = await PostRequestAsync<IEnumerable<Answer>>(url, data, config);
            return response;
        }

        public async Task<ClientResponse<IEnumerable<Answer>>> UpvoteAnswerAsync(ClientRequestConfig config, int answerId)
        {
            var url = $"/answers/{answerId}/upvote";
            var data = new Dictionary<string, string>
            {
                ["site"] = Site,
                ["filter"] = config.Filter,
                ["access_token"] = AccessToken,
                ["key"] = _key
            };

            var response = await PostRequestAsync<IEnumerable<Answer>>(url, data, config);
            return response;
        }

        #endregion Upvoting

        #endregion Voting

        #endregion Answers

        #region Inbox

        public async Task<ClientResponse<IEnumerable<InboxItem>>> GetInboxItemsAsync(ClientRequestConfig config, int page = 1, int pageSize = 10, DateTime? since = null)
        {
            var sinceString = since != null ? $"&since={JsonConvert.SerializeObject(since, Formatting.None, new JsonConverter[] { new TimestampConverter() })}" : string.Empty;
            var url = $"/inbox?page={page}&pagesize={pageSize}{sinceString}&access_token={AccessToken}&key={_key}&filter={config.Filter}";
            var response = await GetRequestAsync<IEnumerable<InboxItem>>(url, config);
            return response;
        }

        #endregion Inbox

        #region Questions

        #region CRUD

        public async Task<ClientResponse<IEnumerable<Question>>> GetQuestionsByIdsAsync(ClientRequestConfig config, IEnumerable<int> questionIds, int page = 1, int pageSize = 50, DateTime? fromDate = null, DateTime? toDate = null, Orders order = Orders.desc, Sorts sort = Sorts.activity)
        {
            var fromDateString = fromDate.HasValue ? $"&fromdate={fromDate.Value.ToUniversalTime()}" : string.Empty;
            var toDateString = toDate.HasValue ? $"&todate={toDate.Value.ToUniversalTime()}" : string.Empty;
            var url = $"/questions/{string.Join(";", questionIds)}?page={page}&pagesize={pageSize}{fromDateString}{toDateString}&order={order}&sort={sort}&site={Site}&key={_key}&filter={config.Filter}&access_token={AccessToken}";

            var response = await GetRequestAsync<IEnumerable<Question>>(url, config);
            return response;
        }

        public async Task<ClientResponse<IEnumerable<Question>>> GetQuestionsBySiteAsync(ClientRequestConfig config, int page = 1, int pageSize = 50, DateTime? fromDate = null, DateTime? toDate = null, Orders order = Orders.desc, Sorts sort = Sorts.activity)
        {
            var fromDateString = fromDate.HasValue ? $"&fromdate={fromDate.Value.ToUniversalTime()}" : string.Empty;
            var toDateString = toDate.HasValue ? $"&todate={toDate.Value.ToUniversalTime()}" : string.Empty;
            var url = $"/questions?page={page}&pagesize={pageSize}{fromDateString}{toDateString}&order={order}&sort={sort}&site={Site}&key={_key}&filter={config.Filter}&access_token={AccessToken}";
            var response = await GetRequestAsync<IEnumerable<Question>>(url, config);
            return response;
        }

        #endregion CRUD

        #region Favoriting

        public async Task<ClientResponse<IEnumerable<Question>>> FavoriteQuestionAsync(ClientRequestConfig config, int questionId)
        {
            var url = $"/questions/{questionId}/favorite";
            var data = new Dictionary<string, string>
            {
                ["site"] = Site,
                ["filter"] = config.Filter,
                ["access_token"] = AccessToken,
                ["key"] = _key
            };

            var response = await PostRequestAsync<IEnumerable<Question>>(url, data, config);
            return response;
        }

        public async Task<ClientResponse<IEnumerable<Question>>> UndoFavoriteQuestionAsync(ClientRequestConfig config, int questionId)
        {
            var url = $"/questions/{questionId}/favorite/undo";
            var data = new Dictionary<string, string>
            {
                ["site"] = Site,
                ["filter"] = config.Filter,
                ["access_token"] = AccessToken,
                ["key"] = _key
            };

            var response = await PostRequestAsync<IEnumerable<Question>>(url, data, config);
            return response;
        }

        #endregion Favoriting

        #region Voting

        #region Downvoting

        public async Task<ClientResponse<IEnumerable<Question>>> UndoDownvoteQuestionAsync(ClientRequestConfig config, int questionId)
        {
            var url = $"/questions/{questionId}/downvote/undo";
            var data = new Dictionary<string, string>
            {
                ["site"] = Site,
                ["filter"] = config.Filter,
                ["access_token"] = AccessToken,
                ["key"] = _key
            };

            var response = await PostRequestAsync<IEnumerable<Question>>(url, data, config);
            return response;
        }

        public async Task<ClientResponse<IEnumerable<Question>>> DownvoteQuestionAsync(ClientRequestConfig config, int questionId)
        {
            var url = $"/questions/{questionId}/downvote";
            var data = new Dictionary<string, string>
            {
                ["site"] = Site,
                ["filter"] = config.Filter,
                ["access_token"] = AccessToken,
                ["key"] = _key
            };

            var response = await PostRequestAsync<IEnumerable<Question>>(url, data, config);
            return response;
        }

        #endregion Downvoting

        #region Upvoting

        public async Task<ClientResponse<IEnumerable<Question>>> UndoUpvoteQuestionAsync(ClientRequestConfig config, int questionId)
        {
            var url = $"/questions/{questionId}/upvote/undo";
            var data = new Dictionary<string, string>
            {
                ["site"] = Site,
                ["filter"] = config.Filter,
                ["access_token"] = AccessToken,
                ["key"] = _key
            };

            var response = await PostRequestAsync<IEnumerable<Question>>(url, data, config);
            return response;
        }

        public async Task<ClientResponse<IEnumerable<Question>>> UpvoteQuestionAsync(ClientRequestConfig config, int questionId)
        {
            var url = $"/questions/{questionId}/upvote";
            var data = new Dictionary<string, string>
            {
                ["site"] = Site,
                ["filter"] = config.Filter,
                ["access_token"] = AccessToken,
                ["key"] = _key
            };

            var response = await PostRequestAsync<IEnumerable<Question>>(url, data, config);
            return response;
        }

        #endregion Upvoting

        #endregion Voting

        #endregion Questions

        #region Reputation

        public async Task<ClientResponse<IEnumerable<ReputationHistory>>> GetMeReputationHistoryFullAsync(ClientRequestConfig config, int page = 1, int pageSize = 500)
        {
            var url = $"/me/reputation-history/full?page={page}&key={_key}&filter={config.Filter}&access_token={AccessToken}&site={Site}";
            var response = await GetRequestAsync<IEnumerable<ReputationHistory>>(url, config);
            return response;
        }

        #endregion Reputation

        #region Sites

        public async Task<ClientResponse<IEnumerable<Site>>> GetSitesAsync(ClientRequestConfig config, int page = 1, int pageSize = 500)
        {
            var url = $"/sites?page={page}&pagesize={pageSize}&key={_key}&filter={config.Filter}";
            var response = await GetRequestAsync<IEnumerable<Site>>(url, config);
            return response;
        }

        #endregion Sites

        #region Users

        public async Task<ClientResponse<IEnumerable<NetworkUser>>> GetAssociatedAccountsAsync(ClientRequestConfig config, int page = 1, int pageSize = 50, int? userId = null)
        {
            var userPart = userId == null ? "me/associated" : $"users/{userId}/associated";
            var url = $"/{userPart}?page={page}&pagesize={pageSize}&access_token={AccessToken}&key={_key}";
            var response = await GetRequestAsync<IEnumerable<NetworkUser>>(url, config);
            return response;
        }

        public async Task<ClientResponse<IEnumerable<User>>> GetMeAsync(ClientRequestConfig config, int page = 1, int pageSize = 50, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var fromDateString = fromDate.HasValue ? $"&fromdate={fromDate.Value.ToUniversalTime()}" : string.Empty;
            var toDateString = toDate.HasValue ? $"&todate={toDate.Value.ToUniversalTime()}" : string.Empty;
            var url = $"/me?order=desc&sort=reputation&page={page}&pagesize={pageSize}{fromDateString}{toDateString}&site={Site}&access_token={AccessToken}&key={_key}&filter={config.Filter}";
            var response = await GetRequestAsync<IEnumerable<User>>(url, config);
            return response;
        }

        public async Task<ClientResponse<IEnumerable<UserTimeline>>> GetMeTimelineAsync(ClientRequestConfig config, int page = 1, int pageSize = 50, DateTime? fromDate = null, DateTime? toDate = null)
        {
            var fromDateString = fromDate.HasValue ? $"&fromdate={fromDate.Value.ToUniversalTime()}" : string.Empty;
            var toDateString = toDate.HasValue ? $"&todate={toDate.Value.ToUniversalTime()}" : string.Empty;
            var url = $"/me/timeline?page={page}&pagesize={pageSize}{fromDateString}{toDateString}&site={Site}&access_token={AccessToken}&key={_key}&filter={config.Filter}";
            var response = await GetRequestAsync<IEnumerable<UserTimeline>>(url, config);
            return response;
        }

        #endregion Users
    }
}

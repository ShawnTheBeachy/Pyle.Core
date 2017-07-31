using Newtonsoft.Json;

namespace Pyle.Core
{
    [JsonObject(MemberSerialization.OptIn)]
    public class NetworkUser : BaseNotify
    {
        #region AccountId

        private int _accountId = default(int);
        [JsonProperty("account_id")]
        public int AccountId { get => _accountId; set => Set(ref _accountId, value); }

        #endregion AccountId

        #region AnswerCount

        private int _answerCount = default(int);
        [JsonProperty("answer_count")]
        public int AnswerCount { get => _answerCount; set => Set(ref _answerCount, value); }

        #endregion AnswerCount

        #region SiteUrl

        private string _siteUrl;
        [JsonProperty("site_url")]
        public string SiteUrl { get => _siteUrl; set => Set(ref _siteUrl, value); }

        #endregion SiteUrl
    }
}

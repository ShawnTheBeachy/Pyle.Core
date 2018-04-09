using Newtonsoft.Json;
using Pyle.Core.JsonConverters;

namespace Pyle.Core.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class User : BaseNotify
    {
        #region AboutMe

        private string _aboutMe = default(string);
        [JsonProperty("about_me")]
        public string AboutMe { get => _aboutMe; set => Set(ref _aboutMe, value); }

        #endregion AboutMe

        #region AcceptRate

        private int? _acceptRate = default(int);
        [JsonProperty("accept_rate")]
        public int? AcceptRate { get => _acceptRate; set => Set(ref _acceptRate, value); }

        #endregion AcceptRate

        #region AccountId

        private int _accountId = default(int);
        [JsonProperty("account_id")]
        public int AccountId { get => _accountId; set => Set(ref _accountId, value); }

        #endregion AccountId

        #region Age

        private int? _age = default(int);
        [JsonProperty("age")]
        public int? Age { get => _age; set => Set(ref _age, value); }

        #endregion Age

        #region AnswerCount

        private int _answerCount = default(int);
        [JsonProperty("answer_count")]
        public int AnswerCount { get => _answerCount; set => Set(ref _answerCount, value); }

        #endregion AnswerCount

        #region DisplayName

        private string _displayName = default(string);
        [JsonProperty("display_name"), JsonConverter(typeof(HtmlDecodingConverter))]
        public string DisplayName { get => _displayName; set => Set(ref _displayName, value); }

        #endregion DisplayName

        #region ProfileImage

        private string _profileImage = string.Empty;
        [JsonProperty("profile_image")]
        public string ProfileImage { get => _profileImage; set => Set(ref _profileImage, value); }

        #endregion ProfileImage

        #region Reputation

        private int _reputation = default(int);
        [JsonProperty("reputation")]
        public int Reputation { get => _reputation; set => Set(ref _reputation, value); }

        #endregion Reputation

        #region UserId

        private int _userId = default(int);
        [JsonProperty("user_id")]
        public int UserId { get => _userId; set => Set(ref _userId, value); }

        #endregion UserId
    }
}

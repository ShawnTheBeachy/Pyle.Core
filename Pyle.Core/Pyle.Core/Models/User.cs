using Newtonsoft.Json;
using Pyle.Core.JsonConverters;

namespace Pyle.Core
{
    [JsonObject(MemberSerialization.OptIn)]
    public class User : BaseNotify
    {
        #region DisplayName

        private string _displayName = string.Empty;
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
    }
}

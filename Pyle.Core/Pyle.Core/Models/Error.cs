using Newtonsoft.Json;

namespace Pyle.Core
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Error : CoreModel
    {
        #region ErrorId

        private int _errorId = default(int);
        [JsonProperty("error_id")]
        public int ErrorId { get => _errorId; set => Set(ref _errorId, value); }

        #endregion ErrorId

        #region ErrorMessage

        private string _errorMessage = string.Empty;
        [JsonProperty("error_message")]
        public string ErrorMessage { get => _errorMessage; set => Set(ref _errorMessage, value); }

        #endregion ErrorMessage

        #region ErrorName

        private string _errorName = string.Empty;
        [JsonProperty("error_name")]
        public string ErrorName { get => _errorName; set => Set(ref _errorName, value); }

        #endregion ErrorName
    }
}

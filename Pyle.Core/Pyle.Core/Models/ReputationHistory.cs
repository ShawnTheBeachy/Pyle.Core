using Newtonsoft.Json;
using Pyle.Core.JsonConverters;
using System;

namespace Pyle.Core
{
    [JsonObject(MemberSerialization.OptIn)]
    public class ReputationHistory : BaseNotify
    {
        #region CreationDate

        private DateTime _creationDate = default(DateTime);
        [JsonProperty("creation_date"), JsonConverter(typeof(TimestampConverter))]
        public DateTime CreationDate { get => _creationDate; set => Set(ref _creationDate, value); }

        #endregion CreationDate

        #region PostId

        private int _postId = default(int);
        [JsonProperty("post_id")]
        public int PostId { get => _postId; set => Set(ref _postId, value); }

        #endregion PostId

        #region ReputationChange

        private int _reputationChange = default(int);
        [JsonProperty("reputation_change")]
        public int ReputationChange { get => _reputationChange; set => Set(ref _reputationChange, value); }

        #endregion ReputationChange
    }
}

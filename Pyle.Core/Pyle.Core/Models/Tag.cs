using Newtonsoft.Json;
using Pyle.Core.JsonConverters;
using System;
using System.Collections.Generic;

namespace Pyle.Core.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Tag : BaseNotify
    {
        #region Count

        private int _count = default(int);
        [JsonProperty("count")]
        public int Count { get => _count; set => Set(ref _count, value); }

        #endregion Count

        #region HasSynonyms

        private bool _hasSynonyms = false;
        [JsonProperty("has_synonyms")]
        public bool HasSynonyms { get => _hasSynonyms; set => Set(ref _hasSynonyms, value); }

        #endregion HasSynonyms

        #region IsModeratorOnly

        private bool _isModeratorOnly = false;
        [JsonProperty("is_moderator_only")]
        public bool IsModeratorOnly { get => _isModeratorOnly; set => Set(ref _isModeratorOnly, value); }

        #endregion IsModeratorOnly

        #region IsRequired

        private bool _isRequired = false;
        [JsonProperty("is_required")]
        public bool IsRequired { get => _isRequired; set => Set(ref _isRequired, value); }

        #endregion IsRequired

        #region LastActivityDate

        private DateTime _lastActivityDate = default(DateTime);
        [JsonProperty("last_activity_date"), JsonConverter(typeof(TimestampConverter))]
        public DateTime LastActivityDate { get => _lastActivityDate; set => Set(ref _lastActivityDate, value); }

        #endregion LastActivityDate

        #region Name

        private string _name = string.Empty;
        [JsonProperty("name")]
        public string Name { get => _name; set => Set(ref _name, value); }

        #endregion Name

        #region Synonyms

        private List<string> _synonyms = new List<string>();
        [JsonProperty("synonyms")]
        public List<string> Synonyms { get => _synonyms; set => Set(ref _synonyms, value); }

        #endregion Synonyms

        #region UserId

        private int _userId = default(int);
        [JsonProperty("user_id")]
        public int UserId { get => _userId; set => Set(ref _userId, value); }

        #endregion UserId

        public enum TagSorts
        {
            activity,
            name,
            popular
        }
    }
}

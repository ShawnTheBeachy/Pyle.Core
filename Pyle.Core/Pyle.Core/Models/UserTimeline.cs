using Newtonsoft.Json;
using Pyle.Core.JsonConverters;
using System;

namespace Pyle.Core.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class UserTimeline : BaseNotify
    {
        #region BadgeId

        private int? _badgeId = default(int?);
        [JsonProperty("badge_id")]
        public int? BadgeId { get => _badgeId; set => Set(ref _badgeId, value); }

        #endregion BadgeId

        #region CommentId

        private int? _commentId = default(int?);
        [JsonProperty("comment_id")]
        public int? CommentId { get => _commentId; set => Set(ref _commentId, value); }

        #endregion CommentId

        #region CreationDate

        private DateTime _creationDate = default(DateTime);
        [JsonProperty("creation_date"), JsonConverter(typeof(TimestampConverter))]
        public DateTime CreationDate { get => _creationDate; set => Set(ref _creationDate, value); }

        #endregion CreationDate

        #region Detail

        private string _detail = default(string);
        [JsonProperty("detail"), JsonConverter(typeof(HtmlDecodingConverter))]
        public string Detail { get => _detail; set => Set(ref _detail, value); }

        #endregion Detail

        #region Link

        private string _link = default(string);
        [JsonProperty("link")]
        public string Link { get => _link; set => Set(ref _link, value); }

        #endregion Link

        #region PostId

        private int? _postId = default(int?);
        [JsonProperty("post_id")]
        public int? PostId { get => _postId; set => Set(ref _postId, value); }

        #endregion PostId

        #region PostType

        private PostTypes _postType = default(PostTypes);
        [JsonProperty("post_type")]
        public PostTypes PostType { get => _postType; set => Set(ref _postType, value); }

        #endregion PostType

        #region SuggestedEditId

        private int? _suggestedEditId = default(int?);
        [JsonProperty("suggested_edit_id")]
        public int? SuggestedEditId { get => _suggestedEditId; set => Set(ref _suggestedEditId, value); }

        #endregion SuggestedEditId

        #region TimelineType

        private TimelineTypes _timelineType = default(TimelineTypes);
        [JsonProperty("timeline_type")]
        public TimelineTypes TimelineType { get => _timelineType; set => Set(ref _timelineType, value); }

        #endregion TimelineType

        #region Title

        private string _title = default(string);
        [JsonProperty("title"), JsonConverter(typeof(HtmlDecodingConverter))]
        public string Title { get => _title; set => Set(ref _title, value); }

        #endregion Title

        #region UserId

        private int? _userId = default(int?);
        [JsonProperty("user_id")]
        public int? UserId { get => _userId; set => Set(ref _userId, value); }

        #endregion UserId

        public enum PostTypes
        {
            answer,
            question
        }

        public enum TimelineTypes
        {
            accepted,
            answered,
            asked,
            badge,
            commented,
            reviewed,
            revision,
            suggested
        }

        public string GetDisplay(string detail, string title) =>
            detail ?? title;
    }
}

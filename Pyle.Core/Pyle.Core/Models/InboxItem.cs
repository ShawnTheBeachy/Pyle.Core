using Newtonsoft.Json;
using Pyle.Core.JsonConverters;
using System;

namespace Pyle.Core
{
    public class InboxItem : BaseNotify
    {
        #region AnswerId

        private int? _answerId = null;
        /// <summary>
        /// Refers to an answer. May be absent. Included in the default filter.
        /// </summary>
        [JsonProperty("answer_id")]
        public int? AnswerId { get => _answerId; set => Set(ref _answerId, value); }

        #endregion AnswerId

        #region Body

        private string _body = string.Empty;
        /// <summary>
        /// Unchanged in unsafe filters. May be absent. Not included in the default filter.
        /// </summary>
        [JsonProperty("body"), JsonConverter(typeof(HtmlDecodingConverter))]
        public string Body { get => _body; set => Set(ref _body, value); }

        #endregion Body

        #region CommentId

        private int? _commentId = null;
        /// <summary>
        /// Unchanged in unsafe filters. May be absent. Included in the default filter.
        /// </summary>
        [JsonProperty("comment_id")]
        public int? CommentId { get => _commentId; set => Set(ref _commentId, value); }

        #endregion CommentId

        #region CreationDate

        private DateTime _creationDate = DateTime.Now;
        /// <summary>
        /// Included in the default filter.
        /// </summary>
        [JsonProperty("creation_date")]
        [JsonConverter(typeof(TimestampConverter))]
        public DateTime CreationDate { get => _creationDate; set => Set(ref _creationDate, value); }

        #endregion CreationDate

        #region IsUnread

        private bool _isUnread = false;
        /// <summary>
        /// Included in the default filter.
        /// </summary>
        [JsonProperty("is_unread")]
        public bool IsUnread { get => _isUnread; set => Set(ref _isUnread, value); }

        #endregion IsUnread

        #region ItemType

        private ItemTypes _itemType;
        /// <summary>
        /// Included in the default filter.
        /// </summary>
        [JsonProperty("item_type")]
        public ItemTypes ItemType { get => _itemType; set => Set(ref _itemType, value); }

        #endregion ItemType

        #region Link

        private string _link = string.Empty;
        /// <summary>
        /// Unchanged in unsafe filters. Included in the default filter.
        /// </summary>
        [JsonProperty("link")]
        public string Link { get => _link; set => Set(ref _link, value); }

        #endregion Link

        #region QuestionId

        private int? _questionId = null;
        /// <summary>
        /// Refers to a question. May be absent. Included in the default filter.
        /// </summary>
        [JsonProperty("question_id")]
        public int? QuestionId { get => _questionId; set => Set(ref _questionId, value); }

        #endregion QuestionId

        #region Site

        private Site _site = null;
        /// <summary>
        /// May be absent. Included in the default filter.
        /// </summary>
        [JsonProperty("site")]
        public Site Site { get => _site; set => Set(ref _site, value); }

        #endregion Site

        #region Title

        private string _title = string.Empty;
        /// <summary>
        /// Included in the default filter.
        /// </summary>
        [JsonProperty("title"), JsonConverter(typeof(HtmlDecodingConverter))]
        public string Title { get => _title; set => Set(ref _title, value); }

        #endregion Title

        public enum ItemTypes
        {
            comment,
            chat_message,
            new_answer,
            careers_message,
            careers_invitations,
            meta_question,
            post_notice,
            moderator_message
        }
    }
}

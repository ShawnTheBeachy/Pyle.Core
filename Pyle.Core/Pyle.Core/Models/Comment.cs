using Newtonsoft.Json;
using Pyle.Core.JsonConverters;
using System;

namespace Pyle.Core.Models
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Comment : BaseNotify
    {
        #region Body

        private string _body;
        /// <summary>
        /// Represents the HTML body of this comment. Excluded in the default filter.
        /// </summary>
        [JsonProperty("body")]
        public string Body { get { return _body; } set { Set(ref _body, value); } }

        #endregion Body

        #region BodyMarkdown

        private string _bodyMarkdown;
        /// <summary>
        /// Represents the Markdown body of this comment. Excluded in the default filter.
        /// </summary>
        [JsonProperty("body_markdown"), JsonConverter(typeof(HtmlDecodingConverter))]
        public string BodyMarkdown { get { return _bodyMarkdown; } set { Set(ref _bodyMarkdown, value); } }

        #endregion BodyMarkdown

        #region CanFlag

        private bool _canFlag;
        /// <summary>
        /// Represents whether or not you can flag this comment. Excluded in the default filter.
        /// </summary>
        [JsonProperty("can_flag")]
        public bool CanFlag { get { return _canFlag; } set { Set(ref _canFlag, value); } }

        #endregion CanFlag

        #region CommentId

        private int _commentId;
        /// <summary>
        /// Represents the identifier for this comment. Included in the default filter.
        /// </summary>
        [JsonProperty("comment_id")]
        public int CommentId { get { return _commentId; } set { Set(ref _commentId, value); } }

        #endregion CommentId

        #region CreationDate

        private DateTime _creationDate;
        /// <summary>
        /// Represents the date on which this comment was created. Included in the default filter.
        /// </summary>
        [JsonProperty("creation_date"), JsonConverter(typeof(TimestampConverter))]
        public DateTime CreationDate { get { return _creationDate; } set { Set(ref _creationDate, value); } }

        #endregion CreationDate

        #region Edited

        private bool _edited;
        /// <summary>
        /// Represents whether or not this question has been edited. Included in the default filter.
        /// </summary>
        [JsonProperty("edited")]
        public bool Edited { get { return _edited; } set { Set(ref _edited, value); } }

        #endregion Edited

        #region Link

        private string _link;
        /// <summary>
        /// Represents a web link to this comment. Excluded in the default filter.
        /// </summary>
        [JsonProperty("link")]
        public string Link { get { return _link; } set { Set(ref _link, value); } }

        #endregion Link

        #region Owner

        private User _owner;
        /// <summary>
        /// Represents the user who posted this comment. Included in the default filter.
        /// </summary>
        [JsonProperty("owner")]
        public User Owner { get { return _owner; } set { Set(ref _owner, value); } }

        #endregion Owner

        #region PostId

        private int postId;
        /// <summary>
        /// Represents the identifier for the post which this comment was posted on. Included in the default filter.
        /// </summary>
        [JsonProperty("post_id")]
        public int PostId { get { return postId; } set { Set(ref postId, value); } }

        #endregion PostId

        #region PostType

        private PostTypes _postType;
        /// <summary>
        /// Represents the type of the post which this comment was posted on. One of "question" or "answer." Excluded in the default filter.
        /// </summary>
        [JsonProperty("post_type")]
        public PostTypes PostType { get { return _postType; } set { Set(ref _postType, value); } }

        #endregion PostType

        #region ReplyToUser

        private User _replyToUser;
        /// <summary>
        /// Represents the user to whom this comment is replying. May be absent. Included in the default filter.
        /// </summary>
        [JsonProperty("reply_to_user")]
        public User ReplyToUser { get { return _replyToUser; } set { Set(ref _replyToUser, value); } }

        #endregion ReplyToUser

        #region Score

        private int _score;
        /// <summary>
        /// Represents the overall score of this comment. Included in the default filter.
        /// </summary>
        [JsonProperty("score")]
        public int Score { get { return _score; } set { Set(ref _score, value); } }

        #endregion Score

        #region Upvoted

        private bool _upvoted;
        /// <summary>
        /// Represents whether or not you upvoted this comment. Private. Excluded in the default filter.
        /// </summary>
        [JsonProperty("upvoted")]
        public bool Upvoted { get { return _upvoted; } set { Set(ref _upvoted, value); } }

        #endregion Upvoted

        /// <summary>
        /// Represents the different types of posts.
        /// </summary>
        public enum PostTypes
        {
            /// <summary>
            /// Represents a post type of "question."
            /// </summary>
            question,
            /// <summary>
            /// Represents a post type of "answer."
            /// </summary>
            answer
        }

        public enum CommentSorts
        {
            creation,
            votes
        }
    }
}

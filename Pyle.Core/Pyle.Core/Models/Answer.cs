using Newtonsoft.Json;
using Pyle.Core.JsonConverters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Pyle.Core
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Answer : BaseNotify
    {
        #region Accepted

        private bool _accepted;
        /// <summary>
        /// Represents whether or not you have accepted this answer. Private. Excluded in the default filter.
        /// </summary>
        [JsonProperty("accepted")]
        public bool Accepted { get { return _accepted; } set { Set(ref _accepted, value); } }

        #endregion Accepted

        #region AnswerId

        private int _answerId;
        /// <summary>
        /// Represents the identifier for this answer. Included in the default filter.
        /// </summary>
        [JsonProperty("answer_id")]
        public int AnswerId { get { return _answerId; } set { Set(ref _answerId, value); } }

        #endregion AnswerId

        #region AwardedBountyAmount

        private int _awardedBountyAmount;
        /// <summary>
        /// Represents the bounty amount awarded to this answer. May be absent. Excluded in the default filter.
        /// </summary>
        [JsonProperty("awarded_bounty_amount")]
        public int AwardedBountyAmount { get { return _awardedBountyAmount; } set { Set(ref _awardedBountyAmount, value); } }

        #endregion AwardedBountyAmount

        #region AwardedBountyUsers

        private List<User> _awardedBountyUsers = new List<User>();
        /// <summary>
        /// Represents the users to whom the bounty was awarded. May be absent. Excluded in the default filter.
        /// </summary>
        [JsonProperty("awarded_bounty_users")]
        public List<User> AwardedBountyUsers { get { return _awardedBountyUsers; } set { Set(ref _awardedBountyUsers, value); } }

        #endregion AwardedBountyUsers

        #region Body

        private string _body;
        /// <summary>
        /// Represents the HTML body of this question. Excluded in the default filter.
        /// </summary>
        [JsonProperty("body")]
        public string Body { get { return _body; } set { Set(ref _body, value); } }

        #endregion Body

        #region BodyMarkdown
        
        private string _bodyMarkdown;
        /// <summary>
        /// Represents the Markdown body of this question. Excluded in the default filter.
        /// </summary>
        [JsonProperty("body_markdown"), JsonConverter(typeof(HtmlDecodingConverter))]
        public string BodyMarkdown { get { return _bodyMarkdown; } set { Set(ref _bodyMarkdown, value); } }

        #endregion BodyMarkdown

        #region CanFlag

        private bool _canFlag;
        /// <summary>
        /// Represents whether or not you can flag this question. Excluded in the default filter.
        /// </summary>
        [JsonProperty("can_flag")]
        public bool CanFlag { get { return _canFlag; } set { Set(ref _canFlag, value); } }

        #endregion CanFlag

        #region CommentCount

        private int _commentCount;
        /// <summary>
        /// Represents the number of comments posted on this answer. Excluded in the default filter.
        /// </summary>
        [JsonProperty("comment_count")]
        public int CommentCount { get { return _commentCount; } set { Set(ref _commentCount, value); } }

        #endregion CommentCount

        #region Comments

        private ObservableCollection<Comment> _comments = new ObservableCollection<Comment>();
        /// <summary>
        /// Represents the collection of comments posted on this answer. May be absent. Excluded in the default filter.
        /// </summary>
        [JsonProperty("comments")]
        public ObservableCollection<Comment> Comments { get { return _comments; } set { Set(ref _comments, value); } }

        #endregion Comments

        #region CommunityOwnedDate

        private DateTime _communityOwnedDate;
        /// <summary>
        /// Represents the date on which the community took possession of this answer. May be absent. Included in the default filter.
        /// </summary>
        [JsonProperty("community_owned_date"), JsonConverter(typeof(TimestampConverter))]
        public DateTime CommunityOwnedDate { get { return _communityOwnedDate; } set { Set(ref _communityOwnedDate, value); } }

        #endregion CommunityOwnedDate

        #region CreationDate

        private DateTime _creationDate;
        /// <summary>
        /// Represents the date on which this answer was created. Included in the default filter.
        /// </summary>
        [JsonProperty("creation_date"), JsonConverter(typeof(TimestampConverter))]
        public DateTime CreationDate { get { return _creationDate; } set { Set(ref _creationDate, value); } }

        #endregion CreationDate

        #region DownVoteCount

        private int _downVoteCount;
        /// <summary>
        /// Represents the number of downvotes on this answer. Excluded in the default filter.
        /// </summary>
        [JsonProperty("down_vote_count")]
        public int DownVoteCount { get { return _downVoteCount; } set { Set(ref _downVoteCount, value); } }

        #endregion DownVoteCount

        #region Downvoted

        private bool _downvoted;
        /// <summary>
        /// Represents whether or not you downvoted this answer. Private. Excluded in the default filter.
        /// </summary>
        [JsonProperty("downvoted")]
        public bool Downvoted { get { return _downvoted; } set { Set(ref _downvoted, value); } }

        #endregion Downvoted

        #region IsAccepted

        private bool _isAccepted;
        /// <summary>
        /// Represents whether or not this answer has been accepted. Included in the default filter.
        /// </summary>
        [JsonProperty("is_accepted")]
        public bool IsAccepted { get { return _isAccepted; } set { Set(ref _isAccepted, value); } }

        #endregion IsAccepted

        #region LastActivityDate

        private DateTime _lastActivityDate;
        /// <summary>
        /// Represents the last date on which activity on this answer took place. Included in the default filter.
        /// </summary>
        [JsonProperty("last_activity_date"), JsonConverter(typeof(TimestampConverter))]
        public DateTime LastActivityDate { get { return _lastActivityDate; } set { Set(ref _lastActivityDate, value); } }

        #endregion LastActivityDate

        #region LastEditDate

        private DateTime _lastEditDate;
        /// <summary>
        /// Represents the last date on which this answer was edited. May be absent. Included in the default filter.
        /// </summary>
        [JsonProperty("last_edit_date"), JsonConverter(typeof(TimestampConverter))]
        public DateTime LastEditDate { get { return _lastEditDate; } set { Set(ref _lastEditDate, value); } }

        #endregion LastEditDate

        #region LastEditor

        private User _lastEditor;
        /// <summary>
        /// Represents the last user to edit this answer. Excluded in the default filter.
        /// </summary>
        [JsonProperty("last_editor")]
        public User LastEditor { get { return _lastEditor; } set { Set(ref _lastEditor, value); } }

        #endregion LastEditor

        #region Link

        private string _link;
        /// <summary>
        /// Represents a web link to this answer. Excluded in the default filter.
        /// </summary>
        [JsonProperty("link")]
        public string Link { get { return _link; } set { Set(ref _link, value); } }

        #endregion Link

        #region LockedDate

        private DateTime _lockedDate;
        /// <summary>
        /// Represents the date on which this answer was locked. May be absent. Included in the default filter.
        /// </summary>
        [JsonProperty("locked_date"), JsonConverter(typeof(TimestampConverter))]
        public DateTime LockedDate { get { return _lockedDate; } set { Set(ref _lockedDate, value); } }

        #endregion LockedDate

        #region Owner

        private User _owner;
        /// <summary>
        /// Represents the user who posted this answer. May be absent. Included in the default filter.
        /// </summary>
        [JsonProperty("owner")]
        public User Owner { get { return _owner; } set { Set(ref _owner, value); } }

        #endregion Owner

        #region QuestionId

        private int _questionId;
        /// <summary>
        /// Represents the id of the question for which this answer was posted. Included in the default filter.
        /// </summary>
        [JsonProperty("question_id")]
        public int QuestionId { get { return _questionId; } set { Set(ref _questionId, value); } }

        #endregion QuestionId

        #region Score

        private int _score;
        /// <summary>
        /// Represents the overall score of this answer. Included in the default filter.
        /// </summary>
        [JsonProperty("score")]
        public int Score { get { return _score; } set { Set(ref _score, value); } }

        #endregion Score

        #region ShareLink

        private string _shareLink;
        /// <summary>
        /// Represents a shortened link to this answer. Excluded in the default filter.
        /// </summary>
        [JsonProperty("share_link")]
        public string ShareLink { get { return _shareLink; } set { Set(ref _shareLink, value); } }

        #endregion ShareLink

        #region Tags

        private List<string> _tags = new List<string>();
        /// <summary>
        /// Represents a collection of strings with which this answer was tagged. Excluded in the default filter.
        /// </summary>
        [JsonProperty("tags")]
        public List<string> Tags { get { return _tags; } set { Set(ref _tags, value); } }

        #endregion Tags

        #region Title

        private string _title;
        /// <summary>
        /// Represents the title of this answer. Excluded in the default filter.
        /// </summary>
        [JsonProperty("title")]
        public string Title { get { return _title; } set { Set(ref _title, value); } }

        #endregion Title

        #region UpVoteCount

        private int _upVoteCount;
        /// <summary>
        /// Represents the number of upvotes on this answer. Excluded in the default filter.
        /// </summary>
        [JsonProperty("up_vote_count")]
        public int UpVoteCount { get { return _upVoteCount; } set { Set(ref _upVoteCount, value); } }

        #endregion UpVoteCount

        #region Upvoted

        private bool _upvoted;
        /// <summary>
        /// Represents whether or not you upvoted this answer. Private. Excluded in the default filter.
        /// </summary>
        [JsonProperty("upvoted")]
        public bool Upvoted { get { return _upvoted; } set { Set(ref _upvoted, value); } }

        #endregion Upvoted
    }
}

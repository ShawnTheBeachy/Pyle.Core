using Newtonsoft.Json;
using Pyle.Core.JsonConverters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Pyle.Core
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Question : CoreModel
    {
        #region AcceptedAnswerId

        private int _acceptedAnswerId = default(int);
        [JsonProperty("accepted_answer_id")]
        public int AcceptedAnswerId { get => _acceptedAnswerId; set => Set(ref _acceptedAnswerId, value); }

        #endregion AcceptedAnswerId

        #region AnswerCount

        private int _answerCount = default(int);
        [JsonProperty("answer_count")]
        public int AnswerCount { get => _answerCount; set => Set(ref _answerCount, value); }

        #endregion AnswerCount

        #region Answers

        private ObservableCollection<Answer> _answers = new ObservableCollection<Answer>();
        [JsonProperty("answers")]
        public ObservableCollection<Answer> Answers { get => _answers; set => Set(ref _answers, value); }

        #endregion Answers

        #region Body

        private string _body = default(string);
        [JsonProperty("body")]
        public string Body { get => _body; set => Set(ref _body, value); }

        #endregion Body

        #region BodyMarkdown

        private string _bodyMarkdown = default(string);
        [JsonProperty("body_markdown"), JsonConverter(typeof(HtmlDecodingConverter))]
        public string BodyMarkdown { get => _bodyMarkdown; set => Set(ref _bodyMarkdown, value); }

        #endregion BodyMarkdown

        #region BountyAmount

        private int _bountyAmount = default(int);
        [JsonProperty("bounty_amount")]
        public int BountyAmount { get => _bountyAmount; set => Set(ref _bountyAmount, value); }

        #endregion BountyAmount

        #region BountyClosesDate

        private DateTime _bountyClosesDate = default(DateTime);
        [JsonProperty("bounty_closes_date"), JsonConverter(typeof(TimestampConverter))]
        public DateTime BountyClosesDate { get => _bountyClosesDate; set => Set(ref _bountyClosesDate, value); }

        #endregion BountyClosesDate

        #region BountyUser

        private User _bountyUser = default(User);
        [JsonProperty("bounty_user")]
        public User BountyUser { get => _bountyUser; set => Set(ref _bountyUser, value); }

        #endregion BountyUser

        #region CanClose

        private bool _canClose = false;
        [JsonProperty("can_close")]
        public bool CanClose { get => _canClose; set => Set(ref _canClose, value); }

        #endregion CanClose

        #region CanFlag

        private bool _canFlag = false;
        [JsonProperty("can_flag")]
        public bool CanFlag { get => _canFlag; set => Set(ref _canFlag, value); }

        #endregion CanFlag

        #region CloseVoteCount

        private int _closeVoteCount = default(int);
        [JsonProperty("close_vote_count")]
        public int CloseVoteCount { get => _closeVoteCount; set => Set(ref _closeVoteCount, value); }

        #endregion CloseVoteCount

        #region ClosedDate

        private DateTime _closedDate = default(DateTime);
        [JsonProperty("closed_date"), JsonConverter(typeof(TimestampConverter))]
        public DateTime ClosedDate { get => _closedDate; set => Set(ref _closedDate, value); }

        #endregion ClosedDate

        #region ClosedDetails

        //private ClosedDetails _closedDetails = default(ClosedDetails);
        //[JsonProperty("closed_details")]
        //public ClosedDetails ClosedDetails { get => _closedDetails; set => Set(ref _closedDetails, value); }

        #endregion ClosedDetails

        #region ClosedReason

        private string _closedReason = string.Empty;
        [JsonProperty("closed_reason"), JsonConverter(typeof(HtmlDecodingConverter))]
        public string ClosedReason { get => _closedReason; set => Set(ref _closedReason, value); }

        #endregion ClosedReason

        #region CommentCount

        private int _commentCount = default(int);
        [JsonProperty("comment_count")]
        public int CommentCount { get => _commentCount; set => Set(ref _commentCount, value); }

        #endregion CommentCount

        #region Comments

        private ObservableCollection<Comment> _comments = new ObservableCollection<Comment>();
        [JsonProperty("comments")]
        public ObservableCollection<Comment> Comments { get => _comments; set => Set(ref _comments, value); }

        #endregion Comments

        #region CommunityOwnedDate

        private DateTime _communityOwnedDate = default(DateTime);
        [JsonProperty("community_owned_date"), JsonConverter(typeof(TimestampConverter))]
        public DateTime CommunityOwnedDate { get => _communityOwnedDate; set => Set(ref _communityOwnedDate, value); }

        #endregion CommunityOwnedDate

        #region CreationDate

        private DateTime _creationDate = default(DateTime);
        [JsonProperty("creation_date"), JsonConverter(typeof(TimestampConverter))]
        public DateTime CreationDate { get => _creationDate; set => Set(ref _creationDate, value); }

        #endregion CreationDate

        #region DeleteVoteCount

        private int _deleteVoteCount = default(int);
        [JsonProperty("delete_vote_count")]
        public int DeleteVoteCount { get => _deleteVoteCount; set => Set(ref _deleteVoteCount, value); }

        #endregion DeleteVoteCount

        #region DownVoteCount

        private int _downVoteCount = default(int);
        [JsonProperty("down_vote_count")]
        public int DownVoteCount { get => _downVoteCount; set => Set(ref _downVoteCount, value); }

        #endregion DownVoteCount

        #region Downvoted

        private bool _downvoted = false;
        [JsonProperty("downvoted")]
        public bool Downvoted { get => _downvoted; set => Set(ref _downvoted, value); }

        #endregion Downvoted

        #region FavoriteCount

        private int _favoriteCount = default(int);
        [JsonProperty("favorite_count")]
        public int FavoriteCount { get => _favoriteCount; set => Set(ref _favoriteCount, value); }

        #endregion FavoriteCount

        #region Favorited

        private bool _favorited = false;
        [JsonProperty("favorited")]
        public bool Favorited { get => _favorited; set => Set(ref _favorited, value); }

        #endregion Favorited

        #region IsAnswered

        private bool _isAnswered = false;
        [JsonProperty("is_answered")]
        public bool IsAnswered { get => _isAnswered; set => Set(ref _isAnswered, value); }

        #endregion IsAnswered

        #region LastActivityDate

        private DateTime _lastActivityDate = default(DateTime);
        [JsonProperty("last_activity_date"), JsonConverter(typeof(TimestampConverter))]
        public DateTime LastActivityDate { get => _lastActivityDate; set => Set(ref _lastActivityDate, value); }

        #endregion LastActivityDate

        #region LastEditDate

        private DateTime _lastEditDate = default(DateTime);
        [JsonProperty("last_edit_date"), JsonConverter(typeof(TimestampConverter))]
        public DateTime LastEditDate { get => _lastEditDate; set => Set(ref _lastEditDate, value); }

        #endregion LastEditDate

        #region LastEditor

        private User _lastEditor = default(User);
        [JsonProperty("last_editor")]
        public User LastEditor { get => _lastEditor; set => Set(ref _lastEditor, value); }

        #endregion LastEditor

        #region Link

        private string _link = string.Empty;
        [JsonProperty("link")]
        public string Link { get => _link; set => Set(ref _link, value); }

        #endregion Link

        #region LockedDate

        private DateTime _lockedDate = default(DateTime);
        [JsonProperty("locked_date"), JsonConverter(typeof(TimestampConverter))]
        public DateTime LockedDate { get => _lockedDate; set => Set(ref _lockedDate, value); }

        #endregion LockedDate

        #region MigratedFrom

        //private MigrationInfo _migratedFrom = default(MigrationInfo);
        //[JsonProperty("migrated_from")]
        //public MigrationInfo MigratedFrom { get => _migratedFrom; set => Set(ref _migratedFrom, value); }

        #endregion MigratedFrom

        #region MigratedTo

        //private MigrationInfo _migratedTo = default(MigrationInfo);
        //[JsonProperty("migrated_to")]
        //public MigrationInfo MigratedTo { get => _migratedTo; set => Set(ref _migratedTo, value); }

        #endregion MigratedTo

        #region Notice

        //private Notice _notice = default(Notice);
        //[JsonProperty("notice")]
        //public Notice Notice { get => _notice; set => Set(ref _notice, value); }

        #endregion Notice

        #region Owner

        private User _owner = default(User);
        [JsonProperty("owner")]
        public User Owner { get => _owner; set => Set(ref _owner, value); }

        #endregion Owner

        #region ProtectedDate

        private DateTime _protectedDate = default(DateTime);
        [JsonProperty("protected_date"), JsonConverter(typeof(TimestampConverter))]
        public DateTime ProtectedDate { get => _protectedDate; set => Set(ref _protectedDate, value); }

        #endregion ProtectedDate

        #region QuestionId

        private int _questionId = default(int);
        [JsonProperty("question_id")]
        public int QuestionId { get => _questionId; set => Set(ref _questionId, value); }

        #endregion QuestionId

        #region ReopenVoteCount

        private int _reopenVoteCount = default(int);
        [JsonProperty("reopen_vote_count")]
        public int ReopenVoteCount { get => _reopenVoteCount; set => Set(ref _reopenVoteCount, value); }

        #endregion ReopenVoteCount

        #region Score

        private int _score = default(int);
        [JsonProperty("score")]
        public int Score { get => _score; set => Set(ref _score, value); }

        #endregion Score

        #region ShareLink

        private string _shareLink = string.Empty;
        [JsonProperty("share_link")]
        public string ShareLink { get => _shareLink; set => Set(ref _shareLink, value); }

        #endregion ShareLink

        #region Tags

        private List<string> _tags = new List<string>();
        [JsonProperty("tags")]
        public List<string> Tags { get => _tags; set => Set(ref _tags, value); }

        #endregion Tags

        #region Title

        private string _title = string.Empty;
        [JsonProperty("title"), JsonConverter(typeof(HtmlDecodingConverter))]
        public string Title { get => _title; set => Set(ref _title, value); }

        #endregion Title

        #region UpVoteCount

        private int _upVoteCount = default(int);
        [JsonProperty("up_vote_count")]
        public int UpVoteCount { get => _upVoteCount; set => Set(ref _upVoteCount, value); }

        #endregion UpVoteCount

        #region Upvoted

        private bool _upvoted = false;
        [JsonProperty("upvoted")]
        public bool Upvoted { get => _upvoted; set => Set(ref _upvoted, value); }

        #endregion Upvoted

        #region ViewCount

        private int _viewCount = default(int);
        [JsonProperty("view_count")]
        public int ViewCount { get => _viewCount; set => Set(ref _viewCount, value); }

        #endregion ViewCount

        public string GetTagsDisplay(IEnumerable<string> tags) =>
            string.Join(", ", tags);
    }
}

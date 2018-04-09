using Pyle.Core.Enums;
using Pyle.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pyle.Core.Interfaces
{
    /// <summary>
    /// The interface from which Pyle clients should inherit.
    /// </summary>
    public interface IPyleClient
    {
        IKeyProvider KeyProvider { get; set; }
        IQuotaHandler QuotaHandler { get; set; }
        ISiteProvider SiteProvider { get; set; }
        ITokenProvider TokenProvider { get; set; }

        #region Answers

        #region CRUD

        /// <summary>
        /// Gets a list of answers for a list of questions.
        /// </summary>
        /// <param name="questionIds">The ids of the questions for which to get answers.</param>
        /// <param name="filter">The filter by which to return fields.</param>
        /// <param name="page">The one-based page index.</param>
        /// <param name="pageSize">The size of the pages to get.</param>
        /// <param name="fromDate">Get only answers posted on or after this date.</param>
        /// <param name="toDate">Get only answers posted on or before this date.</param>
        /// <param name="order">The direction in which to order the answers.</param>
        /// <param name="sort">The method by which to sort the answers.</param>
        /// <returns>A response with an error or the requested answers.</returns>
        Task<ClientResponse<IEnumerable<Answer>>> GetAnswersForQuestionsAsync(
            IEnumerable<int> questionIds,
            string filter = "default",
            int page = 1,
            int pageSize = 50,
            DateTime? fromDate = null,
            DateTime? toDate = null,
            Order order = Order.Descending,
            Sort sort = Sort.Activity);

        #endregion CRUD

        #region Voting

        #region Downvoting

        /// <summary>
        /// Downvotes an answer.
        /// </summary>
        /// <param name="answerId">The id of the answer to downvote.</param>
        /// <param name="filter">The filter by which to return fields.</param>
        /// <returns>The API response.</returns>
        Task<ClientResponse<IEnumerable<Answer>>> DownvoteAnswerAsync(int answerId, string filter = "default");

        /// <summary>
        /// Undoes a downvote on an answer.
        /// </summary>
        /// <param name="answerId">The id of the answer on which to undo a downvote.</param>
        /// <param name="filter">The filter by which to return fields.</param>
        /// <returns>The API response.</returns>
        Task<ClientResponse<IEnumerable<Answer>>> UndoDownvoteAnswerAsync(int answerId, string filter = "default");

        #endregion Downvoting

        #region Upvoting

        /// <summary>
        /// Undoes an upvote on an answer.
        /// </summary>
        /// <param name="answerId">The id of the answer on which to undo an upvote.</param>
        /// <param name="filter">The filter by which to return fields.</param>
        /// <returns>The API response.</returns>
        Task<ClientResponse<IEnumerable<Answer>>> UndoUpvoteAnswerAsync(int answerId, string filter = "default");

        /// <summary>
        /// Upvotes an answer.
        /// </summary>
        /// <param name="answerId">The id of the answer to upvote.</param>
        /// <param name="filter">The filter by which to return fields.</param>
        /// <returns>The API response.</returns>
        Task<ClientResponse<IEnumerable<Answer>>> UpvoteAnswerAsync(int answerId, string filter = "default");

        #endregion Upvoting

        #endregion Voting

        #endregion Answers

        #region Inbox

        /// <summary>
        /// Gets inbox items for the user with the current access token.
        /// </summary>
        /// <param name="page">The page of items to get.</param>
        /// <param name="pageSize">The size of the pages to get.</param>
        /// <param name="since">Only get inbox items created on or after this date.</param>
        /// <returns>The API response.</returns>
        Task<ClientResponse<IEnumerable<InboxItem>>> GetInboxItemsAsync(string filter = "default", int page = 1, int pageSize = 10, DateTime? since = null);

        #endregion Inbox

        #region Questions

        #region CRUD

        /// <summary>
        /// Gets a list of questions by their ids.
        /// </summary>
        /// <param name="questionIds">The ids for which to get questions.</param>
        /// <param name="filter">The filter by which to return fields.</param>
        /// <param name="page">The page to get.</param>
        /// <param name="pageSize"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="order"></param>
        /// <param name="sort"></param>
        /// <returns></returns>
        Task<ClientResponse<IEnumerable<Question>>> GetQuestionsAsync(
            IEnumerable<int> questionIds,
            string filter = "default",
            int page = 1,
            int pageSize = 50,
            DateTime? fromDate = null,
            DateTime? toDate = null,
            Order order = Order.Descending,
            Sort sort = Sort.Activity);

        /// <summary>
        /// Get questions on a site.
        /// </summary>
        /// <param name="filter">The filter by which to return fields.</param>
        /// <param name="page">The page to get.</param>
        /// <param name="pageSize">The size of the page to get.</param>
        /// <param name="fromDate">Get only questions created on or after this date.</param>
        /// <param name="toDate">Get only questions created on or before this date.</param>
        /// <param name="order">How to order the questions.</param>
        /// <param name="sort">The method by which to sort the questions.</param>
        /// <returns>The API response.</returns>
        Task<ClientResponse<IEnumerable<Question>>> GetQuestionsAsync(
            string filter = "default",
            int page = 1,
            int pageSize = 50,
            DateTime? fromDate = null,
            DateTime? toDate = null,
            Order order = Order.Descending,
            Sort sort = Sort.Activity);

        #endregion CRUD

        #region Favoriting

        Task<ClientResponse<IEnumerable<Question>>> FavoriteQuestionAsync(int questionId, string filter = "default");
        Task<ClientResponse<IEnumerable<Question>>> UndoFavoriteQuestionAsync(int questionId, string filter = "default");

        #endregion Favoriting

        #region Voting

        #region Downvoting

        /// <summary>
        /// Downvotes an question.
        /// </summary>
        /// <param name="questionId">The id of the question to downvote.</param>
        /// <param name="filter">The filter by which to return fields.</param>
        /// <returns>The API response.</returns>
        Task<ClientResponse<IEnumerable<Question>>> DownvoteQuestionAsync(int questionId, string filter = "default");

        /// <summary>
        /// Undoes a downvote on an question.
        /// </summary>
        /// <param name="questionId">The id of the question on which to undo a downvote.</param>
        /// <param name="filter">The filter by which to return fields.</param>
        /// <returns>The API response.</returns>
        Task<ClientResponse<IEnumerable<Question>>> UndoDownvoteQuestionAsync(int questionId, string filter = "default");

        #endregion Downvoting

        #region Upvoting

        /// <summary>
        /// Undoes an upvote on an question.
        /// </summary>
        /// <param name="questionId">The id of the question on which to undo an upvote.</param>
        /// <param name="filter">The filter by which to return fields.</param>
        /// <returns>The API response.</returns>
        Task<ClientResponse<IEnumerable<Question>>> UndoUpvoteQuestionAsync(int questionId, string filter = "default");

        /// <summary>
        /// Upvotes an question.
        /// </summary>
        /// <param name="questionId">The id of the question to upvote.</param>
        /// <param name="filter">The filter by which to return fields.</param>
        /// <returns>The API response.</returns>
        Task<ClientResponse<IEnumerable<Question>>> UpvoteQuestionAsync(int questionId, string filter = "default");

        #endregion Upvoting

        #endregion Voting

        #endregion Questions

        #region Reputation

        Task<ClientResponse<IEnumerable<ReputationHistory>>> GetMyReputationHistoryFullAsync(string filter = "default");

        #endregion Reputation

        #region Sites

        /// <summary>
        /// Cache sites for offline retrieval.
        /// </summary>
        /// <param name="sites">The sites to be cached.</param>
        /// <returns></returns>
        Task CacheSitesAsync(IEnumerable<Site> sites);

        /// <summary>
        /// Get the sites which were cached for offline retrieval.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Site>> GetCachedSitesAsync();

        /// <summary>
        /// Get sites from the API.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<ClientResponse<IEnumerable<Site>>> GetSitesAsync(int page = 1, int pageSize = 500, string filter = "default");

        #endregion Sites

        #region Tags

        #region CRUD

        Task<ClientResponse<IEnumerable<Tag>>> GetTagsAsync(string query = null,
            int page = 1, int pageSize = 5, DateTime? fromDate = null, DateTime? toDate = null,
            Order order = Order.Descending, Sort sort = Sort.Activity, string filter = "default");

        #endregion CRUD

        #endregion Tags

        #region Users

        Task<ClientResponse<IEnumerable<NetworkUser>>> GetAssociatedAccountsAsync(int page = 1, int pageSize = 50, int? userId = null, string filter = "default");

        Task<ClientResponse<IEnumerable<User>>> GetMeAsync(int page = 1, int pageSize = 50, DateTime? fromDate = null, DateTime? toDate = null, string filter = "default");

        Task<ClientResponse<IEnumerable<UserTimeline>>> GetMyTimelineAsync(int page = 1, int pageSize = 50, DateTime? fromDate = null, DateTime? toDate = null, string filter = "default");

        #endregion Users
    }
}

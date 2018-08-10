using System.Collections.Generic;

namespace Pyle.Core.Enums.Maps
{
    internal static class EndpointMap
    {
        private static Dictionary<Endpoint, string> _map = new Dictionary<Endpoint, string>
        {
            [Endpoint.Answers] = "answers",
            [Endpoint.AssociatedAccounts] = "users/<user_id>/associated",
            [Endpoint.CreateQuestion] = "questions/add",
            [Endpoint.DownvoteAnswer] = "answers/<answer_id>/downvote",
            [Endpoint.DownvoteQuestion] = "questions/<question_id>/downvote",
            [Endpoint.FavoriteQuestion] = "questions/<question_id>/favorite",
            [Endpoint.Inbox] = "inbox",
            [Endpoint.Me] = "me",
            [Endpoint.MyAssociatedAccounts] = "me/associated",
            [Endpoint.MyFullReputationHistory] = "me/reputation-history/full",
            [Endpoint.MyTimeline] = "me/timeline",
            [Endpoint.QuestionAnswers] = "questions/<question_ids>/answers",
            [Endpoint.Questions] = "questions",
            [Endpoint.QuestionsById] = "questions/<question_ids>",
            [Endpoint.Sites] = "sites",
            [Endpoint.Tags] = "tags",
            [Endpoint.UndoDownvoteAnswer] = "answers/<answer_id>/downvote/undo",
            [Endpoint.UndoDownvoteQuestion] = "questions/<question_id>/downvote/undo",
            [Endpoint.UndoUpvoteAnswer] = "answers/<answer_id>/upvote/undo",
            [Endpoint.UndoUpvoteQuestion] = "questions/<question_id>/upvote/undo",
            [Endpoint.UnfavoriteQuestion] = "questions/<question_id>/favorite/undo",
            [Endpoint.UpvoteAnswer] = "answers/<answer_id>/upvote",
            [Endpoint.UpvoteQuestion] = "questions/<question_id>/upvote"
        };

        internal static string Match(Endpoint endpoint)
        {
            return _map[endpoint];
        }
    }
}

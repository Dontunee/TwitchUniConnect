using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwitchUniConnect.SharedKernel.Types;

namespace TwitchUniConnect.Social.Domain.PostAggregate
{
    public class Comment : Entity<Guid> 
    {

        #region Constructors and properties

        private List<Guid> _repliesId;



        private Comment(Guid id) : base(id)
        {

        }


        public Guid AuthorId { get; private set; }

        public string Message { get; private set; }

        public DateTime? DateCreated { get; private set; }

        public DateTime? LastModified { get; private set; }

        public IEnumerable<Guid> Replies
        {
            get
            {
                return _repliesId;
            }
        }

        #endregion

        #region Factories

        public static Comment Create(Guid id, Guid authorId, string message, DateTime? dateCreated = null,
                                        DateTime? lastModified = null, IEnumerable<Guid> replies = null)
        {
            var comment = new Comment(id);
            comment.AuthorId = authorId;
            comment.Message = message;
            comment.DateCreated = dateCreated ?? DateTime.UtcNow;
            comment._repliesId = replies != null ? replies.ToList() : new List<Guid>();
            return comment;
        }

        #endregion


        #region Public Methods

        public void EditComment(string updateMessage)
        {
            Message = updateMessage;
            LastModified = DateTime.UtcNow;
             
        }


        public void AddReply(Guid replyId)
        {
            _repliesId.Add(replyId);
        }

        public void DeleteReply(Guid replyId)
        {
            var reply = _repliesId.FirstOrDefault(r => r == replyId);

            if (reply == null)
                throw new ArgumentException("Reply not found");

            _repliesId.Remove(replyId);

        }
        #endregion
    }
}

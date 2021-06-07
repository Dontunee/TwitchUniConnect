using System;
using System.Collections.Generic;
using System.Text;
using TwitchUniConnect.SharedKernel.Interfaces;
using TwitchUniConnect.SharedKernel.Types;

namespace TwitchUniConnect.Social.Domain.PostAggregate
{
    public class Post : Entity<Guid>, IAggregateRoot
    {

        #region Constructors  and properties

        private readonly List<Uri> _mediaUrls;
        private readonly List<Comment> _comments;
        private readonly List<Interaction> _interactions;

        


        private Post(Guid id) : base(id)
        {

        }

        public PostType PostType { get; private set; }

        public string Text { get; private set; }

        public Guid Author { get;private set; }

        public IEnumerable<Uri> MediaUrl
        {
            get
            {
                return _mediaUrls;
            }
        }

        public IEnumerable<Comment> Comments
        {
            get
            {
                return _comments;
            }
        }

        public IEnumerable<Interaction> Interactions
        {
            get
            {
                return _interactions;
            }
        }

        public DateTime? DateCreated { get; private set; }

        public DateTime? LastModified { get; private set; }

        public int NumberOfInteractions
        {
            get
            {
                return _interactions.Count;
            }
        }
        public int NumberOfComments
        {
            get
            {
                return _comments.Count;
            }
        }

        #endregion
    }
}

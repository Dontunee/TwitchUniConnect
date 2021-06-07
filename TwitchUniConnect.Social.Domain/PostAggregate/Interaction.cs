using System;
using System.Collections.Generic;
using System.Text;
using TwitchUniConnect.SharedKernel.Types;

namespace TwitchUniConnect.Social.Domain.PostAggregate
{
    public class Interaction : ValueObject
    {
        public Interaction()
        {

        }

        public InteractionType Type { get; private set; }
        public Guid AuthorId { get; private set; }


        #region Factories

        public static Interaction Create(InteractionType type, Guid authorId)
        {
            return new Interaction
            {
                Type = type,
                AuthorId = authorId
            };
        }

        #endregion


        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Type;
            yield return AuthorId;
        }


    }
}

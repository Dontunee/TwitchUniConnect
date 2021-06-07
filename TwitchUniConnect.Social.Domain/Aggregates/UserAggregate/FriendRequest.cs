 using System;
using System.Collections.Generic;
using System.Text;
using TwitchUniConnect.SharedKernel.Types;

namespace TwitchUniConnect.Social.Domain.Aggregates.UserAggregate
{
    public class FriendRequest : ValueObject
    {

        private FriendRequest()
        {

        }

        public Guid FromId { get; private set; }

        public Guid ToId { get; private set; }

        public DateTime DateSent { get; private set; }

        public static FriendRequest Create(Guid from, Guid to)
        {
            return new FriendRequest()
            {
                FromId = from,
                ToId = to,
                DateSent = DateTime.UtcNow
            };
        }


        #region Base Class Override
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FromId;
            yield return ToId;
        }
        #endregion
    }
}

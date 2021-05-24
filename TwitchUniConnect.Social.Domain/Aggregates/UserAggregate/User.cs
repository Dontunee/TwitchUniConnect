using System;
using System.Collections.Generic;
using System.Text;
using TwitchUniConnect.SharedKernel.Interfaces;
using TwitchUniConnect.SharedKernel.Types;

namespace TwitchUniConnect.Social.Domain.Aggregates.UserAggregate
{
    public class User : Entity<Guid>, IAggregateRoot
    {
        #region Constructors and properties
        private User() : base(Guid.NewGuid()) { }

        private User(Guid id ) : base(id)
        {

        }


        public string Username { get; private set; }

        public string Password { get; private set; }

        public UserType Type { get; private set; }

        public Name Name { get; private set; }

        #endregion


    }
}

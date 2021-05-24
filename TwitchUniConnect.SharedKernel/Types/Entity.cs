using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TwitchUniConnect.SharedKernel.Types
{
    public abstract class Entity<TId> : IEquatable<Entity<TId>>
    {
        #region Constructors and properties 

        protected Entity(TId id)
        {
            if (!IsIdValid(id)) throw new ArgumentException();
            Id = id;
        }

        public TId Id { get; private set; }


        #endregion


        #region IEquatable implementation

        public bool Equals(Entity<TId> other)
        {
            return Id.GetHashCode() == other.Id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Entity<TId>);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public static bool operator ==(Entity<TId> lhs, Entity<TId> rhs)
        {

            return lhs.Equals(rhs);
        }

        public static bool operator !=(Entity<TId> lhs, Entity<TId> rhs)
        {
            return !(lhs == rhs);
        }


        #endregion

        #region Private methods 

        private bool IsIdValid(TId id)
        {
            return id is int || id is Guid;
        }

        #endregion






    }
}

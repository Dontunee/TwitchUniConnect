using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace TwitchUniConnect.SharedKernel.Types
{
    public abstract class Enumeration : IComparable, IEquatable<Enumeration>
    {
        #region Constructors and properties 
        public Enumeration(int value, string description)
        {
            Value = value;
            Description = description;
        }

        public int Value { get; private set; }

        public string Description { get; private set; }
        #endregion  


        #region IComparable implementations 
        public int CompareTo(object obj)
        {
            return Value.CompareTo(((Enumeration)obj).Value);
        }
        #endregion


        #region IEquatable implementations 

        public bool Equals(Enumeration other)
        {
            if (other == null)
                return false;

            var typeMatches = GetType().Equals(other.GetType());
            var valueMatches = Value.Equals(other.Value);

            return typeMatches && valueMatches;
        }

        public override bool Equals(object obj)
        {
            var otherValue = obj as Enumeration;

            if (otherValue == null)
                return false;

            return Equals(otherValue);
        }


        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(Enumeration left, Enumeration right)
        {
            if (ReferenceEquals(left, null)
                    ^ ReferenceEquals(right, null))
                return false;

            return ReferenceEquals(left, null) || left.Equals(right);
        }

        public static bool operator !=(Enumeration left, Enumeration right)
        {
            return !(left == right);
        }

        #endregion

        public override string ToString()
        {
            return Description;
        }

    }
}

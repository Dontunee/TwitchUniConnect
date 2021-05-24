using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace TwitchUniConnect.SharedKernel.Types
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        protected abstract IEnumerable<object> GetAtomicValues();

        #region IEquatable implementations 
        public bool Equals(ValueObject other)
        {
            if (other == null || other.GetType() != GetType())
                return false;

            //getValues in Enumerator of this value object 
            var thisValues = GetAtomicValues().GetEnumerator();

            //get values in Enumerator of input value object
            var otherValues = other.GetAtomicValues().GetEnumerator();

            while(thisValues.MoveNext() && otherValues.MoveNext())
            {
                //null check for reference values
                if (ReferenceEquals(thisValues.Current, null)
                        ^ ReferenceEquals(otherValues.Current, null))
                    return false;

                //check if current object value isnt empty and other value doesnt equal it
                if (thisValues.Current != null
                        && !thisValues.Current.Equals(otherValues.Current))
                    return false;

            }

            return !thisValues.MoveNext() && otherValues.MoveNext();
        }


        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;

            return Equals(obj as ValueObject);
        }

        public override int GetHashCode()
        {
            return GetAtomicValues()
                        .Select(x => x != null ? x.GetHashCode() : 0)
                            .Aggregate((x, y) => x ^ y);
        }

        public static bool operator ==(ValueObject leftHand, ValueObject rightHand)
        {
            //returns true only if one of them is null and the other isnt 
            //wont return true if both are null
            if (ReferenceEquals(leftHand, null) ^
                    ReferenceEquals(rightHand, null))
                return false;


            //if left isnt null,return comparison of left and right
            return ReferenceEquals(leftHand, null) || leftHand.Equals(rightHand);
        }

        public static bool operator !=(ValueObject leftHand, ValueObject rightHand)
        {
            return !(leftHand == rightHand);
        }


        #endregion


    }
}

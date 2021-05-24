using System;
using System.Collections.Generic;
using System.Text;
using TwitchUniConnect.SharedKernel.Types;

namespace TwitchUniConnect.Social.Domain.Aggregates.UserAggregate
{
    public class Name : ValueObject
    {

        #region Constructors and properties 
        private Name() { }

        private Name (string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
            Initials = firstName[0].ToString().ToUpperInvariant() + "." + LastName[0].ToString().ToUpperInvariant();
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        public string Initials { get; private set; }

        #endregion

        #region Factories
        
        public static Name Create(string firstName, string lastName)
        {
            return new Name(firstName, lastName);
        }

        #endregion

        #region Public Methods
        
        public Name ChangeFirstName(string newFirstName)
        {
            //Value objects should be immutable and must be recreated to make a change
            return new Name(newFirstName, LastName);
        }

        public Name ChangeLastName(string newLastName)
        {
            return new Name(FirstName, newLastName);
        }

        #endregion

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}

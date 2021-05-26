using System;
using System.Collections.Generic;
using System.Text;
using TwitchUniConnect.SharedKernel.Types;

namespace TwitchUniConnect.Social.Domain.Aggregates.UserAggregate
{
    public class Department : ValueObject
    {
        #region Constructors and properties
        private Department(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public string Name { get; private set; }

        public string Description { get; private set; }


        #endregion

        #region Factories

        public static Department Create(string name, string description)
        {
            return new Department(name, description);
        }

        #endregion

        #region Public Methods

        public Department ChangeDepartmentName(string name)
        {
            //after validation 
            return Create(name, Description);
        }

        public Department ChangeDepartmentDescription(string description)
        {
            //after validation
            return Create(Name, description);
        }


        public Department EditDepartment(string newName, string newDescription)
        {
            return Create(newName, newDescription);
        }
        #endregion


        #region Base class Overrides
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return Name;
            yield return Description;
        }

        #endregion
    }
}

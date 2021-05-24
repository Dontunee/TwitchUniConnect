using System;
using System.Collections.Generic;
using System.Text;
using TwitchUniConnect.SharedKernel.Types;

namespace TwitchUniConnect.Social.Domain.Aggregates.UserAggregate
{
    public class UserType : Enumeration
    {
        #region Constructors and properties 
        public static readonly UserType Student = new UserType(0, "Student");
        public static readonly UserType Teacher = new UserType(1, "Teacher");
        public static readonly UserType Staff = new UserType(2, "Staff");



        private UserType(int value, string description) : base(value, description) { }

        #endregion
    }
}

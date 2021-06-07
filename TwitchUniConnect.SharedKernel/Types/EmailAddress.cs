using System;
using System.Collections.Generic;
using System.Text;

namespace TwitchUniConnect.SharedKernel.Types
{
    public class EmailAddress : ValueObject
    {

        private EmailAddress()
        {

        }

        public string EmailName { get; private set; }

        public string Domain { get; private set; }

        public static EmailAddress Create(string emailName, string domain)
        {
            //To do validation 
            return new EmailAddress()
            {
                EmailName = emailName,
                Domain = domain
            };
        }


        #region Base Class Overrides
        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return EmailName;
            yield return Domain;
        }

        #endregion

        public override string ToString()
        {
            return string.Concat(EmailName, "@", Domain);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TwitchUniConnect.SharedKernel.Types;

namespace TwitchUniConnect.Social.Domain.Aggregates.UserAggregate
{
    public class Degree : Enumeration
    {
        public static readonly Degree Bachelor = new Degree(0, "Bachelor's");

        public static readonly Degree Master = new Degree(1, "Master's");

        public static readonly Degree Doctorate = new Degree(2, "Doctorate");

        public static readonly Degree PostDoctorate = new Degree(3, "Post-Doctorate Research");

        private Degree(int value, string description) : (value,description)
        {

        }
    }
}

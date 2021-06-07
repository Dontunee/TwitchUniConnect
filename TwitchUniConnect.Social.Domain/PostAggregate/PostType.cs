﻿using System;
using System.Collections.Generic;
using System.Text;
using TwitchUniConnect.SharedKernel.Types;

namespace TwitchUniConnect.Social.Domain.PostAggregate
{
    public class PostType : Enumeration
    {


        public static readonly PostType Text = new PostType(0, "Test post");

        public static readonly PostType Video = new PostType(1, "Video post");

        public static readonly PostType Photo = new PostType(2, "Photo post");
        private PostType(int value, string description) : base(value, description) { }


    }
}

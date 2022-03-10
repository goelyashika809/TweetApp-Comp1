using System;

namespace TweetApp.Models
{
    public class Tweet
    {
        public int Id { get; set; }

        public int User_Id { get; set; }

        public string Email { get; set; }

        public string Tweet_Content { get;set ;}

        public DateTime Created_On { get; set; }
    }
}

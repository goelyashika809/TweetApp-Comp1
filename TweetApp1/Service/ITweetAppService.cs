using TweetApp.Models;
using System.Collections.Generic;

namespace TweetApp.Service
{
    public interface ITweetAppService
    {
        public List<Tweet> GetUserTweet(string email);
        public List<Tweet> GetTweets();
        public string AddTweet(Tweet tweet);
        public string Register(User user);
        public User Login(string email, string password);
        public string Password_Forget(string email, string password);
        public string Password_Reset(string email, string newPassword);
        public List<User> GetUsers();
    }
}

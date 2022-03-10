using TweetApp.Models;
using System.Collections.Generic;

namespace TweetApp.Dao
{
    public interface ITweetAppDao
    {
        public List<Tweet> GetUserTweets(string email);
        public List<Tweet> GetTweets();
        public int AddTweet(Tweet tweet);
        public User UserValidation(string emailId);
        public int Register(User user);
        public User Login(string email, string password);
        public int Password_Forget(string email, string password);
        public int Password_Reset(string email, string newPassword);
        public List<User> GetUsers();
    }
}

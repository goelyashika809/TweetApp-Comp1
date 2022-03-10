using System.Collections.Generic;
using System.Threading.Tasks;
using TweetApp.Dao;
using TweetApp.Models;

namespace TweetApp.Service
{
    public class TweetAppService : ITweetAppService
    {
        private readonly ITweetAppDao _dao;

        public TweetAppService(ITweetAppDao dao)
        {
            this._dao = dao;
        }

        public List<Tweet> GetUserTweet(string email)
        {
            return _dao.GetUserTweets(email);
        }

        public List<Tweet> GetTweets()
        {
            return _dao.GetTweets();
        }

        public string AddTweet(Tweet tweet)
        {
            if (_dao.AddTweet(tweet) > 0)
            {
                return "Tweet Added";
            }
            else
            {
                return "Tweet not added";
            }
        }

        public string  Register(User user)
        {
            if (_dao.UserValidation(user.Email) == null)
            {
                if (_dao.Register(user) > 0)
                {
                    return "Registered";
                }
                else
                {
                    return "Not Registered";
                }
            }
            return "Email exists";
        }
        public User Login(string email, string password)
        {
            return _dao.Login(email, password);
        }
        public string Password_Forget(string email, string password)
        {
            if (_dao.UserValidation(email) != null)
            {
                if (_dao.Password_Forget(email, password) > 0)
                {
                    return "Password Changed";
                }
                else
                {
                    return "Password cannot be changed";
                }
            }
            return "Email doesnt exist";
        }

        public string Password_Reset(string email, string newPassword)
        {
            if (_dao.Password_Reset(email, newPassword) > 0)
            {
                return "Password changed";
            }
            else
            {
                return "Password cannot be changed";
            }
        }

        public List<User> GetUsers()
        {
            return _dao.GetUsers();
        }
    }
}

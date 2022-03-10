using System;
using System.Linq;
using System.Collections.Generic;
using TweetApp.Models;

namespace TweetApp.Dao
{
    public class TweetAppDao : ITweetAppDao
    {
        private AppDbContext _context;

        public TweetAppDao(AppDbContext context)
        {
            _context = context;
        }

        public List<Tweet> GetUserTweets(string email)
        {
            try
            {
                return (from tweet in _context.Tweet
                                join user in _context.User on tweet.User_Id equals user.Id
                                where user.Email == email
                                select new Tweet
                                {
                                    Id = tweet.Id,
                                    User_Id = user.Id,
                                    Email = user.Email,
                                    Tweet_Content = tweet.Tweet_Content,
                                    Created_On = tweet.Created_On,
                                }).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<Tweet> GetTweets()
        {
            try
            {
                return (from tweet in _context.Tweet
                                                    join user in _context.User on tweet.User_Id equals user.Id
                                                    select new Tweet
                                                    {
                                                        Id = tweet.Id,
                                                        User_Id = user.Id,
                                                        Email = user.Email,
                                                        Tweet_Content = tweet.Tweet_Content,
                                                        Created_On = tweet.Created_On,
                                                    }).ToList();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public int AddTweet(Tweet tweets)
        {
            try
            {
                _context.Tweet.Add(tweets);
                return this._context.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public int Register(User user)
        {
            try
            {
                _context.User.Add(user);
                return _context.SaveChanges();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public User Login(string email, string password)
        {
            try
            {
                return _context.User.FirstOrDefault(e => e.Email == email && e.Password == password);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public User UserValidation(string email)
        {
            try
            {
                return _context.User.FirstOrDefault(x => x.Email == email);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public int Password_Forget(string email, string password)
        {
            try
            {
                var result = _context.User.FirstOrDefault(s => s.Email == email);
                if (result != null)
                {
                    result.Password = password;
                    _context.Update(result);
                    return _context.SaveChanges();
                }

                return 0;
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }

        public int Password_Reset(string email, string newPassword)
        {
            try
            {
                var result = _context.User.FirstOrDefault(s => s.Email == email);
                if (result != null)
                {
                    result.Password = newPassword;
                    _context.Update(result);
                    return _context.SaveChanges();
                }

                return 0;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public List<User> GetUsers()
        {
            return _context.User.Select(p => new User
            {
                First_Name = p.First_Name,
                Last_Name = p.Last_Name,
                Email = p.Email
            }).ToList();
        }
    }
}

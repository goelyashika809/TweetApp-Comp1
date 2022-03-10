using TweetApp.Models;
using TweetApp.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace TweetApp.Controller
{
    [Route("api/TweetApp/")]
    [ApiController]
    public class TweetAppController : ControllerBase
    {
        private readonly ITweetAppService service;
        private readonly IConfiguration config;

        public TweetAppController(ITweetAppService service, IConfiguration config)
        {
            this.service = service;
            this.config = config;
        }

        [HttpGet]
        [Route("GetUserTweets")]
        public ActionResult GetUserTweets(string email)
        {
                return this.Ok(this.service.GetUserTweet(email));
        }

        [HttpGet]
        [Route("GetTweets")]
        public ActionResult GetTweets()
        {
            return this.Ok(this.service.GetTweets());
        }

        [HttpPost]
        [Route("AddTweet")]
        public ActionResult AddTweet([FromBody] Tweet tweets)
        {
                return this.Ok(this.service.AddTweet(tweets));
        }

        [HttpPost]
        [Route("Register")]
        public ActionResult Register([FromBody] User users)
        {
                return this.Ok(this.service.Register(users));
        }

        [HttpGet]
        [Route("Login")]
        public ActionResult Login(string email, string password)
        {
            AuthenticationController authenticate = new AuthenticationController(config);
            if (this.service.Login(email, password) != null)
            {
                return this.Ok(authenticate.GenerateJwtToken(email));
            }
            return this.Ok(null);
        }

        [HttpPut]
        [Route("Password_Forget")]
        public ActionResult Password_Forget(string email, string password)
        {
            return this.Ok(this.service.Password_Forget(email, password));
        }

        [HttpPut]
        [Route("Password_Reset")]
        public ActionResult Password_Reset(string email, string newPassword)
        {
            return this.Ok(this.service.Password_Reset(email, newPassword));
        }

        [HttpGet]
        [Route("GetUsers")]
        public ActionResult GetUsers()
        {
            return this.Ok(this.service.GetUsers());
        }
    }
}

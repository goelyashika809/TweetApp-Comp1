﻿using System;

namespace TweetApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

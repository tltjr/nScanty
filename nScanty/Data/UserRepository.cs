﻿using System;
using System.Configuration;
using System.Web.Security;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;

namespace nScanty.Data
{
    public class UserRepository
    {
        private readonly MongoCollection<User> _collection;

        public UserRepository()
        {
	        string connection = ConfigurationManager.AppSettings["env"].Equals("local") ? "mongodb://localhost/Users" : ConnectionString.MongoLab;
            var database = MongoDatabase.Create(connection);
            _collection = database.GetCollection<User>("Users");
        }

        public MembershipUser CreateUser(string username, string password)
        {
            var user = new User
                           {
                               UserName = username,
                               Email = string.Empty,
                               Password = BCrypt.HashPassword(password, BCrypt.GenerateSalt()),
                               CreatedDate = DateTime.Now,
                               IsActivated = false,
                               IsLockedOut = false,
                               LastLockedOutDate = DateTime.Now,
                               LastLoginDate = DateTime.Now
                           };

            _collection.Insert(user);
            return GetUser(username);
        }

		public MembershipUser CreateUserWithHashedPassword(string username, string hashedPassword)
		{
            var user = new User
                           {
                               UserName = username,
                               Email = string.Empty,
                               Password = hashedPassword,
                               CreatedDate = DateTime.Now,
                               IsActivated = false,
                               IsLockedOut = false,
                               LastLockedOutDate = DateTime.Now,
                               LastLoginDate = DateTime.Now
                           };

            _collection.Insert(user);
            return GetUser(username);
		}

        public string GetUserNameByEmail(string email)
        {
            var query = Query.EQ("Email", email);
            var result = _collection.FindOne(query);
            return result != null ? result.UserName : String.Empty;
        }

        public MembershipUser GetUser(string username)
        {
            var query = Query.EQ("UserName", username);
            var user = _collection.FindOne(query);
            if (null == user) return null;
            return new MembershipUser("CustomMembershipProvider",
                                                      user.UserName,
                                                      user.Id,
                                                      user.Email,
                                                      "",
                                                      user.Comments,
                                                      user.IsActivated,
                                                      user.IsLockedOut,
                                                      user.CreatedDate,
                                                      user.LastLoginDate,
                                                      DateTime.Now,
                                                      DateTime.Now,
                                                      user.LastLockedOutDate);
        }

        public bool ValidateUser(string username, string password)
        {
            var query = Query.EQ("UserName", username);
            var user = _collection.FindOne(query);
	        if (user == null)
		        return false;
	        var passwordMatched = BCrypt.CheckPassword(password, user.Password);
	        return passwordMatched;
        }
    }

    public class User
    {
        public ObjectId Id { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsActivated { get; set; }

        public bool IsLockedOut { get; set; }

        public DateTime LastLockedOutDate { get; set; }

        public DateTime LastLoginDate { get; set; }

        public string Comments { get; set; }
    }
}
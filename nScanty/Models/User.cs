using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace nScanty.Models
{
    public class User
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsActivated { get; set; }

        public bool IsLockedOut { get; set; }

        public DateTime LastLockedOutDate { get; set; }

        public DateTime LastLoginDate { get; set; }

        public int UserId { get; set; }

        public string Comments { get; set; }
    }
}
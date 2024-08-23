using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCC.Models
{
    public class User
    {
        [Key]
        public string UserId { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTime? LockoutEndDateUtc { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public string UserName { get; set; }
        public string Discriminator { get; set; }

        // 對應的 Category 對象
        //public virtual Category Category { get; set; }

        public User()
        {
            UserId = string.Empty;
            Email = null;
            EmailConfirmed = false;
            PasswordHash = null;
            SecurityStamp = null;
            PhoneNumber = null;
            PhoneNumberConfirmed = false;
            TwoFactorEnabled = false;
            LockoutEndDateUtc = null;
            LockoutEnabled = true;
            AccessFailedCount = 0;
            UserName = string.Empty;
            Discriminator = string.Empty;
        }
        public User(string _userId, string _email, bool _emailConfirmed, string _passwordHash,
                    string _securityStamp, string _phoneNumber, bool _phoneNumberConfirmed,
                    bool _twoFactorEnabled, DateTime? _lockoutEndDateUtc, bool _lockoutEnabled,
                    int _accessFailedCount, string _userName, string _discriminator)
        {
            UserId = _userId;
            Email = _email;
            EmailConfirmed = _emailConfirmed;
            PasswordHash = _passwordHash;
            SecurityStamp = _securityStamp;
            PhoneNumber = _phoneNumber;
            PhoneNumberConfirmed = _phoneNumberConfirmed;
            TwoFactorEnabled = _twoFactorEnabled;
            LockoutEndDateUtc = _lockoutEndDateUtc;
            LockoutEnabled = _lockoutEnabled;
            AccessFailedCount = _accessFailedCount;
            UserName = _userName;
            Discriminator = _discriminator;
        }
    }
}
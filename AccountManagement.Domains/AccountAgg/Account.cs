using _01_Framework.Domain;
using _01_Framework.Infrastructure;
using AccountManagement.Domain.RoleAgg;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.AccountAgg
{
    public class Account:EntityBase
    {
        public string Fullname { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Mobile { get; private set; }
        public string ProfilePhoto { get; private set; }
        public bool IsDeleted { get; private set; }

        public long RoleId { get; private set; }
        public Role Role { get; private set; }


        public Account(string fullname, string username, string password, string mobile, string profilePhoto, long roleId)
        {
            Fullname = fullname;
            Username = username;
            Password = password;
            Mobile = mobile;
            if (string.IsNullOrEmpty(profilePhoto))
                profilePhoto = "Account/UserDefaultLogo.png";
            ProfilePhoto = profilePhoto;
            IsDeleted = false;

            if (roleId == 0)
                roleId = 2;
            RoleId = roleId;
        }

        public void Edit(string fullname, string username, string mobile, string profilePhoto , long roleid)
        {
            Fullname = fullname;
            Username = username;
            Mobile = mobile;
            ProfilePhoto = profilePhoto;

            if (roleid == 0)
                roleid = 2;
            RoleId = roleid;
        }

        public void Delete() 
        {
            IsDeleted = true;
        }
        public void Restore()
        {
            IsDeleted = false;
        }
        public void ChangePassword(string password)
        {
            Password = password;
        }
    }
}

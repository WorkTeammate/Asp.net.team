using _0_Framework.Domain;
using AccountManagement.Domain.RoleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Domain.AccountAgg
{
    public class Account : EntityBase
    {
        public string FullName { get; private set; }
        public string UserName { get; private set; }
        public string Gmail { get; private set; }
        public string MobileNumber { get; private set; } 
        public long RoleId { get; private set; }
        public Role Role { get; private set; }
        public string Password { get; private set; }
        public string ProfilePicture { get; private set; }
        public bool IsDeleted { get; private set; }

        public const string NotSet = "وارد نشده است";
        public const string Profile = "https://upload.wikimedia.org/wikipedia/commons/9/99/Sample_User_Icon.png";
        protected Account()
        {

        }

        public Account(string fullName, string gmail, string mobileNumber, string password, string profilePicture, long roleId, string username)
        {
            FullName = fullName = NotSet;
            Gmail = gmail = NotSet;
            MobileNumber = mobileNumber = NotSet;
            Password = password = NotSet;
            ProfilePicture = profilePicture = Profile;
            IsDeleted = false;
            UserName = username = NotSet;
            RoleId = roleId;
            if (roleId == 0)
                RoleId = 2;
        }


        public void Edit(string fullName, string gmail, string mobileNumber, string profilePicture, long roleId, string username)
        {
            FullName = fullName = NotSet;
            Gmail = gmail = NotSet;
            MobileNumber = mobileNumber = NotSet;
            ProfilePicture = profilePicture = Profile;
            UserName = username = NotSet;
            RoleId = roleId;

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

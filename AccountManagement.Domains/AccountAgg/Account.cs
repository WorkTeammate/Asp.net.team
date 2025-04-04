using _01_Framework.Domain;
using AccountManagement.Domain.RoleAgg;

namespace Market.AccountManagement.Domain.AccountAgg
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

        public void Edit(string fullname, string username, string mobile , long roleid)
        {
            Fullname = fullname;
            Username = username;
            Mobile = mobile;

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
        public void ChangeProfilePicture(string profile)
        {
            ProfilePhoto = profile;
        }
    }
}

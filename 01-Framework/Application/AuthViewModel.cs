﻿namespace _0_Framework.Application
{
    public class AuthViewModel
    {
        public long Id { get; set; }
        public long RoleId { get; set; }
        public string Role { get; set; }

        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Picture { get; set; }
        public string Gmail { get; set; }
        public List<long> Permissions { get; set; }

        public AuthViewModel(){  }

        public AuthViewModel(long id, long roleId, string fullName, string userName,string picture ,string gmail,List<long> permissions)
        {
            Id = id;
            RoleId = roleId;
            FullName = fullName;
            UserName = userName;
            Gmail= gmail;
            Picture = picture;
            Permissions = permissions;
        }   
    }
}

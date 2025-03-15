namespace AccountManagement.Application.Contracts.Account
{
    public class AccountViewModel
    {
        public long Id { get; set; }
        public string Password { get; set; }
        public string ProfilePicture { get; set; }
        public string Fullname { get; set; }
        public string Username { get; set; }
        public string MobileNumber { get; set; }
        public string Gmail { get; set; }
        public string CreationDate { get; set; }
        public long RoleId { get; set; }
        public string Role { get; set; }
    }
}

namespace AccountManagement.Domain.RoleAgg
{
    public class Permission
    {
        public long Id { get; private set; }
        public long Code { get; private set; }
        public string Name { get; private set; }
        public long RoleId { get; private set; }
        public Role Role { get; private set; }

        public Permission(long code)
        {
            Code = code;
        }

        public Permission(int code, string name)
        {
            Code = code;
            Name = name;
        }
    }
}

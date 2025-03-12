namespace _0_Framework.Infrastructure
{
    public class PermissionDto
    {
        public string Name { get; set; }
        public long Code { get; set; }

        public PermissionDto(long code , string name)
        {
            Name = name;
            Code = code;
        }
    }
}

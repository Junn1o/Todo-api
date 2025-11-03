namespace Todo_api.Models.Domain
{
    public class Role
    {
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public List<User_Role> User_Roles { get; set; }
    }
}

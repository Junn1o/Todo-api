using System.ComponentModel.DataAnnotations;

namespace Todo_api.Models.Domain
{
    public class User_Role
    {
        [Key]
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
        public User Users { get; set; }
        public Role Roles { get; set; }
    }
}

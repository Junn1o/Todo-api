using System.ComponentModel.DataAnnotations;

namespace Todo_api.Models.Domain
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        public required string TeamName { get; set; }
        // One Team have many TeamUser
        public required List<Team_User> TeamUsers { get; set; }
        public List<Category> Categories { get; set; } //New
    }
}

using Microsoft.EntityFrameworkCore;
using Todo_api.Models.Domain;

namespace Todo_api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Sub_Task> Sub_Tasks { get; set; }
        public DbSet<Models.Domain.Task> Tasks { get; set; }
        public DbSet<Task_Assignee> Tasks_Assignee { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<Team_User> Team_Users { get; set; }
    }
}

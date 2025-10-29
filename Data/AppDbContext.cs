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
            //Category 1-n Task
            modelBuilder.Entity<Todo_api.Models.Domain.Task>()
                .HasOne(c => c.Category)
                .WithMany(ca => ca.Tasks)
                .HasForeignKey(c => c.CategoryID);

            //Task 1-n Category
            modelBuilder.Entity<Todo_api.Models.Domain.Category>()
                .HasOne(c => c.User)
                .WithMany(ca => ca.Categories)
                .HasForeignKey(c => c.UserId);

            //Task 1-n Sub_Task
            modelBuilder.Entity<Todo_api.Models.Domain.Sub_Task>()
                .HasOne(c => c.Task)
                .WithMany(ca => ca.SubTasks)
                .HasForeignKey(c => c.TaskId);

            //Team 1-n Category
            modelBuilder.Entity<Todo_api.Models.Domain.Category>()
                .HasOne(c => c.Team)
                .WithMany(ca => ca.Categories)
                .HasForeignKey(c => c.TeamId);

            //User 1-n Task
            modelBuilder.Entity<Todo_api.Models.Domain.Task>()
                .HasOne(c => c.User)
                .WithMany(ca => ca.Tasks)
                .HasForeignKey(c => c.UserId);

            //Task_Assignee 1-1 Task
            modelBuilder.Entity<Todo_api.Models.Domain.Task_Assignee>()
                .HasOne(c => c.Task)
                .WithOne(ca => ca.Task_Assignee)
                .HasForeignKey<Task_Assignee>(ca => ca.TaskId); //<-Entity Phu Thuoc

            //Team_User 1-n Task_Assignee
            modelBuilder.Entity<Todo_api.Models.Domain.Task_Assignee>()
                .HasOne(c => c.Team_User)
                .WithMany(ca => ca.Assignees)
                .HasForeignKey(c => c.UserId);

            //Team 1-n Team_User
            modelBuilder.Entity<Todo_api.Models.Domain.Team_User>()
                .HasOne(c => c.Team)
                .WithMany(ca => ca.TeamUsers)
                .HasForeignKey(c => c.TeamId);

            //User 1-n Team_User
            modelBuilder.Entity<Todo_api.Models.Domain.Team_User>()
                .HasOne(c => c.User)
                .WithMany(ca => ca.Users)
                .HasForeignKey(c => c.TeamId);
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

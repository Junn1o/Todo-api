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
            modelBuilder.Entity<User>()
                .HasMany(c => c.Categories)
                .WithOne(u => u.User)
                .HasForeignKey(ui => ui.UserId);
            modelBuilder.Entity<User>()
                .HasMany(t => t.Tasks)
                .WithOne(u => u.User)
                .HasForeignKey(ui => ui.UserId);
            modelBuilder.Entity<Models.Domain.Task>()
                .HasMany(st => st.SubTasks)
                .WithOne(t => t.Task)
                .HasForeignKey(ti=>ti.TaskId);
            modelBuilder.Entity<Category>()
                .HasMany(t => t.Tasks)
                .WithOne(t => t.Category)
                .HasForeignKey(ci => ci.CategoryId);
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Sub_Task> Sub_Tasks { get; set; }
        public DbSet<Models.Domain.Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
    }
}

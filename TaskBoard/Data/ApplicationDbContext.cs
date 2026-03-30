using Microsoft.EntityFrameworkCore;
using TaskBoard.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace TaskBoard.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Models.TaskItem> TaskItems { get; set; }

        //Seeding DB with dummy data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Models.TaskItem>().HasData(
                new Models.TaskItem { Id = 1, Title = "Task 1", Description = "Description for Task 1", CurrentStatus = Models.TaskStatus.ToDo },
                new Models.TaskItem { Id = 2, Title = "Task 2", Description = "Description for Task 2", CurrentStatus = Models.TaskStatus.ToDo },
                new Models.TaskItem { Id = 3, Title = "Task 3", Description = "Description for Task 3", CurrentStatus = Models.TaskStatus.ToDo }
            );
        }

    }
}

using Microsoft.EntityFrameworkCore;

namespace TaskBoard.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Models.TaskItem> TaskItems { get; set; }

    }
}

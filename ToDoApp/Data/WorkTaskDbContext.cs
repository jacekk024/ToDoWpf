using Microsoft.EntityFrameworkCore;
using ToDoApp.Model;

namespace ToDoApp.Data
{
    public class WorkTaskDbContext : DbContext
    {
        public DbSet<WorkTask> WorkTasks { get; set; }
        private readonly string path = "Server=(localdb)\\mssqllocaldb;Database=WorkTasksDb;Trusted_Connection=True;";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(path);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeldatRecruitmentExercise.Models;

namespace TeldatRecruitmentExercise.Data
{
    public class WorkTaskDbContext : DbContext
    {
        public DbSet<WorkTask> WorkTasks { get; set; }
        private string path = "Server=(localdb)\\mssqllocaldb;Database=WorkTasksDb;Trusted_Connection=True;"; 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(path);
        }
    }
}

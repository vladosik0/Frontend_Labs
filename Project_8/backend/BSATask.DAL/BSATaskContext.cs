using BSATask.DAL.Entities;
using BSATask.DAL.Extensions;
using Microsoft.EntityFrameworkCore;
using Task = BSATask.DAL.Entities.Task;

namespace BSATask.DAL
{
    public class BSATaskContext : DbContext
    {
        public BSATaskContext(DbContextOptions<BSATaskContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Configure();

            modelBuilder.Seed();
        }

        public DbSet<Project> Projects { get; private set; }
        public DbSet<User> Users { get; private set; }
        public DbSet<Task> Tasks { get; private set; }
        public DbSet<Team> Teams { get; private set; }
    }
}

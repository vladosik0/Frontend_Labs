using Bogus;
using BSATask.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Task = BSATask.DAL.Entities.Task;

namespace BSATask.DAL.Extensions
{
    public static class ModelBuilderExtensions
    {
        private const int ENTITY_COUNT = 10;
        public static void Configure(this ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureTeams();
            modelBuilder.ConfigureProjects();
            modelBuilder.ConfigureUsers();
            modelBuilder.ConfigureTasks();
        }

        public static void ConfigureTeams(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                .Property(t => t.Id)
                .IsRequired()
                .ValueGeneratedNever();

            modelBuilder.Entity<Team>()
                .Property(t => t.Name)
                .IsRequired();

            modelBuilder.Entity<Team>()
                .Property(t => t.CreatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Team>()
                .HasMany(t => t.Projects)
                .WithOne(p => p.Team)
                .HasForeignKey(p => p.TeamId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<Team>()
                .HasMany(t => t.Users)
                .WithOne(u => u.Team)
                .HasForeignKey(u => u.TeamId)
                .OnDelete(DeleteBehavior.SetNull);

        }

        public static void ConfigureUsers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(u => u.Id)
                .IsRequired()
                .ValueGeneratedNever();

            modelBuilder.Entity<User>()
                .Property(u => u.RegisteredAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<User>()
                .HasMany(u => u.Projects)
                .WithOne(p => p.Author)
                .HasForeignKey(p => p.AuthorId)
                .OnDelete(DeleteBehavior.ClientCascade);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Tasks)
                .WithOne(t => t.Performer)
                .HasForeignKey(t => t.PerformerId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }

        public static void ConfigureProjects(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedNever();

            modelBuilder.Entity<Project>()
                .Property(t => t.Name)
                .IsRequired();

            modelBuilder.Entity<Project>()
                .Property(p => p.CreatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Tasks)
                .WithOne(t => t.Project)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.ClientCascade);
        }

        public static void ConfigureTasks(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>()
                .Property(t => t.Id)
                .IsRequired()
                .ValueGeneratedNever();

            modelBuilder.Entity<Task>()
                .Property(t => t.Name)
                .IsRequired();

            modelBuilder.Entity<Task>()
                .Property(t => t.CreatedAt)
                .HasDefaultValueSql("getdate()");
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            var teams = GenerateRandomTeams();
            var users = GenerateRandomUsers(teams);
            var projects = GenerateRandomProjects(teams, users);
            var tasks = GenerateRandomTasks(users, projects);

            modelBuilder.Entity<Team>().HasData(teams);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<Project>().HasData(projects);
            modelBuilder.Entity<Task>().HasData(tasks);
        }


        public static List<Team> GenerateRandomTeams()
        {
            int teamId = 1;

            return new Faker<Team>()
                .RuleFor(t => t.Id, f => teamId++)
                .RuleFor(t => t.Name, f => f.Company.CompanyName())
                .RuleFor(t => t.CreatedAt, f => f.Date.Past(3))
                .Generate(ENTITY_COUNT)
                .ToList();
        }

        public static List<User> GenerateRandomUsers(List<Team> teams)
        {
            int userId = 1;

            return new Faker<User>()
                .RuleFor(u => u.Id, f => userId++)
                .RuleFor(u => u.TeamId, f => f.PickRandom(teams).Id)
                .RuleFor(u => u.FirstName, f => f.Person.FirstName)
                .RuleFor(u => u.LastName, f => f.Person.LastName)
                .RuleFor(u => u.Email, f => f.Person.Email)
                .RuleFor(u => u.RegisteredAt, f => f.Date.Past(3))
                .RuleFor(u => u.BirthDay, f => f.Date.Between(new DateTime(1920, 01, 01), new DateTime(DateTime.Now.Year - 16, 01, 01)))
                .Generate(ENTITY_COUNT)
                .ToList();
        }

        public static List<Project> GenerateRandomProjects(List<Team> teams, List<User> authors)
        {
            int projectId = 1;

            return new Faker<Project>()
                .RuleFor(p => p.Id, f => projectId++)
                .RuleFor(p => p.AuthorId, f => f.PickRandom(authors).Id)
                .RuleFor(p => p.TeamId, f => f.PickRandom(teams).Id)
                .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
                .RuleFor(p => p.CreatedAt, f => f.Date.Past(3))
                .RuleFor(p => p.Deadline, f => f.Date.Future(2))
                .Generate(ENTITY_COUNT)
                .ToList();
        }

        public static List<Task> GenerateRandomTasks(List<User> performers, List<Project> projects)
        {
            int taskId = 1;

            return new Faker<Task>()
                .RuleFor(t => t.Id, f => taskId++)
                .RuleFor(t => t.ProjectId, f => f.PickRandom(projects).Id)
                .RuleFor(t => t.PerformerId, f => f.PickRandom(performers).Id)
                .RuleFor(t => t.Name, f => f.Lorem.Word())
                .RuleFor(t => t.Description, f => f.Lorem.Sentence())
                .RuleFor(t => t.State, f => f.PickRandom<TaskState>())
                .RuleFor(t => t.CreatedAt, f => f.Date.Past(3))
                .RuleFor(t => t.FinishedAt, (f, t) => t.State == TaskState.Done ? f.Date.Past(1) : null)
                .Generate(ENTITY_COUNT)
                .ToList();
        }
    }
}

using BSATask.DAL;
using BSATask.DAL.Models.MappingProfiles;
using BSATask.DAL.Models.Projects;
using BSATask.DAL.Models.Tasks;
using BSATask.DAL.Models.Teams;
using BSATask.DAL.Models.Users;
using BSATask.DAL.Repositories;
using BSATask.DAL.Repositories.Interfaces;
using BSATask.Domain.Services;
using BSATask.Domain.Services.Interfaces;
using BSATask.WebAPI.Validators.ProjectValidator;
using BSATask.WebAPI.Validators.TaskValidator;
using BSATask.WebAPI.Validators.TeamValidator;
using BSATask.WebAPI.Validators.UserValidator;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BSATask.WebAPI.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.RegisterAutoMapper();

            services.AddRepositories();

            services.AddServicesLayers();

            services.AddValidators();

            return services;
        }

        public static void AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BSATaskContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DbConnection"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            });
        }

        public static void RegisterAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<TaskProfile>();
                cfg.AddProfile<UserProfile>();
                cfg.AddProfile<ProjectProfile>();
                cfg.AddProfile<TeamProfile>();
            },
            Assembly.GetExecutingAssembly());
        }

        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void AddServicesLayers(this IServiceCollection services)
        {
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILinqService, LinqService>();
        }

        public static void AddValidators(this IServiceCollection services)
        {
            services.AddSingleton<IValidator<ProjectCreateDto>, ProjectCreateValidator>();
            services.AddSingleton<IValidator<ProjectEditDto>, ProjectEditValidator>();
            services.AddSingleton<IValidator<TaskCreateDto>, TaskCreateValidator>();
            services.AddSingleton<IValidator<TaskEditDto>, TaskEditValidator>();
            services.AddSingleton<IValidator<TeamCreateDto>, TeamCreateValidator>();
            services.AddSingleton<IValidator<TeamEditDto>, TeamEditValidator>();
            services.AddSingleton<IValidator<UserCreateDto>, UserCreateValidator>();
            services.AddSingleton<IValidator<UserEditDto>, UserEditValidator>();
        }
    }
}

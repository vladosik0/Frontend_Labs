using BSATask.DAL.Entities;
using BSATask.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BSATask.DAL.Repositories
{
    public class ProjectRepository : GenericRepository<Project>, IProjectRepository
    {
        public ProjectRepository(BSATaskContext context) : base(context)
        {

        }

        public async override Task<Project> GetByIdAsync(int id)
        {
            return
                await _context.Projects
                        .Include(p => p.Tasks)
                        .Include(p => p.Author)
                            .ThenInclude(a => a.Team)
                        .SingleOrDefaultAsync(p => p.Id == id);
        }
    }
}

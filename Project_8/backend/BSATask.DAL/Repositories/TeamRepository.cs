using BSATask.DAL.Entities;
using BSATask.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BSATask.DAL.Repositories
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(BSATaskContext context) : base(context)
        {
        }

        public override async Task<Team> GetByIdAsync(int id)
        {
            return
                await _context.Teams
                    .Include(t => t.Projects)
                        .ThenInclude(p => p.Tasks)
                    .Include(t => t.Users)
                    .SingleOrDefaultAsync(t => t.Id == id);

        }
    }
}

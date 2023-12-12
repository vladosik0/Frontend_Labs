using BSATask.DAL.Entities;
using BSATask.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BSATask.DAL.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(BSATaskContext context) : base(context)
        {
        }

        public override async Task<User> GetByIdAsync(int id)
        {
            return
                await _context.Users
                    .Include(u => u.Tasks)
                    .Include(u => u.Projects)
                        .ThenInclude(p => p.Tasks)
                    .Include(u => u.Team)
                    .SingleOrDefaultAsync(u => u.Id == id);
        }
    }
}

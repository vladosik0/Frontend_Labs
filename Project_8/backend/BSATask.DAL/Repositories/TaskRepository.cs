using BSATask.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Task = BSATask.DAL.Entities.Task;

namespace BSATask.DAL.Repositories
{
    public class TaskRepository : GenericRepository<Task>, ITaskRepository
    {
        public TaskRepository(BSATaskContext context) : base(context)
        {
        }

        public override async Task<Task> GetByIdAsync(int id)
        {
            return
                await _context.Tasks
                    .Include(t => t.Project)
                    .Include(t => t.Performer)
                        .ThenInclude(p => p.Team)
                    .SingleOrDefaultAsync(t => t.Id == id);
        }
    }
}

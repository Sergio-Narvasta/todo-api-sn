using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces;
using ToDo.Infraestructure.Data;

namespace ToDo.Infraestructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly AppDbContext _dbContext;
        public TaskRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Tasks>> GetList()
        {
            return await _dbContext
                 .Tasks
                 .AsNoTracking()
                 .ToListAsync();
        }

        public async Task<Tasks> GetById(int id)
        {
            return await _dbContext.Tasks
                 .Where(s => s.Id == id)
                 .FirstAsync();
        }
        public async Task<bool> Insert(Tasks task)
        {
            try
            {
                await _dbContext
                    .Tasks
                    .AddAsync(task);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public async Task<bool> Update(Tasks task)
        {
            try
            {
                _dbContext
                    .Entry(task).State = EntityState.Detached;              
                _dbContext
                    .Tasks
                    .Update(task);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        public async Task<bool> Delete(int id)
        {
            try
            {
                await _dbContext.Tasks
                    .Where(s => s.Id == id)
                    .ExecuteDeleteAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

    }
}

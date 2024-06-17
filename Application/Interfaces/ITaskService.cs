
using ToDo.Domain.Entities;

namespace ToDo.Application.Interfaces
{
    public interface ITaskService
    {
        Task<bool> Delete(int id);
        Task<Tasks> GetById(int id);
        Task<List<Tasks>> GetList();
        Task<bool> Insert(Tasks task);
        Task<bool> Update(Tasks task);
    }
}

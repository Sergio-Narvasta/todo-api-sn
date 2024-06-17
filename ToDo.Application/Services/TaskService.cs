using ToDo.Application.Interfaces;
using ToDo.Domain.Entities;
using ToDo.Domain.Interfaces;

namespace ToDo.Application.Services
{
    public class TaskService(ITaskRepository taskRepository): ITaskService
    {
        private readonly ITaskRepository _taskRepository = taskRepository;
        public async Task<List<Tasks>> GetList() =>
            await _taskRepository.GetList();
        public async Task<Tasks> GetById(int id) =>
            await _taskRepository.GetById(id);

        public async Task<bool> Insert(Tasks task) =>
            await _taskRepository.Insert(task);

        public async Task<bool> Update(Tasks task) =>
            await _taskRepository.Update(task);

        public async Task<bool> Delete(int id) => 
            await _taskRepository.Delete(id);

    }
}

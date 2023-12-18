using TaskManagement.Models;

namespace TaskManagement.Interfaces
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskModel>> GetTasks();
        Task<TaskModel> GetTaskById(int taskId);
        Task<TaskModel> CreateTask(TaskModel task);
        Task<TaskModel> UpdateTask(TaskModel task);
        Task<bool> DeleteTask(int taskId);
    }
}

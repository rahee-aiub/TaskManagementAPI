using TaskManagement.Interfaces;
using TaskManagement.Models;

namespace TaskManagement.Services
{
    public class TaskService : ITaskService
    {
        private readonly List<TaskModel> _tasks = new List<TaskModel>();
        private int _taskIdCounter = 1;

        public async Task<IEnumerable<TaskModel>> GetTasks()
        {
            return await Task.FromResult(_tasks);
        }

        public async Task<TaskModel> GetTaskById(int taskId)
        {
            return await Task.FromResult(_tasks.FirstOrDefault(t => t.Id == taskId));
        }

        public async Task<TaskModel> CreateTask(TaskModel task)
        {
            task.Id = _taskIdCounter++;
            _tasks.Add(task);
            return await Task.FromResult(task);
        }

        public async Task<TaskModel> UpdateTask(TaskModel task)
        {
            var existingTask = _tasks.FirstOrDefault(t => t.Id == task.Id);
            if (existingTask != null)
            {
                existingTask.Title = task.Title;
                existingTask.Description = task.Description;
                existingTask.DueDate = task.DueDate;
                existingTask.Status = task.Status;
            }
            return await Task.FromResult(existingTask);
        }

        public async Task<bool> DeleteTask(int taskId)
        {
            var taskToRemove = _tasks.FirstOrDefault(t => t.Id == taskId);
            if (taskToRemove != null)
            {
                _tasks.Remove(taskToRemove);
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
    }
}

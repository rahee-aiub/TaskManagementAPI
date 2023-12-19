using Microsoft.EntityFrameworkCore;
using TaskManagement.Interfaces;
using TaskManagement.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskManagement.Services
{
    public class TaskService : ITaskService
    {


        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TaskModel>> GetTasks()
        {
    
            return await _context.Tasks.ToListAsync();
        }

        public async Task<TaskModel> GetTaskById(int taskId)
        {
            return await _context.Tasks.FirstOrDefaultAsync(t => t.Id == taskId);
        }

        public async Task<TaskModel> CreateTask(TaskModel task)
        {
            task.Id = 0;
            _context.Tasks.Add(task);
            _context.SaveChanges();
            return await Task.FromResult(task);
        }

        public async Task<TaskModel> UpdateTask(TaskModel task)
        {
            var existingTask = _context.Tasks.FirstOrDefault(t => t.Id == task.Id);
            if (existingTask != null)
            {
                existingTask.Title = task.Title;
                existingTask.Description = task.Description;
                existingTask.DueDate = task.DueDate;
                existingTask.Status = task.Status;
            }

            _context.SaveChanges();

            return await Task.FromResult(existingTask);
        }

        public async Task<bool> DeleteTask(int taskId)
        {
            var taskToRemove = _context.Tasks.FirstOrDefault(t => t.Id == taskId);
            if (taskToRemove != null)
            {
                _context.Tasks.Remove(taskToRemove);
                _context.SaveChanges();
                return await Task.FromResult(true);
            }
            return await Task.FromResult(false);
        }
    }
}

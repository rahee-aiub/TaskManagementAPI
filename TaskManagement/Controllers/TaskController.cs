using Microsoft.AspNetCore.Mvc;
using TaskManagement.Interfaces;

namespace TaskManagement.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }
    }
}

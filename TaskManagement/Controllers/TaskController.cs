using Microsoft.AspNetCore.Mvc;
using TaskManagement.Interfaces;
using TaskManagement.Models;

namespace TaskManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Policy = "BasicAuthentication")]
    public class TaskController : ControllerBase
    {

        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService ?? throw new ArgumentNullException(nameof(taskService));
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskModel>>> GetTasks()
        {
            if (_taskService.GetTasks == null)
            {
                return NotFound();
            }
            var data = await _taskService.GetTasks();
            return Ok(data);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetTaskModel(int id)
        {

            var taskModel = await _taskService.GetTaskById(id);

            if (taskModel == null)
            {
                return NotFound();
            }

            return taskModel;
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> PutTaskModel(int id, TaskModel taskModel)
        {
            if (id != taskModel.Id)
            {
                return BadRequest();
            }

            var data = _taskService.UpdateTask(taskModel);
            return Ok(data);
        }


        [HttpPost]
        public async Task<ActionResult<TaskModel>> PostTaskModel(TaskModel taskModel)
        {
            _taskService.CreateTask(taskModel);
            return CreatedAtAction("GetTaskModel", new { id = taskModel.Id }, taskModel);
        }

 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskModel(int id)
        {
            var taskModel = await _taskService.GetTaskById(id);
            if (taskModel == null)
            {
                return NotFound();
            }

 
            return Ok(_taskService.DeleteTask(id));
        }


    }
}

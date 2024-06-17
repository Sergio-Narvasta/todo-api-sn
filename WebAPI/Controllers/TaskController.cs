using Microsoft.AspNetCore.Mvc;
using ToDo.Application.Interfaces;
using ToDo.Application.Services;
using ToDo.Domain.Entities;
using ToDo.WebAPI.Models;

namespace ToDo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService ;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet(Name = "GetTaskList")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _taskService.GetList());
        }

        [HttpGet("{id}", Name = "GetTaskById")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _taskService.GetById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost(Name = "CreateTask")]
        public async Task<IActionResult> Post([FromBody] Tasks task)
        {
            var result = await _taskService.Insert(task);
            if (result)
            {
                return CreatedAtAction(nameof(Get), new { id = task.Id }, new ResponseModel()
                {
                    Message = ResponseMessage.RegisterSucess,
                    Status = result
                });
            }
            return BadRequest(new ResponseModel()
            {
                Message = ResponseMessage.OperationError,
                Status = result
            });
        }

        [HttpPut( Name = "UpdateTask")]
        public async Task<IActionResult> Put( [FromBody] Tasks task)
        {
            var result = await _taskService.Update(task);
            if (result)
            {
                return Ok(new ResponseModel()
                {
                    Message = ResponseMessage.UpdateSucess,
                    Status = result
                });
            }
            return NotFound(new ResponseModel()
            {
                Message = ResponseMessage.OperationError,
                Status = result
            });
        }

        [HttpDelete("{id}", Name = "DeleteTask")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _taskService.Delete(id);
            if (result)
            {
                return Ok(new ResponseModel(){
                    Message = ResponseMessage.DeleteSucess,
                    Status = result
                });
            }
            return NotFound(new ResponseModel()
            {
                Message = ResponseMessage.OperationError,
                Status = result
            });
        }

    }
}

using App.Adapters.Dtos;
using App.Adapters.Mappers;
using App.Database;
using App.Domain.Entities;
using App.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        private readonly AppDbContext _context;

        public TaskController(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        // GET: api/tasks
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Get()
        {
            var taskList = _taskRepository.GetType();
            return Ok(taskList);
        }

        // GET api/tasks/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Get(int id)
        {
            if (id <= 0)
                return BadRequest();

            TodoTask taskDto = await _taskRepository.FindTaskById(id);

            if (taskDto == null)
                return NotFound();

            GetTaskDto dto = taskDto.EntityToDTO();

            return Ok(dto);
        }

        // POST api/tasks
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post([FromBody] PostTaskDto taskDto)
        {
            if (taskDto == null)
                return BadRequest();

            _taskRepository.AddTask(taskDto);
            return Created();
        }

        // PUT api/tasks/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UpdateTaskDto taskDto)
        {
            if (id <= 0)
                return BadRequest();

            TodoTask findTask = await _taskRepository.FindTaskById(id);

            if (taskDto == null)
                return NotFound();

            
        }

        // DELETE api/tasks/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
                return BadRequest();

            TodoTask taskDto = await _taskRepository.FindTaskById(id);

            if (taskDto == null)
                return NotFound();

            _taskRepository.RemoveTask(id);

            return NoContent();

        }
    }
}

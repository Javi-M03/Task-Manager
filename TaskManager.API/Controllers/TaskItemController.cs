using Microsoft.AspNetCore.Mvc;
using Task_Manager.Domain.Entities;
using Task_Manager.DTOs;
using Task_Manager.Services;

namespace Task_Manager.Controllers
{
    [ApiController]
    [Route("api/task")]
    public class TaskItemController : ControllerBase
    {
        private readonly TaskItemService _service;
        public TaskItemController(TaskItemService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<List<GetTaskItemDto>>> GetAll() =>
        Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<GetTaskItemDto>> GetById(int id)
        {
            var task = await _service.GetByIdAsync(id);
            return task is null ? NotFound() : Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<GetTaskItemDto>> Create(CreateTaskItemDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTaskItemDto dto)
        {
            var success = await _service.UpdateAsync(id, dto);
            return success ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            return success ? NoContent() : NotFound();
        }
        
    }
}

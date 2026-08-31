using Microsoft.AspNetCore.Mvc;
using Task_Manager.Domain.Entities;
using Task_Manager.DTOs;
using Task_Manager.Services;

namespace Task_Manager.Controllers
{
    /// <summary>
    /// Controlador encargado del manejo de endpoints de la Api.
    /// </summary>
    [ApiController]
    [Route("api/task")]
    public class TaskItemController : ControllerBase
    {
        private readonly TaskItemService _service;
        public TaskItemController(TaskItemService service) => _service = service;

        /// <summary>
        /// Obtenemos todas las tareas.
        /// </summary>
        /// <response code="200">Retorna todas las tareas creadas.</response>
        

        [HttpGet]
        public async Task<ActionResult<List<GetTaskItemDto>>> GetAll() =>
        Ok(await _service.GetAllAsync());

        /// <summary>
        /// Obtenemos una tarea con el ID especificado.
        /// </summary>
        /// <param name="id">El ID de la tarea a buscar.</param>
        /// <response code="200">Retorna los datos de la tarea según el ID especificado.</response>
        /// <response code="404">No se encontró tarea con el ID especificado.</response>

        [HttpGet("{id}")]
        public async Task<ActionResult<GetTaskItemDto>> GetById(int id)
        {
            var task = await _service.GetByIdAsync(id);
            return task is null ? NotFoundProblem(id) : Ok(task);
        }

        /// <summary>
        /// Creamos una nueva tarea.
        /// </summary>
        /// <response code="201">Se creó la nueva tarea con éxito.</response>
        /// <response code="400">El título no puede ir vacío.</response>

        [HttpPost]
        public async Task<ActionResult<GetTaskItemDto>> Create(CreateTaskItemDto dto)
        {
            var created = await _service.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }
        /// <summary>
        /// Actualizamos una tarea existente según el ID especificado.
        /// </summary>
        /// <param name="id">El ID de la tarea a modificar.</param>
        /// <response code="204">La tarea se modificó con éxito.</response>
        /// <response code="400">El campo no puede ir vacío.</response>
        /// <response code="404">No se encontró tarea con el ID especificado.</response>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateTaskItemDto dto)
        {
            var success = await _service.UpdateAsync(id, dto);
            return success ? NoContent() : NotFoundProblem(id);
        }
        /// <summary>
        /// Eliminamos una tarea existente según el ID especificado.
        /// </summary>
        /// <param name="id">El ID de la tarea a eliminar.</param>
        /// <response code="204">La tarea se eliminó con éxito.</response>
        /// <response code="404">No se encontró tarea con el ID especificado.</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _service.DeleteAsync(id);
            return success ? NoContent() : NotFoundProblem(id);
        }

        private ActionResult NotFoundProblem(int id) =>
            NotFound(new ProblemDetails
            {
                Title = "Tarea no encontrada.",
                Detail = $"No existe la tarea con el id {id}.",
                Status = StatusCodes.Status404NotFound
            });
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Task_Manager.DTOs
{
    public class CreateTaskItemDto
    {
        [Required(ErrorMessage = "El título de la tarea no puede ir vacío.")]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}

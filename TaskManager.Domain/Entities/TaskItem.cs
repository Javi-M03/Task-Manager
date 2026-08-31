using System;
using System.Collections.Generic;
using System.Text;

namespace Task_Manager.Domain.Entities
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsDone { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedAt { get; set; }

        public TaskItem(string title, string description)
        {
            SetTitle(title);
            Description = description;
            IsDone = false;
            CreatedAt = DateTime.UtcNow;
        }

        public void SetTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) 
                throw new ArgumentNullException("El titulo de esta tarea no puede estar vacía",
                nameof(title));

            Title = title.Trim();
            UpdateTime();
        }

        public void Done()
        {
            IsDone = true;
            UpdateTime();
        }

        public void Undone()
        {
            IsDone = false;
            UpdateTime();
        }

        private void UpdateTime() => ModifiedAt = DateTime.UtcNow;

    }
}

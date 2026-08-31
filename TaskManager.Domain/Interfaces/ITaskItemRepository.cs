using System;
using System.Collections.Generic;
using System.Text;
using Task_Manager.Domain.Entities;

namespace Task_Manager.Domain.Interfaces
{
    public interface ITaskItemRepository
    {
        Task<List<TaskItem>> GetAllAsync();
        Task<TaskItem?> GetByIdAsync(int id);
        Task AddAsync(TaskItem task);
        void Update(TaskItem task);
        void Delete(TaskItem task);
        Task<bool> SaveChangesAsync();
    }
}

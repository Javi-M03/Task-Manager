using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Task_Manager.Domain.Entities;
using Task_Manager.Domain.Interfaces;
using Task_Manager.Infrastructure.Data;

namespace Task_Manager.Infrastructure.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private readonly AppDbContext _context;
        public TaskItemRepository(AppDbContext context) => _context = context;

        public async Task<List<TaskItem>> GetAllAsync() => await _context.TaskItems.ToListAsync();
        public async Task<TaskItem?> GetByIdAsync(int id) => await _context.TaskItems.FindAsync(id);
        public async Task AddAsync(TaskItem task) => await _context.TaskItems.AddAsync(task);
        public void Update(TaskItem task) => _context.TaskItems.Update(task);
        public void Delete(TaskItem task) => _context.TaskItems.Remove(task);
        public async Task<bool> SaveChangesAsync() => await _context.SaveChangesAsync() > 0;

    }
}
